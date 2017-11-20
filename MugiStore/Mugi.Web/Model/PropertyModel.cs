using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class PropertyModel : BaseModel
    {
        public PropertyModel()
        {
            PropertyDetailsOfSubProducts = new List<PropertyDetailsModel>();
        }

        public string PropertyName { get; set; }

        public IList<PropertyDetailsModel> PropertyDetailsOfSubProducts { get; set; }
    }
}
