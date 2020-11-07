using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using data.Abstract;
using business.Abstract;
using business.Concrete;
using data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ui.Identity;
using ui.EmailService;

namespace ui
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration ;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlite("Data Source=BookingDb"));
            
            services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            
               services.Configure<IdentityOptions>(options =>
            {
                // password

                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;


                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                     HttpOnly = true,
                     Name=".BarberApp.Security.Cookie",
                     SameSite = SameSiteMode.Strict
                };

            });

            services.AddScoped<IEmailSender, SmtpEmailSender>(i=>
                new SmtpEmailSender(Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:UserName"],
                    Configuration["EmailSender:Password"]));
            
            services.AddScoped<IBookingRepository, EFCoreBookingRepository>();
            services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();
            services.AddScoped<IProductRepository, EFCoreProductRepository>();
            services.AddScoped<IServiceRepository, EFCoreServiceRepository>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IServiceService, ServiceManager>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "search",
                 pattern: "search",
                 defaults: new { controller = "Shop", action = "Search" }
               );
               
                endpoints.MapControllerRoute(
                 name: "productdetails",
                 pattern: "{producturl}",
                 defaults: new { controller = "Shop", action = "Details" }
               );
               
               endpoints.MapControllerRoute(
                 name: "createbooking",
                 pattern: "booking/create",
                 defaults: new { controller = "Booking", action = "CreateBooking" }
               );
               endpoints.MapControllerRoute(
                 name: "createbooking",
                 pattern: "booking/create/{customerId}",
                 defaults: new { controller = "Booking", action = "CreateBooking" }
               );
               
               endpoints.MapControllerRoute(
                 name: "bookinghistory",
                 pattern: "booking/history",
                 defaults: new { controller = "Booking", action = "BookingHistory" }
               );
               endpoints.MapControllerRoute(
                 name: "adminbookingcreate",
                 pattern: "admin/booking/create",
                 defaults: new { controller = "Admin", action = "CreateBooking" }
               );
               endpoints.MapControllerRoute(
                 name: "adminbookinglist",
                 pattern: "admin/bookings",
                 defaults: new { controller = "Admin", action = "BookingHistory" }
               );
               endpoints.MapControllerRoute(
                 name: "editbooking",
                 pattern: "admin/booking/{id}",
                 defaults: new { controller = "Admin", action = "EditBooking" }
               );

               endpoints.MapControllerRoute(
                 name: "adminusers",
                 pattern: "admin/users",
                 defaults: new { controller = "Admin", action = "UserList" }
               );
               endpoints.MapControllerRoute(
                 name: "createuser",
                 pattern: "admin/users/create",
                 defaults: new { controller = "Admin", action = "CreateUser" }
               );
                endpoints.MapControllerRoute(
                 name: "edituser",
                 pattern: "admin/users/{id?}",
                 defaults: new { controller = "Admin", action = "EditUser" }
               );

               endpoints.MapControllerRoute(
                 name: "adminroles",
                 pattern: "admin/roles",
                 defaults: new { controller = "Admin", action = "RoleList" }
               );
                endpoints.MapControllerRoute(
                 name: "editrole",
                 pattern: "admin/roles/{id?}",
                 defaults: new { controller = "Admin", action = "EditRole" }
               );

                 endpoints.MapControllerRoute(
                 name: "adminProducts",
                 pattern: "admin/products",
                 defaults: new { controller = "Admin", action = "ProductList" }
               );
               endpoints.MapControllerRoute(
                 name: "adminProductCreate",
                 pattern: "admin/products/create",
                 defaults: new { controller = "Admin", action = "CreateProduct" }
               );
                endpoints.MapControllerRoute(
                    name: "adminEditProduct",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "EditProduct" }
                );

                endpoints.MapControllerRoute(
                 name: "adminCategories",
                 pattern: "admin/categories",
                 defaults: new { controller = "Admin", action = "CategoryList" }
               );
                endpoints.MapControllerRoute(
                 name: "adminCategoryCreate",
                 pattern: "admin/categories/create",
                 defaults: new { controller = "Admin", action = "CreateCategory" }
               );
                endpoints.MapControllerRoute(
                    name: "adminEditcategory",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "EditCategory" }
                );

                endpoints.MapControllerRoute(
                    name : "products",
                    pattern : "products/{category?}",
                    defaults : new {controller = "Shop", action = "List"}
                );
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}"

                   );
            });
            IdentitySeed.Seed(userManager,roleManager,configuration).Wait();
        }
    }
}
