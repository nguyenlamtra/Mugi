using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class StatisticalTableModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSell { get; set; }
        public decimal TotalPay { get; set; }
    }

    //public class XXX
    //{
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public int Quantity { get; set; }
    //    public decimal TotalSell { get; set; }
    //    public decimal TotalPay { get; set; }
    //}

    public class SubProductOrderStatistical
    {
        public int SubProductId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalSell { get; set; }
        public decimal TotalPay { get; set; }
    }

    public class SubProductGoodsReceiptStatistical
    {
        public int SubProductId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPay { get; set; }
    }
}
