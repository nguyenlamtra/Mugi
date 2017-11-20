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
    public class AdvertisementViewComponent : ViewComponent
    {
        private readonly IMapper Mapper;
        private ICustomerService CustomerService;
        private IAdvertisementService AdvertisementService;
        public AdvertisementViewComponent(ICustomerService customerService,
            IAdvertisementService advertisementService,
            IMapper mapper)
        {

            this.Mapper = mapper;
            this.CustomerService = customerService;
            this.AdvertisementService = advertisementService;
        }

        public IViewComponentResult Invoke()
        {
            var advertisements = AdvertisementService.GetAdvertisements();
            var advertisementModels = Mapper.Map<IEnumerable<Advertisement>,
                IEnumerable<AdvertisementModel>>(advertisements);
            return View("Advertisement",advertisementModels);
        }
       
    }

}