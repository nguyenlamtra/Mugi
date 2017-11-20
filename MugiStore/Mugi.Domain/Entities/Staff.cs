using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class Staff : BaseEntity
    {
        public virtual Account Account { get; set; }

        public int AccountId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public virtual ICollection<Advertisement> Advertisements { get; set; }

        public virtual ICollection<ReturnProduct> ReturnProducts { get; set; }

        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }

        public virtual ICollection<Order> DeliverOrders { get; set; }

        public virtual ICollection<Order> ConfirmOrders { get; set; }

        public virtual ICollection<Order> CompleteOrders { get; set; }
    }
}
