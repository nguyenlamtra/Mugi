using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class AddPropertyDetailsViewModel
    {
        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME)]
        [StringLength(StaticValue.StaticValue.NAME_LENGTH, ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME)]
        public string PropertyValue { get; set; }

       
        public List<BasicProperty> Properties { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NOT_NULL)]
        public int PropertyId { get; set; }
    }
}
