using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class RegisterCustomerViewModel:BaseModel
    {
        [Required]
        public AccountModel Account { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_EMAIL)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = StaticValue.StaticValue.REQUIRE_EMAIL_FORMAT)]
        public string Mail { get; set; }


        public string Phone { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_GENDER)]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD)]
        [StringLength(StaticValue.StaticValue.MAX_PASSWORD_LENGTH,
             MinimumLength = StaticValue.StaticValue.MIN_PASSWORD_LENGTH,
             ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD_LENGTH)]
        public string RePassword { get; set; }
    }
}
