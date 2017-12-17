using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugi.Service.Services;
using Mugi.Web.Model.ViewModel;
using Mugi.Web.Model;
using Mugi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using AutoMapper;
using Mugi.Web.Extensions;

namespace Mugi.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper Mapper;
        private ICategoryService CategoryService;
        private IProductService ProductService;
        private ISupplierService SupplierService;
        private IPriceDetailsService PriceDetailsService;
        private IImageProductService ImageProductService;
        private IAdvertisementService AdvertisementService;
        private ISubProductService SubProductService;
        private IOrderService OrderService;
        private IOrderSubProductService OrderSubProductService;

        private IAccountService AccountService;

        public ProductController(
            IMapper mapper,
            ICategoryService categoryService,
            IProductService productService,
            ISupplierService supplierService,
            IPriceDetailsService priceDetailsService,
            IImageProductService imageProductService,
            IAdvertisementService advertisementService,
            ISubProductService subProductService,
            IOrderService orderService,
            IOrderSubProductService orderSubProductService,

            IAccountService accountService)
        {
            this.Mapper = mapper;
            this.SupplierService = supplierService;
            this.PriceDetailsService = priceDetailsService;
            this.ImageProductService = imageProductService;
            this.CategoryService = categoryService;
            this.ProductService = productService;
            this.AdvertisementService = advertisementService;
            this.SubProductService = subProductService;
            this.OrderService = orderService;
            this.OrderSubProductService = orderSubProductService;

            this.AccountService = accountService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult FeedBack()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }

        //GET: Detail Product
        public IActionResult ProductDetails(int productId)
        {
            var product = this.ProductService.GetProductById(productId);
            var productModel = Mapper.Map<Product, ProductModel>(product);
            //foreach(var i in productDetailsViewModel.Properties)
            //{
            //    var temp = product.PropertyProducts
            //        .Where(x => x.PropertyId == i.Id).Select(x => x.Property.PropertyDetails).SingleOrDefault().ToList();
            //    i.PropertyDetailsOfSubProducts = Mapper.Map<List<PropertyDetails>, List<PropertyDetailsModel>>(temp);
            //}

            var _property = product.PropertyProducts.OrderBy(x => x.Property.PropertyName).Select(x => x.Property);
            var propertyModels = Mapper.Map<IEnumerable<Property>, IEnumerable<PropertyModel>>(_property);

            var subProducts = product.SubProducts.Where(x => x.ProductLeft > 0);
            var subProductModels = Mapper.Map<IEnumerable<SubProduct>, IEnumerable<SubProductModel>>(subProducts);

            foreach (PropertyModel property in propertyModels)
            {
                foreach (var subProductModel in subProductModels.Select(x => x.PropertyDetails))
                {
                    var temp = subProductModel.Where(x => x.Property.Id == property.Id).SingleOrDefault();
                    if (temp != null)
                    {
                        if (!propertyModels.Where(x => x.Id == property.Id)
                            .SingleOrDefault().PropertyDetailsOfSubProducts.Select(x => x.Id).Contains(temp.Id))
                            propertyModels.Where(x => x.Id == property.Id)
                                .SingleOrDefault().PropertyDetailsOfSubProducts.Add(temp);
                    }
                }
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel();
            productDetailsViewModel.ProductModel = productModel;

            productDetailsViewModel.PropertyModels = propertyModels.ToList();

            return View(productDetailsViewModel);
        }


        public IActionResult SearchProduct(string name)
        {
            var products = this.ProductService.GetForSearch(name);
            var searchResult = Mapper.Map<IEnumerable<Product>, IEnumerable<SearchHomePageModel>>(products);
            return Json(new { results = searchResult });
        }

        //GET: Shop Cart
        public IActionResult ShopCart()
        {
            //var shopCart = HttpContext.Session.GetCart("cart");
            List<ShopCartViewModel> shopCart = new List<ShopCartViewModel>();
            SessionModel session = HttpContext.Session.GetSession("session");
            int[] subProductIds = session.Products.Select(x => x.SubProductId).ToArray();
            var subProducts = this.SubProductService.GetForShopCart(subProductIds);
            shopCart = Mapper.Map<IEnumerable<SubProduct>, IEnumerable<ShopCartViewModel>>(subProducts).ToList();
            foreach(var item in shopCart)
            {
                foreach(var item1 in session.Products)
                {
                    if (item.SubProductId == item1.SubProductId)
                    {
                        item.ProductOrder = item1.NumberProduct;
                    }
                }
            }
            return View(shopCart);
        }

        private List<ProductModel> RemoveProduct(List<ProductModel> productModels)
        {
            List<ProductModel> temp = new List<ProductModel>();
            for (int i = 0; i < productModels.Count(); i++)
            {
                if (productModels.ElementAt(i).ProductLeft == 0 || productModels.ElementAt(i).PriceDetails == null)
                {
                    temp.Add(productModels.ElementAt(i));
                }
            }
            foreach (var i in temp)
            {
                productModels.Remove(i);
            }
            return productModels;
        }

        //GET: Home page
        public IActionResult HomePage()
        {
            HomePageViewModel homePageViewModel = new HomePageViewModel();

            var suppliers = SupplierService.GetAll();
            var supplierModels = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierModel>>(suppliers);
            homePageViewModel.SupplierModels = supplierModels.ToList();

            var products = ProductService.GetAllProducts();
            var productModels = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductModel>>(products).ToList();
           

            homePageViewModel.ProductModels = RemoveProduct(productModels);

            var categories = CategoryService.GetAllCategoriesAndSub();
            var categoryModels = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categories);
            homePageViewModel.CategoryModels = categoryModels.ToList();

            var advertisements = AdvertisementService.GetAdvertisements();
            var advertisementModels = Mapper.Map<IEnumerable<Advertisement>, IEnumerable<AdvertisementModel>>(advertisements);
            homePageViewModel.AdvertisementModels = advertisementModels.ToList();

            return View(homePageViewModel);
        }



        //GET: Home Page Filter
        public PartialViewResult Filter(HomePageFilterViewModel filter)
        {
            var products = ProductService.GetAllProductsByFilterId(
                filter.subCategoryId,
                filter.supplierIds,
                filter.priceFilterId,
                filter.staticFilterId);
            var productModels = Mapper.Map<IEnumerable<Product>,
                IEnumerable<ProductModel>>(products).ToList();
            
            return PartialView("_Product", RemoveProduct(productModels));
        }


        //GET Product Detais Filter
        public JsonResult ProductDetailsFilter(ProductDetailsFilterViewModel filter)
        {
            try
            {
                var product = this.ProductService.GetProductById(filter.ProductId);
                var _property = product.PropertyProducts.OrderBy(x => x.Property.PropertyName).Select(x => x.Property);
                var propertyModels = Mapper.Map<IEnumerable<Property>, IEnumerable<PropertyModel>>(_property);

                var subProducts = product.SubProducts.Where(x => x.ProductLeft > 0);
                var subProductModels = Mapper.Map<IEnumerable<SubProduct>, IEnumerable<SubProductModel>>(subProducts);
                foreach (PropertyModel property in propertyModels)
                {
                    foreach (var subProduct in subProductModels)
                    {
                        var propertyDetails = subProduct.PropertyDetails;
                        int count = 0;
                        foreach (var i in filter.PropertyDetailsIds)
                        {
                            if (propertyDetails.Select(x => x.Id).Contains(i)) count++;
                        }
                        if (count == filter.PropertyDetailsIds.Length)
                        {
                            var temp = propertyDetails.Where(x => x.Property.Id == property.Id).SingleOrDefault();
                            propertyModels.Where(x => x.Id == property.Id).FirstOrDefault()
                           .PropertyDetailsOfSubProducts.Add(temp);
                        }
                        //var temp1 = propertyDetails.Where(x => filter.PropertyDetailsIds.Contains(x.Id));
                        //if (temp1.Count() != 0)
                        //{
                        //    var temp = propertyDetails.Where(x => x.Property.Id == property.Id).FirstOrDefault();
                        //    propertyModels.Where(x => x.Id == property.Id).FirstOrDefault()
                        //   .PropertyDetailsOfSubProducts.Add(temp);
                        //}
                    }
                }
                return Json(propertyModels);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Json("");
            }
            
        }

        //POST Add Cart
        public JsonResult AddCart([FromBody] ProductDetailsFilterViewModel filter)
        {
            if (filter == null) return Json("failed");
            var product = this.ProductService.GetProductById(filter.ProductId);
            var properties = product.PropertyProducts.OrderBy(x => x.Property.PropertyName).Select(x => x.Property);
            var subProducts = product.SubProducts.Where(x => x.ProductLeft > 0);
            var subProductModels = Mapper.Map<IEnumerable<SubProduct>, IEnumerable<SubProductModel>>(subProducts);
            SubProductModel subProduct = new SubProductModel();
            foreach (var item in subProductModels)
            {
                var propertyDetails = item.PropertyDetails;
                int count = 0;
                for (int i = 0; i < propertyDetails.Count(); i++)
                {
                    for (int j = 0; j < filter.PropertyDetailsIds.Count(); j++)
                    {
                        if (propertyDetails[i].Id == filter.PropertyDetailsIds[j]) count++;
                    }
                }
                if (properties.Count() == count)
                {
                    subProduct = item;
                    break;
                }
            }

            if (subProduct.Id != 0)
            {
                //var temp = this.SubProductService.GetBySubProductById(subProduct.Id);
                //var shopCart = Mapper.Map<SubProduct, ShopCartViewModel>(temp);
                //List<ShopCartViewModel> listShopCartViewModel =
                //    HttpContext.Session.GetCart("cart");
                //foreach (var item in listShopCartViewModel)
                //{
                //    if (item.SubProductId == subProduct.Id)
                //    {
                //        return Json("duplicate");
                //    }
                //}
                //shopCart.ProductOrder = 1;
                //listShopCartViewModel.Add(shopCart);
                //HttpContext.Session.SetSession("cart", listShopCartViewModel);
                //HttpContext.Session.SetInt32("count", listShopCartViewModel.Count());

                ProductInSessionModel productInSessionModel = new ProductInSessionModel();
                productInSessionModel.SubProductId = subProduct.Id;
                productInSessionModel.NumberProduct = 1;

                SessionModel session = HttpContext.Session.GetSession("session");
                foreach(var item in session.Products)
                {
                    if (item.SubProductId == subProduct.Id)
                    {
                        return Json("duplicate");
                    }
                }
                session.Products.Add(productInSessionModel);
                HttpContext.Session.SetSession("session", session);

                return Json("success");
            }
            else
            {
                return Json("failed");
            }
        }

        public JsonResult ChangeNumberProduct([FromBody] OrderViewModel orderViewModel)
        {
            //List<ShopCartViewModel> listOrderSubProducts = new List<ShopCartViewModel>();
            //listOrderSubProducts = HttpContext.Session.GetCart("cart");
            //foreach(var item in listOrderSubProducts)
            //{
            //    if (item.SubProductId == orderViewModel.SubProductId)
            //    {
            //        item.ProductOrder = orderViewModel.NumberProduct;
            //        HttpContext.Session.SetSession("cart",listOrderSubProducts);
            //        return Json("success");
            //    }
            //}
            SessionModel session= HttpContext.Session.GetSession("session");
            foreach (var item in session.Products)
            {
                if (item.SubProductId == orderViewModel.SubProductId)
                {
                    item.NumberProduct = orderViewModel.NumberProduct;
                    HttpContext.Session.SetSession("session", session);
                    return Json("success");
                }
            }
            return Json("failed");
        }


        public void Test()
        {
            var a = this.CategoryService.GetTest();
            var b = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel> >(a);
        }

    }
}