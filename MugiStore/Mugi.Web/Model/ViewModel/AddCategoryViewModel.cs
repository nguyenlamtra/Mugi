using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddCategoryViewModel : BaseModel
    {
        [Required(ErrorMessage = "Tên không được phép trống!")]
        [StringLength(StaticValue.StaticValue.NAME_LENGTH, ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME_LENGTH)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Mô tả không được phép trống!")]
        public string CategoryDescription { get; set; }

        public List<BasicProperty> Categories { get; set; }
    }

}
