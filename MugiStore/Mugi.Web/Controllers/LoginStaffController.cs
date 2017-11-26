using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugi.Web.Model;
using Mugi.Web.Extensions;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Mugi.Web.Model.ViewModel;
using Mugi.Service.Services;
using Mugi.Domain.Entities;

namespace Mugi.Web.Controllers
{
    public class LoginStaffController : Controller
    {

        private IAccountService AccountService;
        private IStaffServie StaffService;

        public LoginStaffController(IAccountService accountService, IStaffServie staffService)
        {
            AccountService = accountService;
            StaffService = staffService;
        }


        // GET: Login
        public IActionResult LoginStaff()
        {
            return View();
        }


        // POST: Login
        [HttpPost]
        public IActionResult LoginStaff(LoginCustomerViewModel loginCustomerViewModel)
        {
            if (ModelState.IsValid)
            {
                loginCustomerViewModel.UserName = loginCustomerViewModel.UserName.Trim();
                loginCustomerViewModel.Password = loginCustomerViewModel.Password.Trim();

                var account = Mapper.Map<LoginCustomerViewModel, Account>(loginCustomerViewModel);
                if (this.AccountService.Verify(account))
                {
                    var staff = this.StaffService.GetByUserName(account.UserName);
                    if (staff != null)
                    {
                        SessionStaffModel session = HttpContext.Session.GetStaffSession("sessionStaff");
                        if (session == null)
                        {
                            session = new SessionStaffModel();

                        }
                        session.StaffName = staff.Name;
                        session.StaffId = staff.Id;
                        //HttpContext.Session.SetSession("session", null);
                        HttpContext.Session.SetSession("sessionStaff", session);
                        HttpContext.Session.SetString("permission", staff.Account.Role.RoleName);
                        return RedirectToAction("Index", "Staff");
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
    }
}