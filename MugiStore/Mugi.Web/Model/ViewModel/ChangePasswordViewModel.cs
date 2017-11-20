using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD)]
        [StringLength (StaticValue.StaticValue.MAX_PASSWORD_LENGTH, 
            MinimumLength = StaticValue.StaticValue.MIN_PASSWORD_LENGTH,
            ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD_LENGTH)]
        public string PrePassword { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD)]
        [StringLength(StaticValue.StaticValue.MAX_PASSWORD_LENGTH, 
            MinimumLength = StaticValue.StaticValue.MIN_PASSWORD_LENGTH,
            ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD_LENGTH)]
        public string Password { get; set; }

        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD)]
        [StringLength(StaticValue.StaticValue.MAX_PASSWORD_LENGTH, 
            MinimumLength = StaticValue.StaticValue.MIN_PASSWORD_LENGTH,
            ErrorMessage = StaticValue.StaticValue.REQUIRE_PASSWORD_LENGTH)]
        public string RePassword { get; set; }
    }
}
