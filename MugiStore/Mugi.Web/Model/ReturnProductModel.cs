using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class ReturnProductModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public List<SubProductReturnModel> SubProducts { get; set; }
        [Required]
        public string Reason { get; set; }
    }
    public class SubProductReturnModel
    {
        [Required]
        public int SubProductId { get; set; }
        
        public int Quantity { get; set; }
    }
}
