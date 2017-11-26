using AutoMapper;
using Mugi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mugi.Web.StaticValue;
using Mugi.Web.Model;
using Mugi.Web.Model.ViewModel;

namespace Mugi.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<SubCategory, SubCategoryModel>();

            CreateMap<Category, CategoryModel>()
               .ForMember(cm => cm.SubCategoryModels, map => map.MapFrom(c => c.SubCategories));

            CreateMap<SubProduct, SubProductModel>()
               .ForMember(sm => sm.PropertyDetails, map => map.MapFrom(s => s.PropertyDetailsSubProducts.Select(y => y.PropertyDetails)))
               .ForMember(sm => sm.ProductId, map => map.MapFrom(s => s.Product.Id));

            CreateMap<Product, ProductModel>()
           .ForMember(pm => pm.PriceDetails, map => map.MapFrom(p => p.PriceDetails
           .OrderByDescending(x => x.CreatedDate).FirstOrDefault()))
           .ForMember(pm => pm.Promotion, map => map.MapFrom(p => p.PromotionProducts
           .Where(z => z.Promotion.BeginDay <= DateTime.Now && z.Promotion.EndDay >= DateTime.Now)
           .Select(x => x.Promotion).FirstOrDefault()))
           .ForMember(pm => pm.ProductLeft, map => map.MapFrom(p => p.SubProducts.Sum(y => y.ProductLeft)));

            CreateMap<Property, PropertyModel>();
            CreateMap<Supplier, SupplierModel>();
            CreateMap<PriceDetails, PriceDetailsModel>();
            CreateMap<PropertyDetails, PropertyDetailsModel>();

            CreateMap<ImageProduct, ImageProductModel>()
                .ForMember(im => im.Url, map => map.MapFrom(i => i.Url == null ? StaticValue.StaticValue.SRC_NULL_IMAGE : StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + i.Url));

            CreateMap<Promotion, PromotionModel>();

            CreateMap<Advertisement, AdvertisementModel>()
                 .ForMember(am => am.Url, map => map.MapFrom(a => a.Url == null ? StaticValue.StaticValue.SRC_NULL_IMAGE : StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + a.Url));

            CreateMap<SubProduct, ShopCartViewModel>()
               .ForMember(sm => sm.SubProductId, map => map.MapFrom(s => s.Id))
               .ForMember(sm => sm.PropertyDetails, map => map.MapFrom(s => s.PropertyDetailsSubProducts.Select(x => x.PropertyDetails)))
               .ForMember(sm => sm.Price, map => map.MapFrom(s => s.Product.PriceDetails
               .OrderByDescending(x => x.CreatedDate).Select(x => x.Price).FirstOrDefault()))
               .ForMember(sm => sm.ProductId, map => map.MapFrom(s => s.Product.Id))
               .ForMember(sm => sm.PromotionPercent,
                map => map.MapFrom(s => s.Product.PromotionProducts.Where(z => z.Promotion.BeginDay <= DateTime.Now && z.Promotion.EndDay >= DateTime.Now)
                .Select(x => x.Promotion.PromotionPercent).FirstOrDefault()))
               .ForMember(sm => sm.ProductLeft, map => map.MapFrom(s => s.ProductLeft))
               .ForMember(sm => sm.ProductName, map => map.MapFrom(s => s.Product.ProductName))
               .ForMember(sm => sm.ImageUrl, map => map.MapFrom(s => s.Product.ImageProducts.Select(x => x.Url)
               .FirstOrDefault() == null ? StaticValue.StaticValue.SRC_NULL_IMAGE : StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + s.Product
                .ImageProducts.Select(x => x.Url).FirstOrDefault()));

            CreateMap<Account, AccountModel>();

            CreateMap<Customer, CustomerModel>();
            CreateMap<Customer, CustomerProfileViewModel>();
            CreateMap<Staff, StaffProfileViewModel>()
               .ForMember(x => x.AccountId, map => map.MapFrom(x => x.Account.Id));


            CreateMap<OrderSubProduct, OrderDetailsViewModel>()
                .ForMember(x => x.ImageUrl, map => map
                   .MapFrom(s => s.SubProduct.Product
                  .ImageProducts.Select(x => x.Url).FirstOrDefault() == null ? StaticValue.StaticValue.SRC_NULL_IMAGE :
                  StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + s.SubProduct.Product
                  .ImageProducts.Select(x => x.Url).FirstOrDefault()))
               //.ForMember(x => x.Price, map => map.MapFrom(x => x.Price))
               .ForMember(x => x.ProductName, map => map.MapFrom(x => x.SubProduct.Product.ProductName))
               .ForMember(x => x.ProductOrder, map => map.MapFrom(x => x.Quantity))
               .ForMember(x => x.PropertyDetails, map => map
               .MapFrom(s => s.SubProduct.PropertyDetailsSubProducts.Select(x => x.PropertyDetails)));


            // View Ordered 
            CreateMap<PropertyDetails, PropertyDetailsOfOrderd>()
                .ForMember(x => x.PropertyName, map => map.MapFrom(x => x.Property.PropertyName))
                .ForMember(x => x.PropertyValue,
                map => map.MapFrom(x => x.PropertyValue));

            CreateMap<OrderSubProduct, SubProductOrderedViewModel>()
                .ForMember(x => x.ProductId, map => map.MapFrom(x => x.SubProduct.Product.Id))
                .ForMember(x => x.NumberSubProduct, map => map.MapFrom(x => x.Quantity))
                .ForMember(x => x.PropertyDetails, map =>
                map.MapFrom(x => x.SubProduct.PropertyDetailsSubProducts.Select(y => y.PropertyDetails)))
                .ForMember(x => x.SubProductId, map => map.MapFrom(x => x.SubProductId))
                .ForMember(x => x.OrderedViewModel, map => map.MapFrom(x => x.Order));

            CreateMap<OrderProduct, ProductOrderedViewModel>()
                .ForMember(x => x.ProductId, map => map.MapFrom(x => x.ProductId))
                .ForMember(x => x.Price, map => map.MapFrom(x => x.Price))
                .ForMember(x => x.ProductName, map => map.MapFrom(x => x.Product.ProductName));

            CreateMap<Order, OrderedViewModel>()
                .ForMember(x => x.OrderId, map => map.MapFrom(x => x.Id))
                .ForMember(x => x.CreatedDate, map => map.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.NumberProduct, map => map.MapFrom(x => x.OrderSubProducts.Count()))
                .ForMember(x => x.Status, map => map.MapFrom(x => x.Status))
                .ForMember(x => x.SubProductOrderedViewModels, map => map.MapFrom(x => x.OrderSubProducts))
                 .ForMember(x => x.ProductOrderedViewModels, map => map.MapFrom(x => x.OrderProducts))
                 .ForMember(x => x.CustomerName, map => map.MapFrom(x => x.Customer.Name));

            // View Add Product
            CreateMap<Supplier, PropertyInInserProduct>()
                  .ForMember(x => x.Name, map => map.MapFrom(x => x.SupplierName));


            CreateMap<Property, PropertyInInserProduct>()
                  .ForMember(x => x.Name, map => map.MapFrom(x => x.PropertyName));

            CreateMap<SubCategory, PropertyInInserProduct>()
                  .ForMember(x => x.Name, map => map.MapFrom(x => x.SubCategoryName));

            // View ListProduct
            CreateMap<Product, ListProductViewModel>()
                 .ForMember(x => x.SupplierName, map => map.MapFrom(x => x.Supplier.SupplierName))
                 .ForMember(x => x.ProductLeft, map => map.MapFrom(x => x.SubProducts.Sum(y => y.ProductLeft)))
                 .ForMember(x => x.Price, map => map.MapFrom(x => x.PriceDetails
                 .OrderByDescending(z => z.CreatedDate).Select(y => y.Price).FirstOrDefault()));


            // View Add Product
            CreateMap<PropertyDetails, PropertyInInserProduct>()
                .ForMember(x => x.Name, map => map.MapFrom(x => x.PropertyValue));

            CreateMap<Property, PropertyInAddSubProduct>();

            CreateMap<Product, AddSubProductViewModel>()
            .ForMember(x => x.Image, map => map.MapFrom(x => x.ImageProducts.Select(y => y.Url).FirstOrDefault() == null ?
            StaticValue.StaticValue.SRC_NULL_IMAGE
            : StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + x.ImageProducts.Select(y => y.Url).FirstOrDefault()))
             .ForMember(x => x.ProductId, map => map.MapFrom(x => x.Id))
            .ForMember(x => x.Properties, map => map.MapFrom(x => x.PropertyProducts.Select(y => y.Property)));

            // View UpdateProduct
            CreateMap<Supplier, BasicProperty>()
              .ForMember(x => x.Name, map => map.MapFrom(x => x.SupplierName));
            CreateMap<SubCategory, BasicProperty>()
             .ForMember(x => x.Name, map => map.MapFrom(x => x.SubCategoryName));
            CreateMap<Product, UpdateProductViewModel>()
             .ForMember(x => x.Price, map => map.MapFrom(y => y
             .PriceDetails.OrderByDescending(x => x.CreatedDate).Select(x => x.Price).FirstOrDefault()));

            // Add Image Product
            CreateMap<Product, AddImageProductViewModel>()
              .ForMember(x => x.ImageProducts, map => map.MapFrom(x => x.ImageProducts));

            CreateMap<ImageProduct, BasicProperty>()
            .ForMember(x => x.Name, map => map.MapFrom(x => x.Url == null ? StaticValue.StaticValue.SRC_NULL_IMAGE
            : StaticValue.StaticValue.PREFIX_IMAGE_LINK_URL + x.Url));

            CreateMap<Category, BasicProperty>()
              .ForMember(x => x.Name, map => map.MapFrom(x => x.CategoryName));

            // Add PropertyDetails
            CreateMap<Property, BasicProperty>()
             .ForMember(x => x.Name, map => map.MapFrom(x => x.PropertyName));

            // Add advertisement
            CreateMap<Advertisement, AddAdvertisementViewModel>();

            // Search
            CreateMap<Product, SearchModel>()
                .ForMember(x => x.Url, map => map.MapFrom(x => StaticValue.StaticValue.URL_SEARCH + x.Id));

            CreateMap<Product, SearchHomePageModel>()
                .ForMember(x => x.Url, map => map.MapFrom(x => StaticValue.StaticValue.URL_SEARCH_HOME_PAGE + x.Id));

            // Search
            CreateMap<Product, BasicProperty>()
                .ForMember(x => x.Name, map => map.MapFrom(x => x.ProductName));

            //GoodsReceipt
            CreateMap<Product, ProductForGoodsReceiptModel>()
                .ForMember(x => x.Properties, map => map.MapFrom(x => x.PropertyProducts.Select(y => y.Property)));

            CreateMap<SubProduct, SubProductForGoodsReceiptModel>()
                .ForMember(x => x.PropertyDetails,
                map => map.MapFrom(x => x.PropertyDetailsSubProducts.Select(y => y.PropertyDetails)));

            CreateMap<PropertyDetails, PropertyDetailForGoodsReceiptModel>();

            CreateMap<Property, PropertyForGoodsReceiptModel>();

            CreateMap<Product, SearchGoodsReceiptModel>();



            CreateMap<Product, ProductInPromotion>()
                .ForMember(x => x.Price, map => map.MapFrom(x => x.PriceDetails
                     .OrderByDescending(z => z.CreatedDate).Select(y => y.Price).FirstOrDefault()));

            CreateMap<Staff, StaffInDeliverViewModel>();


            CreateMap<SubCategory, SubCategoryInAddSubCategoryView>();

            CreateMap<Product, BasicProductModel>();

            ////CreateMap<SubProduct, ShopOrderViewModel>()
            ////    .ForMember(x => x.SubProductId, map => map.MapFrom(x => x.Id))
            ////    .ForMember(x => x.PropertyValues, map => map.MapFrom(x => x.PropertyDetailsSubProducts))
            ////    .ForMember(x => x.ProductName, map => map.MapFrom(x => x.Product.ProductName));

            ////CreateMap<PropertyDetailsSubProduct, PropertyShopOrderViewModel>()
            ////    .ForMember(x => x.PropertyName, map => map.MapFrom(x => x.PropertyDetails.Property.PropertyName))
            ////    .ForMember(x => x.PropertyValue, map => map.MapFrom(x => x.PropertyDetails.PropertyValue));

            //CreateMap<Product, ProductDetailsViewModel>()
            //    .ForMember(x => x.ImageProducts, map => map.MapFrom(x => x.ImageProducts
            //    .OrderByDescending(y => y.Id).Select(y => y.Url)))

            //    .ForMember(x => x.Price, map => map.MapFrom(x => x.PriceDetails
            //    .OrderByDescending(y => y.CreatedDate).Select(y => y.Price).FirstOrDefault()))

            //    .ForMember(x => x.Promotion, map => map.MapFrom(x => x.PromotionProducts
            //    .Where(y => y.Promotion.BeginDay <= DateTime.Now && y.Promotion.EndDay >= DateTime.Now)
            //    .Select(z => z.Promotion.PromotionPercent).FirstOrDefault()))

            //    .ForMember(x => x.Properties, map => map.MapFrom(x => x.PropertyProducts.Select(y => y.Property)))
            //    .ForMember(x => x.SubCategory, map => map.MapFrom(x => x.SubCategory.SubCategoryName))
            //    .ForMember(x => x.Supplier, map => map.MapFrom(x => x.Supplier.SupplierName));
            //    CreateMap<PropertyDetails, PropertyDetailsModel>();
        }
    }
}
