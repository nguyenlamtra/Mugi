using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class AddProductModel
    {
        public int ProductId { get; set; }
        public int[] PropertyDetailIds { get; set; }
    }
}
