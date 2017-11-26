using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mugi.Service.Services;

namespace Mugi.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
