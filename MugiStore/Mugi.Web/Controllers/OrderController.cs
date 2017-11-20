using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugi.Service.Services;
using AutoMapper;
using Mugi.Web.Extensions;
using Mugi.Web.Model.ViewModel;
using Mugi.Domain.Entities;
using Mugi.Web.Model;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MimeKit;
using MailKit.Net.Smtp;

namespace Mugi.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMapper Mapper;
        private IOrderService OrderService;
        private IAdvertisementService AdvertisementService;
        private IOrderSubProductService OrderSubProductService;
        private ISubProductService SubProductService;
        private IPromotionService PromotionService;
        private IServiceProvider _serviceProvider;
        private ICustomerService CustomerService;

        public OrderController(IOrderService orderService,
            IAdvertisementService advertisementService,
            IOrderSubProductService orderSubProductService,
            ISubProductService subProductService,
            IPromotionService promotionService,
            IMapper mapper,
            IServiceProvider serviceProvider,
            ICustomerService customerService)
        {
            this.Mapper = mapper;
            this.OrderService = orderService;
            this.AdvertisementService = advertisementService;
            this.OrderSubProductService = orderSubProductService;
            this.SubProductService = subProductService;
            this.PromotionService = promotionService;
            this._serviceProvider = serviceProvider;
            this.CustomerService = customerService;
        }

        public IActionResult ListOrdered()
        {
            var session = HttpContext.Session.GetSession("session");
            if (session != null)
            {
                var listOrders = this.OrderService.GetOrderByCustomerId(session.CustomerId);
                var listOrderedViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderedViewModel>>(listOrders);
                return View(listOrderedViewModel);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Payment()
        {
            SessionModel session = HttpContext.Session.GetSession("session");
            if (session == null)
            {
                TempData["ShopCart"] = "sessionempty";
                return RedirectToAction("ShopCart", "Product");
            }
            if (session.Products.Count() == 0)
            {
                TempData["ShopCart"] = "cartempty";
                return RedirectToAction("ShopCart", "Product");
            }
            if (session.CustomerId == 0)
            {
                TempData["LoginCustomer"] = "requestlogin";
                return RedirectToAction("LoginCustomer", "Customer");
            }
            return View();
        }

        private int GetCustomerId()
        {
            SessionModel session = HttpContext.Session.GetSession("session");
            return session.CustomerId;
        }

        [HttpPost]
        public IActionResult Payment(OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                SessionModel session = HttpContext.Session.GetSession("session");

                if (session != null && session.Products.Count() != 0 && session.CustomerId != 0)
                {
                    Order order = new Order();
                    List<OrderSubProduct> listOrderSubProduct = new List<OrderSubProduct>();
                    List<OrderProduct> listOrderProduct = new List<OrderProduct>();
                    OrderSubProduct temp = new OrderSubProduct();
                    OrderProduct temp1 = new OrderProduct();

                    int a = this.SubProductService
                        .CheckBeforeCheckout(session.Products.Select(x => x.SubProductId).ToArray());

                    if (a == -1)
                    {
                        var listSubProducts = this.SubProductService
                        .GetProductByListSubProductId(session.Products.Select(x => x.SubProductId).ToArray());

                        var productIds = listSubProducts.Select(x => x.ProductId).Distinct();
                        var promotionNow = this.PromotionService.GetNowPromotion();

                        foreach (int id in productIds)
                        {
                            var price = listSubProducts.Where(x => x.Product.Id == id)
                                .Select(x => x.Product.PriceDetails.OrderByDescending(y => y.CreatedDate)
                            .Select(y => y.Price).FirstOrDefault()).FirstOrDefault();
                            foreach (var promotion in promotionNow)
                            {
                                if (promotion.PromotionProducts.Select(x => x.ProductId).Contains(id))
                                {
                                    price = price - price * promotion.PromotionPercent / 100;
                                }
                            }

                            temp1 = new OrderProduct(id, price);
                            listOrderProduct.Add(temp1);
                        }


                        foreach (var item in session.Products)
                        {
                            temp = new OrderSubProduct();
                            temp.SubProductId = item.SubProductId;
                            temp.Quantity = item.NumberProduct;
                            listOrderSubProduct.Add(temp);
                        }
                        order.PhoneNumber = orderModel.PhoneNumber;
                        order.Address = orderModel.Address;
                        order.OrderSubProducts = listOrderSubProduct;
                        order.OrderProducts = listOrderProduct;
                        //order.CustomerId = session.CustomerId;
                        order.IsDeleted = false;
                        order.CreatedDate = DateTime.Now;
                        order.PaymentType = orderModel.PaymentType.ToString();

                        ////////////////////////
                        List<ShopCartViewModel> shopCart = new List<ShopCartViewModel>();
                        int total = 0;
                        int[] subProductIds = session.Products.Select(x => x.SubProductId).ToArray();
                        var subProducts = this.SubProductService.GetForShopCart(subProductIds);
                        shopCart = Mapper.Map<IEnumerable<SubProduct>, IEnumerable<ShopCartViewModel>>(subProducts).ToList();
                        foreach (var item in shopCart)
                        {
                            foreach (var item1 in session.Products)
                            {
                                if (item.SubProductId == item1.SubProductId)
                                {
                                    item.ProductOrder = item1.NumberProduct;
                                    if (item.PromotionPercent != 0)
                                        total += (item.Price * item.ProductOrder) - (item.Price * item.ProductOrder * item.PromotionPercent / 100);
                                    else
                                        total += item.Price * item.ProductOrder;
                                }
                            }
                        }
                        order.Total = total;
                        PayViewModel payViewModel = new PayViewModel(shopCart, total);
                        if (orderModel.PaymentType.ToString() == "PayPal")
                            TempData["PaymentType"] = "PayPal";
                        else
                            TempData["PaymentType"] = "None";
                        ViewBag.total = total;

                        //if (order.PaymentType == "PayPal")
                        //{
                        //    HttpContext.Session.SetSession("order", order);
                        //    return View("Pay", payViewModel);
                        //}
                        //else
                        //{
                        int orderId = this.OrderService.InsertOrder(order, GetCustomerId());
                        if (orderId != 0)
                        {
                            var customer = this.CustomerService.GetById(order.CustomerId);
                            SendMail(customer.Name, customer.Mail, orderId);
                            session.Products = new List<ProductInSessionModel>();
                            HttpContext.Session.SetSession("session", session);
                            return View("Pay", payViewModel);
                        }
                        else
                        {
                            ModelState.AddModelError("PaymentType", "Error");
                            return View(orderModel);
                        }
                        //}
                    }
                    else if (a == 0)
                    {
                        ModelState.AddModelError("Address", "Error");
                        return View(orderModel);
                    }
                    else
                    {
                        var subProduct = this.SubProductService.GetById(a);
                        ModelState.AddModelError("Address", "Sản phẩm "
                            + subProduct.Product.ProductName + " đã hết hàng. Chúng tôi rất xin lỗi về vấn đề này!");
                        return View(orderModel);
                    }


                }
                else
                {
                    ModelState.AddModelError("PaymentType", "Error");
                    return View(orderModel);
                }
            }
            else
            {
                return View(orderModel);
            }

        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.DisplayName;

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                var engine = _serviceProvider.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine; // Resolver.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = engine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    sw,
                    new HtmlHelperOptions() //Added this parameter in
                );

                //Everything is async now!
                var t = viewResult.View.RenderAsync(viewContext);
                t.Wait();

                return sw.GetStringBuilder().ToString();
            }
        }


        private void SendMail(string name, string email, int orderId)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(StaticValue.StaticValue.MAIL_FROM_NAME, StaticValue.StaticValue.MAIL_FROM_ADDRESS));
                message.To.Add(new MailboxAddress(name, email));
                BodyBuilder body = new BodyBuilder();
                var order = this.OrderService.GetForOrderDetails(orderId);
                var viewModel = Mapper.Map<Order, OrderedViewModel>(order);
                body.HtmlBody = RenderPartialViewToString("Mail", viewModel);
                message.Subject = "Mugi Shop";
                message.Body = body.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2");
                    // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     
                    client.Authenticate("nguyenlamtra95@gmail.com", "0913499062");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
          
        }
        public IActionResult Success()
        {
            //Order order = HttpContext.Session.GetOrder("order");
            //int orderId = this.OrderService.InsertOrder(order, GetCustomerId());
            //if (orderId != 0)
            //{
            SessionModel session = HttpContext.Session.GetSession("session");
            session.Products = new List<ProductInSessionModel>();
            //HttpContext.Session.SetSession("order", null);
            HttpContext.Session.SetSession("session", session);
            return View();
            //}

            //else
            //    return View("Error");
        }

        public IActionResult Error()
        {
            return View();
        }


        //// POST: Order
        //public JsonResult Order([FromBody] List<OrderViewModel> orderViewModels)
        //{
        //    if (orderViewModels.Count() == 0)
        //    {
        //        return Json("Empty");
        //    }
        //    var session = HttpContext.Session.GetSession("session");
        //    if (session == null || session.CustomerId == 0)
        //    {
        //        TempData["LoginCustomer"] = "RequestLogin";
        //        return Json("RequestLogin");
        //    }
        //    else
        //    {
        //        List<OrderSubProduct> listOrderSubProducts = new List<OrderSubProduct>();
        //        Order order = new Order();
        //        order.Customer.Id = session.CustomerId;// customer.Id;
        //        order.IsDeleted = false;
        //        foreach (var item in orderViewModels)
        //        {
        //            OrderSubProduct orderSubProduct = new OrderSubProduct();
        //            orderSubProduct.SubProductId = item.SubProductId;
        //            orderSubProduct.Quantity = item.NumberProduct;
        //            listOrderSubProducts.Add(orderSubProduct);
        //        }
        //        order.OrderSubProducts = listOrderSubProducts;

        //        if (this.OrderService.InsertOrder(order) != 0)
        //        {
        //            HttpContext.Session.SetSession("session", new List<ShopCartViewModel>());
        //            TempData["ShopCart"] = "OrderSuccess";
        //            return Json("Success");
        //        }
        //        else
        //        {
        //            return Json("Failed");
        //        }
        //    }
        //}
    }
}