using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class AccountModel : BaseModel
    {
        [StringLength(StaticValue.StaticValue.MAX_USERNAME_LENGTH, 
            MinimumLength = StaticValue.StaticValue.MIN_USERNAME_LENGTH , 
            ErrorMessage = StaticValue.StaticValue.REQUIRE_USERNAME_LENGTH)]
        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME)]
        public string UserName { set; get; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD)]
        [StringLength(StaticValue.StaticValue.MAX_PASSWORD_LENGTH,
            MinimumLength = StaticValue.StaticValue.MIN_PASSWORD_LENGTH,
            ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD_LENGTH)]
        public string Password { get; set; }
    }
}
