using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Mugi.Web.StaticValue;

namespace Mugi.Web.Model.ViewModel
{
    public class StaffProfileViewModel:BaseModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_EMAIL)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = StaticValue.StaticValue.REQUIRE_EMAIL_FORMAT)]
        public string Mail { get; set; }

        [StringLength (StaticValue.StaticValue.MAX_PHONE_LENGTH,
            MinimumLength = StaticValue.StaticValue.MIN_PHONE_LENGTH,
            ErrorMessage =StaticValue.StaticValue.REQUIRE_PHONE)]
        public string Phone { get; set; }

        //[Required]
        //public GenderType Gender { get; set; }
    }
}
