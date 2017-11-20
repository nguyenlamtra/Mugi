using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mugi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public virtual Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public string PaymentType { get; set; }

        public int Total { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Status { get; set; }

        public DateTime? ConfirmDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? DeliverId { get; set; }

        public int? CompleteId { get; set; }

        public int? ConfirmId { get; set; }

        public virtual Staff Deliver { get; set; }

        public virtual Staff Complete { get; set; }
        
        public virtual Staff Confirm { get; set; }

        public virtual ICollection<ReturnProduct> ReturnProducts { get; set; }

        public virtual ICollection<OrderSubProduct> OrderSubProducts { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
