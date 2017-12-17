using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugi.Web.Model.ViewModel;
using Mugi.Service.Services;
using AutoMapper;
using Mugi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Mugi.Web.Model;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Mugi.Web.Extensions;
using MimeKit;
using MailKit.Net.Smtp;
using Mugi.Web.Service;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using COmpStoreClient.Filters;

namespace Mugi.Web.Controllers
{
    [ValidateAdmin]
    public class StaffController : Controller
    {
        private IMapper Mapper;
        private ISupplierService SupplierService;
        private IPropertyService PropertyService;
        private ISubCategoryService SubCategoriesService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IProductService ProductService;
        private IPropertyDetailsService PropertyDetailsService;
        private ISubProductService SubProductService;
        private IImageProductService ImageProductService;
        private ICategoryService CategoryService;
        private IAdvertisementService AdvertisementService;
        private IGoodsReceiptService GoodsReceiptService;
        private IGoodsReceiptProductService GoodsReceiptProductService;
        private IStaffServie StaffService;
        private IAccountService AccountService;
        private IOrderService OrderService;
        private IReturnProductService ReturnProductService;
        private IPromotionService PromotionService;
        //private IShopOrderService ShopOrderService;
        private IGoodsReceiptSubProductService GoodsReceiptSubProductService;

        public StaffController(
            IMapper mapper,
            IViewRenderService viewRenderService,
            ISupplierService supplierService,
            IPropertyService propertyService,
            ISubCategoryService subCategoriesService,
            IHostingEnvironment hostingEnvironment,
            IProductService productService,
            IPropertyDetailsService propertyDetailsService,
            ISubProductService subProductService,
            ISubCategoryService subCategoryService,
            IImageProductService imageProductService,
            ICategoryService categoryService,
            IAdvertisementService advertisementService,
            IGoodsReceiptService goodsReceiptService,
            IStaffServie staffService,
            IAccountService accountService,
            IOrderService orderService,
            IReturnProductService returnProductService,
            IPromotionService promotionService,
            //IShopOrderService shopOrderService,
            IGoodsReceiptProductService goodsReceiptProductService,
            IGoodsReceiptSubProductService goodsReceiptSubProductService)
        {
            this.Mapper = mapper;
            this.SupplierService = supplierService;
            this.PropertyService = propertyService;
            this.SubCategoriesService = subCategoriesService;
            this._hostingEnvironment = hostingEnvironment;
            this.ProductService = productService;
            this.PropertyDetailsService = propertyDetailsService;
            this.SubProductService = subProductService;
            this.ImageProductService = imageProductService;
            this.CategoryService = categoryService;
            this.AdvertisementService = advertisementService;
            this.GoodsReceiptService = goodsReceiptService;
            this.StaffService = staffService;
            this.AccountService = accountService;
            this.OrderService = orderService;
            this.ReturnProductService = returnProductService;
            this.PromotionService = promotionService;
            //this.ShopOrderService = shopOrderService;
            this.GoodsReceiptProductService = goodsReceiptProductService;
            this.GoodsReceiptSubProductService = goodsReceiptSubProductService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HandleOrder()
        {
            return View();
        }

        public IActionResult GetReport()
        {
            return View();
        }



        public IActionResult UpdateProduct(int productId)
        {
            var suppliers = this.SupplierService.GetAll();
            var product = this.ProductService.GetForUpdateProduct(productId);
            var subCategories = this.SubCategoriesService.GetAll();
            var viewModel = Mapper.Map<Product, UpdateProductViewModel>(product);
            viewModel.Suppliers = Mapper.Map<IEnumerable<Supplier>, IEnumerable<BasicProperty>>(suppliers).ToList();
            viewModel.SubCategories = Mapper.Map<IEnumerable<SubCategory>, IEnumerable<BasicProperty>>(subCategories).ToList();
            return View(viewModel);
        }

        //public IActionResult Test()
        //{
        //    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //    mail.To.Add("to gmail address");
        //    mail.From = new MailAddress("from gmail address", "Email head", System.Text.Encoding.UTF8);
        //    mail.Subject = "This mail is send from asp.net application";
        //    mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //    mail.Body = "This is Email Body Text";
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    mail.IsBodyHtml = true;
        //    mail.Priority = MailPriority.High;
        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("from gmail address", "your gmail account password");
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";
        //    client.EnableSsl = true;
        //    try
        //    {
        //        client.Send(mail);
        //        Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        Exception ex2 = ex;
        //        string errorMessage = string.Empty;
        //        while (ex2 != null)
        //        {
        //            errorMessage += ex2.ToString();
        //            ex2 = ex2.InnerException;
        //        }
        //        Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
        //    }

        //}

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductViewModel viewModel)
        {
            var suppliers = this.SupplierService.GetAll();
            var temp = this.ProductService.GetForUpdateProduct(viewModel.Id);
            var subCategories = this.SubCategoriesService.GetAll();

            if (ModelState.IsValid)
            {
                if (suppliers.Select(x => x.Id).Contains(viewModel.SupplierId) && subCategories.Select(x => x.Id).Contains(viewModel.SubCategoryId))
                {
                    if (temp != null)
                    {
                        var product = Mapper.Map<UpdateProductViewModel, Product>(viewModel);
                        product.PriceDetails = new List<PriceDetails>();
                        product.PriceDetails.Add(new PriceDetails(viewModel.Price));
                        if (this.ProductService.Update(product))
                        {
                            TempData["UpdateProduct"] = "Success";

                            return RedirectToAction("UpdateProduct", "Staff", new { productId = viewModel.Id });
                        }
                        else
                        {
                            TempData["UpdateProduct"] = "Failed";
                            return RedirectToAction("UpdateProduct", "Staff", new { productId = viewModel.Id });
                        }
                    }
                    else
                    {
                        TempData["UpdateProduct"] = "Failed";
                        return RedirectToAction("UpdateProduct", "Staff", new { productId = viewModel.Id });
                    }
                }
                else
                {
                    TempData["UpdateProduct"] = "Failed";
                    return RedirectToAction("UpdateProduct", "Staff", new { productId = viewModel.Id });
                }
            }
            else
            {
                viewModel.Suppliers = Mapper.Map<IEnumerable<Supplier>, IEnumerable<BasicProperty>>(suppliers).ToList();
                viewModel.SubCategories = Mapper.Map<IEnumerable<SubCategory>, IEnumerable<BasicProperty>>(subCategories).ToList();
                return View(viewModel);
            }
        }

        public IActionResult AddImageProduct(int productId)
        {
            var images = this.ImageProductService.GetImageProductByProductId(productId);
            var product = this.ProductService.GetProductForAddImageView(productId);
            product.ImageProducts = new List<ImageProduct>();
            product.ImageProducts = images.ToList();
            var viewModel = Mapper.Map<Product, AddImageProductViewModel>(product);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddImageProduct(AddImageProductViewModel viewModel)
        {
            var file = viewModel.Image;
            var filePath = _hostingEnvironment.WebRootPath + "\\images\\ProductImages";
            if (ModelState.IsValid)
            {
                if (this.ImageProductService.Add(viewModel.Id, file.FileName))
                {
                    using (var stream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    TempData["AddImageProduct"] = "Success";
                    return RedirectToAction("AddImageProduct", "Staff", new { productId = viewModel.Id });
                }
                else
                {
                    TempData["AddImageProduct"] = "Failed";
                    return RedirectToAction("AddImageProduct", "Staff", new { productId = viewModel.Id });
                }
            }
            else
            {
                return RedirectToAction("AddImageProduct", "Staff", new { productId = viewModel.Id });
            }


        }


        [HttpPost]
        public IActionResult DeleteImageProduct(int imageId)
        {
            if (this.ImageProductService.Delete(imageId))
            {
                return Json("Success");
            }
            else
            {
                return Json("Failed");
            }
        }

        public IActionResult Delete(int productId)
        {
            if (this.ProductService.Delete(productId))
            {
                TempData["ListProduct"] = "Success";
            }
            else
            {
                TempData["ListProduct"] = "Failed";
            }
            return RedirectToAction("ListProduct", "Staff");
        }

        public IActionResult AddSubProduct(int productId)
        {
            var product = this.ProductService.GetForAddSubProductView(productId);
            var viewModel = Mapper.Map<Product, AddSubProductViewModel>(product);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddSubProduct([FromBody] AddProductModel model)
        {
            var product = this.ProductService.GetForAddSubProductView(model.ProductId);
            var temp = Mapper.Map<Product, AddSubProductViewModel>(product);
            List<ErrorModel> errors = new List<ErrorModel>();
            var propertiesId = this.PropertyDetailsService.GetPropertyIdsByPropertyDetailsIds(model.PropertyDetailIds);

            foreach (var item in temp.Properties)
            {
                if (!propertiesId.Contains(item.Id))
                {
                    errors.Add(new ErrorModel(item.Id.ToString(), item.PropertyName + " không được trống!"));
                }
            }

            if (errors.Any())
            {
                return Json(new { status = "fails", errors = errors });
            }
            else
            {
                if (!this.SubProductService.CheckSubProduct(model.ProductId, model.PropertyDetailIds))
                {
                    return Json(new { status = "exist", error = "Mặt hàng này đã tồn tại!" });
                }
                else
                {
                    SubProduct subProduct = new SubProduct(model.ProductId, model.PropertyDetailIds);
                    if (this.SubProductService.Add(subProduct))
                        return Json(new { status = "success" });
                    else
                        return Json(new { status = "insertFailed", error = "Insert Failed!" });
                }

            }
        }

        public IActionResult ListProduct()
        {
            var listProduct = this.ProductService.GetForListProductView();
            var listProductView = Mapper.Map<IEnumerable<Product>, IEnumerable<ListProductViewModel>>(listProduct);
            return View(listProductView);
        }

        public IActionResult AddProduct()
        {
            return View(new InsertProductViewModel(GetSubCategories(), GetProperies(), GetSuppliers()));
        }

        private List<PropertyInInserProduct> GetSuppliers()
        {
            return Mapper.Map<IEnumerable<Supplier>,
                IEnumerable<PropertyInInserProduct>>(this.SupplierService.GetAll()).ToList();
        }
        private List<PropertyInInserProduct> GetProperies()
        {
            return Mapper.Map<IEnumerable<Property>,
                IEnumerable<PropertyInInserProduct>>(this.PropertyService.GetAll()).ToList();
        }
        private List<PropertyInInserProduct> GetSubCategories()
        {
            return Mapper.Map<IEnumerable<SubCategory>,
                IEnumerable<PropertyInInserProduct>>(this.SubCategoriesService.GetAll()).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(InsertProductViewModel insertProductViewModel)
        {


            if (ModelState.IsValid)
            {
                var file = insertProductViewModel.Image;
                var filePath = _hostingEnvironment.WebRootPath + "\\images\\ProductImages";
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    Product product = new Product(
                        insertProductViewModel.ProductName.Trim(), insertProductViewModel.Description,
                        insertProductViewModel.SubCategoryId, insertProductViewModel.SupplierId,
                        file.FileName, insertProductViewModel.PropertyIds/*, insertProductViewModel.Price*/);
                    this.ProductService.Add(product);
                }
                TempData["AddProduct"] = true;
                return RedirectToAction("AddProduct", "Staff");
            }
            else
            {
                insertProductViewModel.Suppliers = GetSuppliers();
                insertProductViewModel.Properties = GetProperies();
                insertProductViewModel.SubCategories = GetSubCategories();
                return View(insertProductViewModel);
            }

        }

        public IActionResult SearchProduct(string name)
        {


            var products = this.ProductService.GetForSearch(name);
            var searchResult = Mapper.Map<IEnumerable<Product>, IEnumerable<SearchModel>>(products);
            return Json(new { results = searchResult });
        }

        public IActionResult GoodsReceiptSearch(string name)
        {


            var products = this.ProductService.GetForSearch(name);
            var searchResult = Mapper.Map<IEnumerable<Product>, IEnumerable<SearchGoodsReceiptModel>>(products);
            return Json(new { results = searchResult });
        }

        [HttpPost]
        public IActionResult GoodsReceiptProduct(int productId)
        {


            var product = this.ProductService.GetForGoodsReceipt(productId);
            var result = Mapper.Map<Product, ProductForGoodsReceiptModel>(product);
            return PartialView("_GoodsReceipt", result);
        }

        public IActionResult AddCategory()
        {


            var categories = this.CategoryService.GetAllCategories();
            AddCategoryViewModel viewModel = new AddCategoryViewModel();
            viewModel.Categories = Mapper.Map<IEnumerable<Category>, IEnumerable<BasicProperty>>(categories).ToList();
            return View(viewModel);
        }

        public IActionResult GetDescriptionCategory(int categoryId)
        {


            string description = this.CategoryService.GetDescription(categoryId);
            return Json(description);
        }

        [HttpPost]
        public IActionResult AddOrUpdateCategory([FromBody] AddCategoryViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                var category = Mapper.Map<AddCategoryViewModel, Category>(viewModel);

                if (viewModel.Id == 0)
                {
                    if (this.CategoryService.IsExistName(viewModel.CategoryName))
                    {
                        return Json(new { status = "InsertFailed" });
                    }
                    if (this.CategoryService.Add(category))
                    {
                        return Json(new { status = "InsertSuccess" });
                    }
                    else
                    {
                        return Json(new { status = "InsertFailed" });
                    }
                }
                else
                {
                    if (this.CategoryService.CheckUpdate(viewModel.CategoryName, viewModel.Id))
                    {
                        if (this.CategoryService.Update(category))
                        {
                            return Json(new { status = "UpdateSuccess" });
                        }
                        else
                        {
                            return Json(new { status = "UpdateFailed" });
                        }

                    }
                    else
                    {
                        return Json(new { status = "UpdateFailed" });
                    }

                }

            }
            else
            {
                var errors = GetError(ModelState);
                return Json(new { status = "Error", errors = errors });
            }

        }

        public IActionResult AddSubCategory(int categoryId)
        {


            AddSubCategoryViewModel viewModel = new AddSubCategoryViewModel();
            viewModel.Categories = Mapper.Map<IEnumerable<Category>,
                IEnumerable<BasicProperty>>(this.CategoryService.GetAllCategories()).ToList();
            viewModel.SubCategories = Mapper.Map<IEnumerable<SubCategory>,
                IEnumerable<SubCategoryInAddSubCategoryView>>(this.SubCategoriesService.GetByCategoryId(categoryId)).ToList();
            viewModel.CategoryId = categoryId;
            return View(viewModel);

        }

        public IActionResult DeleteSubCategory(int subCategoryId)
        {
            if (SubCategoriesService.Delete(subCategoryId))
                return Json(true);
            else
                return Json(false);
        }

        public IActionResult DeleteCategory(int categoryId)
        {
            if (this.CategoryService.Delete(categoryId))
                return Json(true);
            else
                return Json(false);
        }

        private List<ModelErrorCollection> GetError(ModelStateDictionary modelState)
        {
            return ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
        }

        [HttpPost]
        public IActionResult AddOrUpdateSubCategory([FromBody] SubCategoryViewModel viewModel)
        {


            viewModel.SubCategoryName = viewModel.SubCategoryName.Trim();
            if (ModelState.IsValid)
            {
                var subCategory = Mapper.Map<SubCategoryViewModel, SubCategory>(viewModel);
                if (viewModel.Id != 0)
                {
                    if (this.SubCategoriesService.CheckNameForUpdate(viewModel.SubCategoryName, viewModel.Id, viewModel.CategoryId))
                    {
                        if (this.SubCategoriesService.Update(subCategory))
                        {
                            return Json(new { status = "UpdateSuccess" });
                        }
                        else
                        {
                            return Json(new { status = "UpdateFailed" });
                        }
                    }
                    else
                    {
                        return Json(new { status = "UpdateFailed" });
                    }
                }
                else
                {
                    if (this.SubCategoriesService.CheckNameForInsert(viewModel.SubCategoryName, viewModel.CategoryId))
                    {
                        return Json(new { status = "InsertFailed" });
                    }
                    if (this.SubCategoriesService.Add(subCategory))
                    {
                        return Json(new { status = "InsertSuccess" });
                    }
                    else
                    {
                        return Json(new { status = "InsertFailed" });
                    }
                }
            }
            else
            {
                var errors = GetError(ModelState);
                return Json(new { status = "Error", errors = errors });
            }

        }


        [HttpPost]
        public IActionResult AddSupplier(string supplierName)
        {


            if (supplierName.Trim().Length > StaticValue.StaticValue.SUPPLIERNAME_LENGTH)
            {
                return Json(new { Status = "Length" });
            }
            Supplier supplier = new Supplier();
            supplier.SupplierName = supplierName;
            var result = this.SupplierService.Add(supplier);
            if (result != null)
            {
                return Json(new { Status = "Success", Id = result.Id });
            }
            else
            {
                return Json(new { Status = "Failed" });
            }
        }

        [HttpPost]
        public IActionResult AddProperty(string propertyName)
        {


            Property property = new Property();
            if (propertyName.Length > StaticValue.StaticValue.PROPERTYNAME_LENGTH)
            {
                return Json(new { Status = "Length" });
            }
            else
            {
                property.PropertyName = propertyName.Trim();
                if (this.PropertyService.Check(property.PropertyName))
                {
                    var result = this.PropertyService.Add(property);
                    if (result != null)
                    {
                        return Json(new { Status = "Success", Id = result.Id });
                    }
                    else
                    {
                        return Json(new { Status = "Failed" });
                    }
                }
                else
                {
                    return Json(new { Status = "Equals" });
                }

            }
        }

        public IActionResult AddPropertyDetails()
        {



            AddPropertyDetailsViewModel viewModel = new AddPropertyDetailsViewModel();
            var properties = this.PropertyService.GetAll();
            viewModel.Properties = Mapper.Map<IEnumerable<Property>, IEnumerable<BasicProperty>>(properties).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPropertyDetails(AddPropertyDetailsViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                viewModel.PropertyValue = viewModel.PropertyValue.Trim();

                var propertyDetails = Mapper.Map<AddPropertyDetailsViewModel, PropertyDetails>(viewModel);
                if (this.PropertyDetailsService.CheckExist(viewModel.PropertyValue))
                {
                    if (this.PropertyDetailsService.Add(propertyDetails))
                    {
                        TempData["AddPropertyDetails"] = "Success";
                        return RedirectToAction("AddPropertyDetails", "Staff");
                    }
                    else
                    {
                        var properties = this.PropertyService.GetAll();
                        viewModel.Properties = Mapper.Map<IEnumerable<Property>,
                            IEnumerable<BasicProperty>>(properties).ToList();
                        ModelState.AddModelError("PropertyValue", "Thuộc tính đã tồn tại");
                        return View(viewModel);
                    }
                }
                else
                {
                    var properties = this.PropertyService.GetAll();
                    viewModel.Properties = Mapper.Map<IEnumerable<Property>,
                        IEnumerable<BasicProperty>>(properties).ToList();
                    ModelState.AddModelError("PropertyValue", "Thuộc tính đã tồn tại");
                    return View(viewModel);
                }

            }
            else
            {
                var properties = this.PropertyService.GetAll();
                viewModel.Properties = Mapper.Map<IEnumerable<Property>,
                    IEnumerable<BasicProperty>>(properties).ToList();
                return View(viewModel);
            }

        }

        public IActionResult AddAdvertisement()
        {


            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddAdvertisement(AddAdvertisementViewModel viewModel)
        {


            var file = viewModel.Image;
            var filePath = _hostingEnvironment.WebRootPath + "\\images\\ProductImages";
            SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
            if (ModelState.IsValid)
            {
                if (session.StaffId != 0)
                {
                    var advertisement = Mapper.Map<AddAdvertisementViewModel, Advertisement>(viewModel);
                    advertisement.Url = viewModel.Image.FileName;
                    advertisement.StaffId = session.StaffId;
                    if (this.AdvertisementService.Add(advertisement))
                    {
                        using (var stream = new FileStream(Path.Combine(filePath, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        TempData["AddAdvertisement"] = "Success";
                        return RedirectToAction("AddAdvertisement", "Staff");
                    }
                    else
                    {
                        TempData["AddAdvertisement"] = "Failed";
                        return RedirectToAction("AddAdvertisement", "Staff");
                    }
                }
                else
                {
                    return RedirectToAction("LoginStaff", "Staff");
                }

            }
            else
            {
                return View();
            }

        }

        public IActionResult GoodsReceipt()
        {


            return View();
        }

        [HttpPost]
        public IActionResult GoodsReceipt([FromBody] List<GoodsReceiptModel> products)
        {


            if (products.Any())
            {
                GoodsReceipt goodsReceipt = new GoodsReceipt();
                GoodsReceiptProduct temp = new GoodsReceiptProduct();
                GoodsReceiptSubProduct temp1 = new GoodsReceiptSubProduct();
                List<PriceDetails> priceDetails = new List<PriceDetails>();

                foreach (var product in products)
                {
                    temp = new GoodsReceiptProduct();
                    temp.ProductId = product.ProductId;
                    temp.PriceInsert = product.PriceInput;
                    priceDetails.Add(new PriceDetails(product.PriceOutput, product.ProductId));
                    foreach (var subProduct in product.SubProducts)
                    {
                        temp1 = new GoodsReceiptSubProduct();
                        temp1.SubProductId = subProduct.SubProductId;
                        temp1.Quantity = subProduct.Quantity;
                        goodsReceipt.GoodsReceiptSubProducts.Add(temp1);
                    }
                    goodsReceipt.GoodsReceiptProducts.Add(temp);
                }
                if (this.GoodsReceiptService.Add(goodsReceipt, priceDetails, GetStaffId()))
                    return Json("Success");
                else
                    return Json("Failed");
            }
            else
                return Json("Error");
        }












        public IActionResult RegisterStaff()
        {


            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterStaff
            (RegisterStaffViewModel registerStaffViewModel)
        {


            if (ModelState.IsValid)
            {
                registerStaffViewModel.Account.UserName = registerStaffViewModel.Account.UserName.Trim();
                registerStaffViewModel.Account.Password = registerStaffViewModel.Account.Password.Trim();
                registerStaffViewModel.Mail = registerStaffViewModel.Mail.Trim();
                registerStaffViewModel.Name = registerStaffViewModel.Name.Trim();
                registerStaffViewModel.RePassword = registerStaffViewModel.RePassword.Trim();
                if (registerStaffViewModel.RePassword == registerStaffViewModel.Account.Password)
                {

                    Staff staff = Mapper.Map<RegisterStaffViewModel, Staff>(registerStaffViewModel);
                    int check = this.StaffService.GetStaffIdByEmail(staff.Mail);

                    if (check == 0)
                    {
                        if (StaffService.AddStaff(staff, StaticValue.StaticValue.PERMISSION_STAFF))
                        {
                            //var customerModel = Mapper.Map<Customer, CustomerModel>(customer);
                            SessionStaffModel session = new SessionStaffModel();
                            session.StaffId = this.StaffService.GetStaffIdByEmail(staff.Mail);
                            session.StaffName = staff.Name;
                            HttpContext.Session.SetSession("sessionStaff", session);
                            HttpContext.Session.SetString("permission", StaticValue.StaticValue.PERMISSION_STAFF);
                            return RedirectToAction("Index", "Staff");
                        }
                        else
                        {
                            ModelState.AddModelError("Account.UserName", "Tài khoản trùng");
                            return View(registerStaffViewModel);
                        }
                    }

                    else
                    {
                        ModelState.AddModelError("Mail", "Mail đã tồn tại!");
                        return View(registerStaffViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("RePassword", "Mật khẩu nhập lại không đúng!");
                    return View(registerStaffViewModel);
                }
            }
            else
            {
                return View(registerStaffViewModel);
            }
        }




        //POST: UpdateProfile
        [HttpPost]
        public IActionResult StaffProfile(StaffProfileViewModel staffProfileViewModel)
        {


            if (ModelState.IsValid)
            {
                var staff = Mapper.Map<StaffProfileViewModel, Staff>(staffProfileViewModel);
                if (this.StaffService.Update(staff))
                {
                    SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
                    session.StaffName = staff.Name;
                    HttpContext.Session.SetSession("sessionStaff", session);
                    return View(staffProfileViewModel);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(staffProfileViewModel);
            }
        }

        // GET: 
        public IActionResult StaffProfile()
        {


            //CustomerModel customer = HttpContext.Session.GetCustomer("customer");
            SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
            //if (customer.Name != null)
            if (session != null)
            {
                //var temp = this.CustomerService.GetById(customer.Id);
                var temp = this.StaffService.GetById(session.StaffId);
                var staffProfileViewModel = Mapper.Map<Staff, StaffProfileViewModel>(temp);
                return View(staffProfileViewModel);
            }
            else
                return View();
        }

        // GET: Logout
        public IActionResult LogoutStaff()
        {


            HttpContext.Session.SetSession("sessionStaff", null);
            HttpContext.Session.SetSession("permission", null);
            return RedirectToAction("Index", "Staff");
        }



        // GET: Change password
        public IActionResult ChangePassword()
        {


            //var customer = HttpContext.Session.GetCustomer("customer");
            SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
            ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();
            //if (customer != null && customer.Id != 0)

            if (session != null && session.StaffId != 0)
            {
                var accountId = this.StaffService.GetAccountIdByStaffId(session.StaffId);
                changePasswordViewModel.Id = accountId;//customer.Account.Id;
                return View(changePasswordViewModel);
            }
            else
            {
                return View();
            }

        }

        // POST: Change password
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {


            if (ModelState.IsValid)
            {
                changePasswordViewModel.Password = changePasswordViewModel.Password.Trim();
                changePasswordViewModel.PrePassword = changePasswordViewModel.PrePassword.Trim();
                changePasswordViewModel.RePassword = changePasswordViewModel.RePassword.Trim();

                if (changePasswordViewModel.Password != changePasswordViewModel.RePassword)
                {
                    ModelState.AddModelError("RePassword", "Mật khẩu nhập lại không chính xác!");
                    return View(changePasswordViewModel);
                }

                //var customerModel = HttpContext.Session.GetCustomer("customer");
                SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");

                //if (customerModel != null)
                if (session != null && session.StaffId != 0)
                {
                    var staff = this.StaffService.GetById(session.StaffId);
                    //if (customerModel.Account.Id == changePasswordViewModel.Id)
                    if (staff.Account.Id == changePasswordViewModel.Id)
                    {
                        var account = this.AccountService.GetById(changePasswordViewModel.Id);
                        if (account.Password == changePasswordViewModel.PrePassword)
                        {
                            account.Password = changePasswordViewModel.Password;
                            this.AccountService.Update(account);
                            TempData["ChangePassword"] = "success";
                            return RedirectToAction("StaffProfile");
                        }
                        else
                        {
                            ModelState.AddModelError("PrePassword", "Sai mật khẩu!");
                            return View(changePasswordViewModel);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("RePassword", "Thông tin bạn nhập không chính xác!");
                        return View(changePasswordViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("RePassword", "Vui lòng đăng nhập!");
                    return View(changePasswordViewModel);
                }
            }
            else
            {
                return View(changePasswordViewModel);
            }

        }

        private int GetStaffId()
        {
            SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
            return session.StaffId;
        }

        public IActionResult ListOrder()
        {


            var session = HttpContext.Session.GetSession("session");
            if (session != null)
            {
                var listOrders = this.OrderService.GetOrderForStaff();
                var listOrderedViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderedViewModel>>(listOrders);
                return View(listOrderedViewModel);
            }
            else
            {
                return View();
            }
        }

        public IActionResult OrderDetails(int orderId)
        {


            string status = this.OrderService.GetStatus(orderId);
            if (status == StaticValue.StaticValue.STATUS_HANDLING)
            {
                var order = this.OrderService.GetForOrderDetails(orderId);
                var viewModel = Mapper.Map<Order, OrderedViewModel>(order);
                return View(viewModel);
            }
            else
            {
                TempData["ListOrder"] = "ChangeStatusFailed";
                return RedirectToAction("ListOrder", "Staff");
            }

        }

        public IActionResult Deliver(int orderId)
        {
            string status = this.OrderService.GetStatus(orderId);
            if (status == StaticValue.StaticValue.STATUS_CONFIRMED)
            {

                return View(GetDeliverViewModel(orderId));
            }
            else
            {
                TempData["ListOrder"] = "DeliverFailed";
                return RedirectToAction("ListOrder", "Staff");
            }

        }

        private DeliverViewModel GetDeliverViewModel(int orderId)
        {
            DeliverViewModel viewModel = new DeliverViewModel();
            var order = this.OrderService.GetForOrderDetails(orderId);
            viewModel.Order = Mapper.Map<Order, OrderedViewModel>(order);
            viewModel.OrderId = orderId;
            var staffs = this.StaffService.GetAll();
            viewModel.Staffs = Mapper.Map<IEnumerable<Staff>, IEnumerable<StaffInDeliverViewModel>>(staffs).ToList();
            return viewModel;
        }

        [HttpPost]
        public IActionResult Deliver(DeliverViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (StaffService.CheckStaff(viewModel.StaffId) && OrderService.CheckOrder(viewModel.OrderId))
                {

                    if (OrderService.UpdateDeliver(viewModel.OrderId, viewModel.StaffId))
                    {
                        TempData["ListOrder"] = "DeliverSuccess";
                        return RedirectToAction("ListOrder", "Staff");
                    };
                    TempData["Deliver"] = "DeliverError";
                    return View(GetDeliverViewModel(viewModel.OrderId));
                }
                TempData["Deliver"] = "DeliverFailed";
                return View(GetDeliverViewModel(viewModel.OrderId));
            }
            else
            {
                return View(GetDeliverViewModel(viewModel.OrderId));
            }
        }

        public IActionResult ConfirmOrder(int orderId)
        {
            if (this.OrderService.UpdateConfirm(orderId, GetStaffId()))
            {
                TempData["ListOrder"] = "ConfirmSuccess";
                return RedirectToAction("ListOrder", "Staff");
            }
            else
            {
                TempData["OrderDetails"] = "Failed";
                return RedirectToAction("OrderDetails", "Staff", new { orderId = orderId });
            }
        }

        public IActionResult CompleteOrder(int orderId)
        {
            string status = this.OrderService.GetStatus(orderId);
            if (status == StaticValue.StaticValue.STATUS_DELIVERING)
            {
                if (this.OrderService.UpdateComplete(orderId, GetStaffId()))
                {
                    TempData["ListOrder"] = "CompleteSuccess";
                    return RedirectToAction("ListOrder", "Staff");
                }
                else
                {
                    TempData["ListOrder"] = "CompleteFailed";
                    return RedirectToAction("ListOrder", "Staff");
                }
            }
            else
            {
                TempData["ListOrder"] = "CompleteFailed";
                return RedirectToAction("ListOrder", "Staff");
            }


        }



        public IActionResult DenyOrder(int orderId)
        {
            if (this.OrderService.UpdateDeny(orderId, GetStaffId()))
            {
                TempData["ListOrder"] = "DenySuccess";
                return RedirectToAction("ListOrder", "Staff");
            }
            else
            {
                TempData["OrderDetails"] = "Failed";
                return RedirectToAction("OrderDetails", "Staff", new { orderId = orderId });
            }

        }

        public IActionResult Test()
        {

            return View("Index");
        }

        private int CheckBeforeReturnProduct(ReturnProductModel model)
        {
            try
            {
                string status = this.OrderService.GetStatus(model.OrderId);
                if (status == StaticValue.StaticValue.STATUS_COMPLETED)
                {
                    var order = this.OrderService.GetForOrderDetails(model.OrderId);
                    var returnProducts = this.ReturnProductService.GetReturnProduct(model.OrderId);
                    int flag = 0;
                    var viewModel = Mapper.Map<Order, OrderedViewModel>(order);
                    if (returnProducts != null)
                    {
                        for (int i = 0; i < returnProducts.Count(); i++)
                        {
                            var returnProduct = returnProducts.ElementAt(i);
                            for (int j = 0; j < returnProduct.ReturnProductSubProducts.Count(); j++)
                            {
                                var returnProductSubProduct = returnProduct.ReturnProductSubProducts.ElementAt(j);
                                var subProduct = viewModel.SubProductOrderedViewModels
                                    .Where(x => x.SubProductId == returnProductSubProduct.SubProductId).SingleOrDefault();
                                if (subProduct != null)
                                {
                                    viewModel.SubProductOrderedViewModels
                                    .Where(x => x.SubProductId == returnProductSubProduct.SubProductId)
                                    .SingleOrDefault().NumberSubProduct -= returnProduct.ReturnProductSubProducts.ElementAt(j).Quantity;
                                    var temp = viewModel.SubProductOrderedViewModels
                                    .Where(x => x.SubProductId == returnProductSubProduct.SubProductId)
                                    .SingleOrDefault().NumberSubProduct;

                                    if (temp <= 0)
                                    {
                                        flag++;
                                    }
                                }

                            }

                        }

                    }

                    foreach (var i in model.SubProducts)
                    {
                        var temp = viewModel.SubProductOrderedViewModels.Where(x => x.SubProductId == i.SubProductId).SingleOrDefault();
                        if (temp.NumberSubProduct - i.Quantity < 0) return 1;//out of range
                    }
                    return 0;//ok
                }
                else
                {
                    return 2;//not pay yet
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 3;//error
            }

        }

        public IActionResult ReturnProduct(int orderId)
        {


            string status = this.OrderService.GetStatus(orderId);
            if (status == StaticValue.StaticValue.STATUS_COMPLETED)
            {
                var order = this.OrderService.GetForOrderDetails(orderId);
                var returnProducts = this.ReturnProductService.GetReturnProduct(orderId);
                int flag = 0;
                var viewModel = Mapper.Map<Order, OrderedViewModel>(order);
                if (returnProducts != null)
                {
                    for (int i = 0; i < returnProducts.Count(); i++)
                    {
                        var returnProduct = returnProducts.ElementAt(i);
                        for (int j = 0; j < returnProduct.ReturnProductSubProducts.Count(); j++)
                        {
                            var returnProductSubProduct = returnProduct.ReturnProductSubProducts.ElementAt(j);
                            var subProduct = viewModel.SubProductOrderedViewModels
                                .Where(x => x.SubProductId == returnProductSubProduct.SubProductId).SingleOrDefault();
                            if (subProduct != null)
                            {
                                viewModel.SubProductOrderedViewModels
                                .Where(x => x.SubProductId == returnProductSubProduct.SubProductId)
                                .SingleOrDefault().NumberSubProduct -= returnProduct.ReturnProductSubProducts.ElementAt(j).Quantity;
                                var temp = viewModel.SubProductOrderedViewModels
                                .Where(x => x.SubProductId == returnProductSubProduct.SubProductId)
                                .SingleOrDefault().NumberSubProduct;

                                if (temp <= 0)
                                {
                                    flag++;
                                }
                            }

                        }

                    }

                }

                if (viewModel.NumberProduct == flag)
                {
                    TempData["ListOrder"] = "ReturnProductFull";
                    return RedirectToAction("ListOrder", "Staff");
                }
                else
                    return View(viewModel);
            }
            else
            {
                TempData["ListOrder"] = "ReturnProductFailed";
                return RedirectToAction("ListOrder", "Staff");
            }

        }

        [HttpPost]
        public IActionResult ReturnProduct([FromBody] ReturnProductModel model)
        {


            if (ModelState.IsValid)
            {
                int check = CheckBeforeReturnProduct(model);
                if (check == 0)
                {
                    var session = HttpContext.Session.GetStaffSession("sessionStaff");
                    ReturnProduct returnProduct = new ReturnProduct();
                    returnProduct.CreatedDate = DateTime.Now;
                    returnProduct.OrderId = model.OrderId;
                    returnProduct.StaffId = session.StaffId;
                    returnProduct.Reason = model.Reason;
                    returnProduct.ReturnProductSubProducts = new List<ReturnProductSubProduct>();
                    bool flag = true;
                    foreach (var item in model.SubProducts)
                    {
                        if (item.Quantity > 0)
                        {
                            ReturnProductSubProduct rtsp = new ReturnProductSubProduct();
                            rtsp.SubProductId = item.SubProductId;
                            rtsp.Quantity = item.Quantity;
                            returnProduct.ReturnProductSubProducts.Add(rtsp);
                            flag = false;
                        }

                    }
                    if (flag) return Json("NoProductReturn");

                    if (this.ReturnProductService.Add(returnProduct))
                        return Json("Success");
                    else
                        return Json("Failed");
                }
                else return Json("Error");
            }
            else
            {
                return Json("Error");
            }

        }

        public IActionResult AddPromotion()
        {


            AddPromotionViewModel viewModel = new AddPromotionViewModel();
            var products = this.ProductService.GetAll();
            var list = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductInPromotion>>(products);

            viewModel.Products = list.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPromotion(AddPromotionViewModel viewModel)
        {


            if (ModelState.IsValid)
            {

                try
                {
                    List<int> productIds = new List<int>();
                    foreach (var id in viewModel.ProductIds.Split
                       (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        productIds.Add(Int32.Parse(id.Trim()));
                    }
                    var promotion = Mapper.Map<AddPromotionViewModel, Promotion>(viewModel);
                    promotion.PromotionProducts = new List<PromotionProduct>();
                    foreach (var id in productIds)
                    {
                        promotion.PromotionProducts.Add(new PromotionProduct(id));
                    }
                    var promotionNow = this.PromotionService.GetNowPromotion();
                    foreach (var item in promotionNow)
                    {
                        foreach (var pdid in item.PromotionProducts.Select(x => x.ProductId))
                        {
                            if (viewModel.ProductIds.Any())
                            {
                                var productName = this.ProductService.GetProductNameWithNoTracking(pdid);
                                ModelState.AddModelError("PromotionPercent", "Sản phẩm" + productName + "đã nằm trong đợt khuyến mãi khác");
                            }
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        if (this.PromotionService.Add(promotion, GetStaffId()))
                        {
                            TempData["AddPromotion"] = "Success";
                            return RedirectToAction("AddPromotion", "Staff");
                        }
                        else
                        {
                            TempData["AddPromotion"] = "Failed";
                            viewModel.Products = GetListProductInPromotion().ToList();
                            return View(viewModel);
                        }
                    }
                    else
                    {
                        viewModel.Products = GetListProductInPromotion().ToList();
                        return View(viewModel);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    viewModel.Products = GetListProductInPromotion().ToList();
                    return View(viewModel);
                }
            }
            else
            {

                viewModel.Products = GetListProductInPromotion().ToList();
                return View(viewModel);
            }
        }

        private IEnumerable<ProductInPromotion> GetListProductInPromotion()
        {
            var products = this.ProductService.GetAll();
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductInPromotion>>(products);
        }

        private bool CheckPermission()
        {
            SessionStaffModel staff = new SessionStaffModel();
            //staff.StaffId = 1;
            //staff.StaffName = "123";
            //HttpContext.Session.SetSession("sessionStaff", staff);
            //HttpContext.Session.SetString("permission", "STAFF");


            string permission = HttpContext.Session.GetString("permission");
            if (permission == StaticValue.StaticValue.PERMISSION_STAFF)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult FilterOrder(string query)
        {
            var orders = this.OrderService.Filter(query);
            if (orders.Any())
            {
                var orderViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<OrderedViewModel>>(orders);

                return PartialView("_ListOrder", orderViewModel);
            }

            else
                return Json("");
        }

        [ValidateAdmin]
        public IActionResult Export(int orderId)
        {


            string status = this.OrderService.GetStatus(orderId);
            if (status == StaticValue.StaticValue.STATUS_DELIVERING)
            {
                var order = this.OrderService.GetForOrderDetails(orderId);
                var viewModel = Mapper.Map<Order, OrderedViewModel>(order);
                viewModel.Total = order.Total;
                return View(viewModel);
            }
            else
            {
                TempData["ListOrder"] = "ExportFailed";
                return RedirectToAction("ListOrder", "Staff");
            }
        }

        public IActionResult Statistical()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Statistical(StatisticalModel model)
        {
            var orders = OrderService
                .GetStatistical(model.StartDate, model.EndDate);

            List<SubProductOrderStatistical> list = new List<SubProductOrderStatistical>();
            foreach (var order in orders)
            {
                foreach (var orderSubProduct in order.OrderSubProducts)
                {
                    int sumTemp = 0;
                    var returnProducts = order.ReturnProducts;
                    foreach (var returnProduct in returnProducts)
                    {
                        var temp = returnProduct.ReturnProductSubProducts;
                        if (temp != null && temp.Select(x => x.SubProductId).Contains(orderSubProduct.SubProductId))
                        {
                            var i = temp.Where(x => x.SubProductId == orderSubProduct.SubProductId).SingleOrDefault();
                            sumTemp += i.Quantity;
                        }
                    }
                    var price = orderSubProduct.Order.OrderProducts
                        .Where(x => x.ProductId == orderSubProduct.SubProduct.ProductId)
                        .SingleOrDefault().Price;
                    list.Add(new SubProductOrderStatistical
                    {
                        SubProductId = orderSubProduct.SubProductId,
                        Quantity = orderSubProduct.Quantity,
                        TotalSell = price * orderSubProduct.Quantity - sumTemp * price,
                        ProductId = orderSubProduct.SubProduct.ProductId,
                        TotalPay = GoodsReceiptSubProductService
                        .GetTotalPay(order.Id,orderSubProduct.SubProductId, 
                        orderSubProduct.Quantity, orderSubProduct.Order.CreatedDate)
                    });
                }
            }

            var result = list.GroupBy(x => x.ProductId)
                .Select(x => new StatisticalTableModel
                {
                    ProductId = x.Key,
                    ProductName = ProductService.GetProductById(x.Key).ProductName,
                    TotalSell = x.Sum(y => y.TotalSell),
                    Quantity = x.Sum(y => y.Quantity),
                    TotalPay = x.Sum(y => y.TotalPay)
                });

            ViewBag.Table = result;

            return View(model);
        }

        public IActionResult ShopOrder()
        {
            ViewBag.Suppliers = Mapper.Map<IEnumerable<SupplierModel>>(SupplierService.GetAll());
            return View();
        }

        [HttpPost]
        public IActionResult ShopOrder(List<int> productIds)
        {
            var products = Mapper.Map<IEnumerable<ProductForGoodsReceiptModel>>(ProductService.GetForShopOrder(productIds.ToArray()));
            return View("ChildShopOrder", products);
        }

        //[HttpPost]
        //public IActionResult SaveShopOrder(List<ShopOrderViewModel> model)
        //{
        //    ShopOrder shopOrder = new ShopOrder();
        //    List<ShopOrderProduct> shopOrderProducts = new List<ShopOrderProduct>();
        //    List<ShopOrderSubProduct> shopOrderSubProducts = new List<ShopOrderSubProduct>();
        //    int supplierId = 0;
        //    if (model[0] != null)
        //    {
        //        supplierId = ProductService.GetProductById(model[0].Id).SupplierId;
        //    }
        //    foreach (var item in model)
        //    {
        //        if (!item.SubProducts.Any(x => x.NumberProduct != 0) || item.PriceInput <= 0) continue;
        //        var shopOrderProduct = new ShopOrderProduct { ProductId = item.Id, PriceInput = item.PriceInput };
        //        foreach (var subItem in item.SubProducts)
        //        {
        //            if (subItem.NumberProduct == 0) continue;
        //            shopOrderSubProducts.Add(new ShopOrderSubProduct
        //            {
        //                Quantity = subItem.NumberProduct,
        //                SubProductId = subItem.Id
        //            });
        //        }
        //        shopOrderProducts.Add(shopOrderProduct);
        //    }
        //    shopOrder.ShopOrderSubProducts = shopOrderSubProducts;
        //    shopOrder.ShopOrderProducts = shopOrderProducts;
        //    shopOrder.SupplierId = supplierId;
        //    if (ShopOrderService.Save(shopOrder))
        //    {
        //        ViewBag.ShopOrderSuccess = true;
        //    }
        //    ViewBag.Suppliers = Mapper.Map<IEnumerable<SupplierModel>>(SupplierService.GetAll());
        //    return View("ShopOrder");
        //}


        [HttpPost]
        public IActionResult GetProductBySupplierId(int supplierId)
        {
            var products = Mapper.Map<IEnumerable<BasicProductModel>>(ProductService.GetAllProductsBySupplierId(supplierId));
            return Json(products);
        }


    }

}
//foreach (var file in files)
//{
//    var filename = ContentDispositionHeaderValue
//                    .Parse(file.ContentDisposition)
//                    .FileName
//                    .Trim('"');
//    filename = _hostingEnvironment.WebRootPath + $@"\{filename}";
//    size += file.Length;
//    using (FileStream fs = System.IO.File.Create(filename))
//    {
//        file.CopyTo(fs);
//        fs.Flush();
//    }
//}

//ViewBag.Message = $"{files.Count} file(s) / { size} bytes uploaded successfully!";


//[HttpPost]
//public IActionResult UploadFilesAjax()
//{
//    long size = 0;
//    var files = Request.Form.Files;
//    foreach (var file in files)
//    {
//        var filename = ContentDispositionHeaderValue
//                        .Parse(file.ContentDisposition)
//                        .FileName
//                        .Trim('"');
//        filename = _hostingEnvironment.WebRootPath + $@"\{filename}";
//        size += file.Length;
//        using (FileStream fs = System.IO.File.Create(filename))
//        {
//            file.CopyTo(fs);
//            fs.Flush();
//        }
//    }
//    string message = $"{files.Count} file(s) / { size} bytes uploaded successfully!";
//    return Json(message);
//}
