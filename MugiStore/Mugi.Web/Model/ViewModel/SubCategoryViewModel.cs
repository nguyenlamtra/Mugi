using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class SubCategoryViewModel : BaseModel
    {
        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NOT_NULL)]
        [StringLength(StaticValue.StaticValue.NAME_LENGTH, ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME_LENGTH)]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NOT_NULL)]
        [StringLength(StaticValue.StaticValue.DESCRIPTION_LENGTH, ErrorMessage = StaticValue.StaticValue.REQUIRE_DESCRIPTION_LENGTH)]
        public string SubCategoryDescription { get; set; }


        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NOT_NULL)]
        public int CategoryId { get; set; }
    }
}
