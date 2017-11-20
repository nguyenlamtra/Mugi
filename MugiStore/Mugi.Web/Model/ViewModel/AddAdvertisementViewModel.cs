using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddAdvertisementViewModel
    {
        public int StaffId { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_STARTDAY)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_ENDDAY)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NOT_NULL)]
        public string Description { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_IMAGE)]
        public IFormFile Image { get; set; }
    }
}
