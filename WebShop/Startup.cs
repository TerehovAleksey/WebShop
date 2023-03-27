using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using WebShop.Clients.Services.Employees;
using WebShop.Clients.Services.Orders;
using WebShop.Clients.Services.Products;
using WebShop.Clients.Services.Users;
using WebShop.Domain.Entities;
using WebShop.Interfaces;
using WebShop.Interfaces.Api;
using WebShop.Logger;
using WebShop.Services;
using WebShop.Services.Middleware;

namespace WebShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region зависимости

            //внедрение зависимостей
            services.AddTransient<IEmployeesData, EmployeesClient>();
            services.AddTransient<IProductData, ProductsClient>();
            services.AddTransient<IOrderService, OrdersClient>();

            //корзина
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartStore, CookieCartStore>();

            services.AddTransient<IUserIdentity, UsersClient>();
            services.AddTransient<IUserStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserRoleStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserClaimStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserPasswordStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserTwoFactorStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserEmailStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserPhoneNumberStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserLockoutStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IUserLoginStore<ApplicationUser>, UsersClient>();
            services.AddTransient<IRoleStore<IdentityRole>, RolesClient>();

            #endregion

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders();

            //конфигурация идентификации
            services.Configure<IdentityOptions>(o =>
            {
                //настройки пароля
                o.Password.RequiredLength = 6;

                //настройки локаута
                o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                o.Lockout.MaxFailedAccessAttempts = 10;
                o.Lockout.AllowedForNewUsers = true;

                //настройки пользователя
                o.User.RequireUniqueEmail = true;
            });

            //конфигурация куки
            services.ConfigureApplicationCookie(o =>
            {
                o.Cookie.HttpOnly = true;
                //o.Cookie.Expiration = TimeSpan.FromDays(30);
                o.LoginPath = "/Account/Login";
                o.LogoutPath = "/Account/Logout";
                o.AccessDeniedPath = "/Account/AccessDenied";
                o.SlidingExpiration = true;
            });

            //добавление mvc-архитектуры
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseStatusCodePagesWithRedirects("~/Home/ErrorStatus/{0}");
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("AdminArea", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
