using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Mugi.Core;
using Mugi.Core.Infrastructure;
using Mugi.Service.Services;
using AutoMapper;
using System;
using Mugi.Web.Service;

namespace Mugi.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<IISOptions>(options =>
            {});
            // Add framework services.
            services.AddMvc();

            // Config db service
            var connectionString = @"Server=.;Database=MugiShop;Trusted_Connection=True;";
            services.AddDbContext<MugiStoreDbContext>(options => options.UseSqlServer(connectionString));

            // Unit of work
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            // Services
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(ISupplierService), typeof(SupplierService));
            services.AddScoped(typeof(IPriceDetailsService), typeof(PriceDetailsService));
            services.AddScoped(typeof(IImageProductService), typeof(ImageProductService));
            services.AddScoped(typeof(IAdvertisementService), typeof(AdvertisementService));
            services.AddScoped(typeof(ISubProductService), typeof(SubProductService));
            services.AddScoped(typeof(IOrderService), typeof(OrderService));
            services.AddScoped(typeof(IOrderSubProductService), typeof(OrderSubProductService));
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(IPropertyService), typeof(PropertyService));
            services.AddScoped(typeof(ISubCategoryService), typeof(SubCategoryService));
            services.AddScoped(typeof(IPropertyDetailsService), typeof(PropertyDetailsService));
            services.AddScoped(typeof(IGoodsReceiptService), typeof(GoodsReceiptService));
            services.AddScoped(typeof(IStaffServie), typeof(StaffService));
            services.AddScoped(typeof(IReturnProductService), typeof(ReturnProductService));
            services.AddScoped(typeof(IPromotionService), typeof(PromotionService));
            services.AddScoped(typeof(IViewRenderService), typeof(ViewRenderService));

            //Mappings
            services.AddAutoMapper();

            //Session
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseSession();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=HomePage}/{id= UrlParameter.Optional}");
            });
        }
    }
}