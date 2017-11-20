using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model.ViewModel
{
    public class RegisterStaffViewModel : BaseModel
    {
        [Required]
        public AccountModel Account { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên!")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email để nhận thông báo từ chúng tôi!")]
        [EmailAddress(ErrorMessage = "Sai định dạng email!")]
        public string Mail { get; set; }


        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu!")]
        public string RePassword { get; set; }
    }
}
