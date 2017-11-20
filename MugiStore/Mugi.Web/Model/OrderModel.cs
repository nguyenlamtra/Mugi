using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public enum PaymentType
    {
        PayPal,
        ThanhToanKhiGiaoHang
    }
    public class OrderModel 
    {
        public PaymentType PaymentType { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
