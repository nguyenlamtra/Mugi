using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class ReturnProduct : BaseEntity
    {
        public virtual Order Order { get; set; }

        public int OrderId { get; set; } 

        public virtual Staff Staff { get; set; }

        public int? StaffId { get; set; }

        //public int Total { get; set; }

        public string Reason { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ReturnProductSubProduct> ReturnProductSubProducts { get; set; }
    }
}
