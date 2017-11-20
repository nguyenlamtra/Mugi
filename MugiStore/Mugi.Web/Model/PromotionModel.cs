using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class PromotionModel
    {
        public int ProductModelId { get; set; }

        public int PayNumber { get; set; }              // Buy many get 1 free

        public int PromotionPercent { get; set; }

    }
}
