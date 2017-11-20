using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mugi.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        //public int PayNumber { get; set; }              // Buy many get 1 free

        public int PromotionPercent { get; set; }

        public DateTime BeginDay { get; set; }

        public DateTime EndDay { get; set; }

        public DateTime CreatedDate { get; set; }

        public Staff Staff { get; set; }

        public int StaffId { get; set; }

        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
    }
}
