using Microsoft.AspNetCore.Mvc;
using Mugi.Service.Services;
using Mugi.Web.Model;
using Mugi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Mugi.Web.Extensions;
using Mugi.Web.Model.ViewModel;
using System.Collections.Generic;

namespace Mugi.Web.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly IMapper Mapper;
        private ICustomerService CustomerService;
        private IAdvertisementService AdvertisementService;
        private IAccountService AccountService;
        public CustomerController(ICustomerService customerService,
            IAdvertisementService advertisementService,
            IAccountService accountService,
        IMapper mapper)
        {
            this.Mapper = mapper;
            this.CustomerService = customerService;
            this.AdvertisementService = advertisementService;
            this.AccountService = accountService;
        }

        // GET: Register
        public IActionResult RegisterCustomer()
        {
            return View();
        }


        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCustomer
            (RegisterCustomerViewModel registerCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                registerCustomerViewModel.Account.UserName = registerCustomerViewModel.Account.UserName.Trim();
                registerCustomerViewModel.Account.Password = registerCustomerViewModel.Account.Password.Trim();
                registerCustomerViewModel.Mail = registerCustomerViewModel.Mail.Trim();
                registerCustomerViewModel.Name = registerCustomerViewModel.Name.Trim();
                registerCustomerViewModel.RePassword = registerCustomerViewModel.RePassword.Trim();
                if (registerCustomerViewModel.RePassword == registerCustomerViewModel.Account.Password)
                {

                    Customer customer = Mapper.Map<RegisterCustomerViewModel, Customer>(registerCustomerViewModel);
                    int check = this.CustomerService.GetCustomerIdByEmail(customer.Mail);
                    if (check == 0)
                    {
                        if (CustomerService.InsertCustomer(customer, StaticValue.StaticValue.PERMISSION_STAFF))
                        {
                            //var customerModel = Mapper.Map<Customer, CustomerModel>(customer);
                            SessionModel session = new SessionModel();
                            session.CustomerId = this.CustomerService.GetCustomerIdByEmail(customer.Mail);
                            session.CustomerName = customer.Name;
                            HttpContext.Session.SetSession("session", session);
                            HttpContext.Session.SetSession("permission", StaticValue.StaticValue.PERMISSION_STAFF);
                            return RedirectToAction("HomePage", "Product");
                        }
                        else
                        {
                            ModelState.AddModelError("Account.UserName", "Tài khoản trùng");
                            return View(registerCustomerViewModel);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Mail", "Mail đã tồn tại!");
                        return View(registerCustomerViewModel);
                    }

                }
                else
                {
                    ModelState.AddModelError("RePassword", "Mật khẩu nhập lại không đúng!");
                    return View(registerCustomerViewModel);
                }
            }
            else
            {
                return View(registerCustomerViewModel);
            }
        }


        // GET: Login
        public IActionResult LoginCustomer()
        {
            return View();
        }


        // POST: Login
        [HttpPost]
        public IActionResult LoginCustomer(LoginCustomerViewModel loginCustomerViewModel)
        {

            if (ModelState.IsValid)
            {
                loginCustomerViewModel.UserName = loginCustomerViewModel.UserName.Trim();
                loginCustomerViewModel.Password = loginCustomerViewModel.Password.Trim();
                var account = Mapper.Map<LoginCustomerViewModel, Account>(loginCustomerViewModel);
                if (this.AccountService.Verify(account))
                {
                    var customer = this.CustomerService.GetByUserName(account.UserName);
                    if (customer != null && customer.Account.Role.RoleName == StaticValue.StaticValue.PERMISSION_CUSTOMER)
                    {
                        SessionModel session = HttpContext.Session.GetSession("session");
                        List<ProductInSessionModel> products = session.Products ?? new List<ProductInSessionModel>();
                        HttpContext.Session.Clear();

                        //if (session != null)
                        //{
                        //    session.CustomerName = customer.Name;
                        //    session.CustomerId = customer.Id;
                        //}
                        //else
                        //{
                        //    session = new SessionModel();
                        //}
                        //HttpContext.Session.SetSession("sessionStaff", null);
                        HttpContext.Session.SetSession("session", new SessionModel
                        {
                            Products = products,
                            CustomerId = customer.Id,
                            CustomerName = customer.Name
                        });
                        HttpContext.Session.SetString("permission", customer.Account.Role.RoleName);
                        return RedirectToAction("HomePage", "Product");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Tên tài khoản hoặc mật khẩu không đúng!");
                        return View(loginCustomerViewModel);
                    }


                }
                else
                {
                    ModelState.AddModelError("Password", "Tên tài khoản hoặc mật khẩu không đúng!");
                    return View(loginCustomerViewModel);
                }
            }
            else
            {
                return View(loginCustomerViewModel);
            }
        }

        //POST: UpdateProfile
        [HttpPost]
        public IActionResult CustomerProfile(CustomerProfileViewModel customerProfileViewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = Mapper.Map<CustomerProfileViewModel, Customer>(customerProfileViewModel);
                if (this.CustomerService.Update(customer))
                {
                    SessionModel session = HttpContext.Session.GetSession("session");
                    session.CustomerName = customer.Name;
                    HttpContext.Session.SetSession("session", session);
                    return View(customerProfileViewModel);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(customerProfileViewModel);
            }
        }

        // GET: 
        public IActionResult CustomerProfile()
        {
            //CustomerModel customer = HttpContext.Session.GetCustomer("customer");
            SessionModel session = HttpContext.Session.GetSession("session");
            //if (customer.Name != null)
            if (session != null)
            {
                //var temp = this.CustomerService.GetById(customer.Id);
                var temp = this.CustomerService.GetById(session.CustomerId);
                var customerProfileViewModel = Mapper.Map<Customer, CustomerProfileViewModel>(temp);
                return View(customerProfileViewModel);
            }
            else
                return View();
        }

        // GET: Logout
        public IActionResult LogoutCustomer()
        {
            HttpContext.Session.Clear();
            //HttpContext.Session.SetSession("session", null);
            //HttpContext.Session.SetSession("permission", null);
            return RedirectToAction("HomePage", "Product");
        }

        // GET: Change password
        public IActionResult ChangePassword()
        {
            //var customer = HttpContext.Session.GetCustomer("customer");
            SessionModel session = HttpContext.Session.GetSession("session");
            ChangePasswordViewModel changePasswordViewModel = new ChangePasswordViewModel();
            //if (customer != null && customer.Id != 0)

            if (session != null && session.CustomerId != 0)
            {
                var accountId = this.CustomerService.GetAccountIdByCustomerId(session.CustomerId);
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

                if (changePasswordViewModel.Password != changePasswordViewModel.RePassword)
                {
                    ModelState.AddModelError("RePassword", "Mật khẩu nhập lại không chính xác!");
                    return View(changePasswordViewModel);
                }
                //var customerModel = HttpContext.Session.GetCustomer("customer");
                SessionModel session = HttpContext.Session.GetSession("session");


                //if (customerModel != null)
                if (session != null && session.CustomerId != 0)
                {
                    var customer = this.CustomerService.GetById(session.CustomerId);
                    //if (customerModel.Account.Id == changePasswordViewModel.Id)
                    if (customer.Account.Id == changePasswordViewModel.Id)
                    {
                        var account = this.AccountService.GetById(changePasswordViewModel.Id);
                        if (account.Password == changePasswordViewModel.PrePassword)
                        {
                            account.Password = changePasswordViewModel.Password;
                            this.AccountService.Update(account);
                            TempData["ChangePassword"] = "success";
                            return RedirectToAction("CustomerProfile");
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

    }
}
