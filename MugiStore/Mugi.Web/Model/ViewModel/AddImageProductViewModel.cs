using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddImageProductViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public List<BasicProperty> ImageProducts { get; set; }

        public IFormFile Image { get; set; }
    }

}
