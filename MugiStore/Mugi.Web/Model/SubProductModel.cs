using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class SubProductModel : BaseModel
    {
        public int ProductId { get; set; }

        public int ProductLeft { get; set; }

        public IList<PropertyDetailsModel> PropertyDetails { get; set; }

    }
}
