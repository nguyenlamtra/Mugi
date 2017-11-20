using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mugi.Web.StaticValue;

namespace Mugi.Web.Model.ViewModel
{
    public class InsertProductViewModel
    { 
        public InsertProductViewModel()
        {

        }

        public InsertProductViewModel(
            IEnumerable<PropertyInInserProduct> subCategories,
            IEnumerable<PropertyInInserProduct> properties,
            IEnumerable<PropertyInInserProduct> suppliers)
        {
            this.SubCategories = subCategories;
            this.Properties = properties;
            this.Suppliers = suppliers;
        }

        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_PRODUCTNAME)]
        [StringLength(20, ErrorMessage = StaticValue.StaticValue.REQUIRE_NAME_LENGTH)]
        public string ProductName { get; set; }
        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_DESCRIPTION)]
        public string Description { get; set; }
        //[Required]
        //public int Price { get; set; }
        [Required (ErrorMessage = StaticValue.StaticValue.REQUIRE_SUBCATEGORY)]
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_SUPPLIER)]
        public int SupplierId { get; set; }
        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_PROPERTY)]
        public int[] PropertyIds { get; set; }
        [Required(ErrorMessage = StaticValue.StaticValue.REQUIRE_IMAGE)]
        public IFormFile Image { get; set; }

        public IEnumerable<PropertyInInserProduct> SubCategories { get; set; }

        public IEnumerable<PropertyInInserProduct> Properties { get; set; }

        public IEnumerable<PropertyInInserProduct> Suppliers { get; set; }
    }

    public class PropertyInInserProduct : BaseModel
    {
        public string Name { get; set; }
    }
}
