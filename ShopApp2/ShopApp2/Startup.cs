using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp2.Business.Abstract;
using ShopApp2.Business.Concrete;
using ShopApp2.DataAccess.Abstract;
using ShopApp2.DataAccess.Concrete.EfCore;
using ShopApp2.Presentation.EmailServices;
using ShopApp2.Presentation.Identity;
using ShopApp2.Presentation.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp2
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                //options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = false;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name=".ShopApp.Security.Cookie",
                    SameSite=SameSiteMode.Strict //  cross-site atacklarýni engeller.
                };
            });
                       
            
            
            services.AddScoped<IProductDal, EfCoreProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryDal, EfCoreCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICartDal, EfCoreCartDal>();
            services.AddScoped<ICartService, CartManager>();

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.CustomStaticFiles();
            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "products", pattern: "products/{category?}", defaults: new
                { controller = "Shop", action = "List" });

                endpoints.MapControllerRoute(name: "adminProducts", pattern: "admin/products", defaults: new
                { controller = "Admin", action = "ProductList" });

                endpoints.MapControllerRoute(name: "adminProducts", pattern: "admin/products/{id?}", defaults: new
                { controller = "Admin", action = "EditProduct" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedIdentity.Seed(userManager, roleManager, Configuration).Wait();
        }
    }
}
