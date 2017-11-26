using AutoMapper;
using Mugi.Domain.Entities;
using Mugi.Web.Model;
using Mugi.Web.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mugi.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<AccountModel, Account>();
            CreateMap<LoginCustomerViewModel, Account>();
            CreateMap<RegisterCustomerViewModel, Customer>();
            CreateMap<RegisterStaffViewModel, Staff>();
            CreateMap<CustomerProfileViewModel, Customer>();
            CreateMap<StaffProfileViewModel, Staff>();

            // View UpdateProduct
            CreateMap<UpdateProductViewModel, Product>();

            //Add category
            CreateMap<AddCategoryViewModel, Category>();

            //Add subcategory
            CreateMap<AddSubCategoryViewModel, SubCategory>();
            CreateMap<SubCategoryViewModel, SubCategory>();

            //Add PropertyDetails
            CreateMap<AddPropertyDetailsViewModel, PropertyDetails>();

            //Add Advertisement
            CreateMap<AddAdvertisementViewModel, Advertisement>();

            // AddPromotion
            CreateMap<AddPromotionViewModel, Promotion>();


            //CreateMap<ShopOrderViewModel, ShopOrder>()
            //    .ForMember(x => x.SupplierId, map => map.MapFrom(x => x.PriceInput))
            //    .ForMember(x => x.SupplierId, map => map.MapFrom(x => x.SubProducts))
            //    .ForMember(x => x.ShopOrderProducts, map => map.MapFrom(x => x.Id));



            //CreateMap<InsertProductViewModel, Product>();
            //CreateMap<CategoryModel, Category>();
            //CreateMap<ImageProduct, ImageProduct>();
            //CreateMap<ProductModel, Product>();
            //CreateMap<ProductModel, Product>();

        }
    }
}
