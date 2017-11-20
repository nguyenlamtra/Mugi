using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Model
{
    public class InsertProductModel
    {
        public string ProductName { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int Price { get; set; }

        public int SubCategoryId { get; set; }

        public int SupplierId { get; set; }

        public int[] PropertyIds { get; set; }
    }
}
