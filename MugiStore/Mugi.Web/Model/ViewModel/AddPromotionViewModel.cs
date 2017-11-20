using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddPromotionViewModel
    {
        [Range(0, 100, ErrorMessage = StaticValue.StaticValue.REQUIRE_PROMOTION_PERCENT)]
        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_PROMOTION)]
        public int PromotionPercent { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_STARTDAY)]
        public DateTime BeginDay { get; set; }

        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_ENDDAY)]
        public DateTime EndDay { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_ENDDAY)]
        public string ProductIds { get; set; }

       
        public List<ProductInPromotion> Products { get; set; }
    }

}
