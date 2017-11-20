using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class PropertyDetailsModel : BaseModel
    {
        public PropertyModel Property { get; set; }

        public string PropertyValue { get; set; }

    }
}
