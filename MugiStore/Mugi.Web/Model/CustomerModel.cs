using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public enum GenderType
    {
        Nam,
        Nữ,
        Khác
    }
    public class CustomerModel : BaseModel
    {
        public CustomerModel()
        {
            this.Account = new AccountModel();
        }

        [Required]
        public AccountModel Account { get; set; }

        [Required]
        public string Name { get; set; }

      
        public string Address { get; set; }

        [Required]
        public string Mail { get; set; }

        
        public string Phone { get; set; }

        [Required]
        public GenderType Gender { get; set; }
    }
}
