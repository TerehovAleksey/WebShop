using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebShop.Clients.Services.Employees;
using WebShop.DAL;
using WebShop.Domain.Entities;
using WebShop.Interfaces;
using WebShop.Services;
using WebShop.Services.InMemory;
using WebShop.Services.Sql;

namespace WebShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //внедрение зависимостей
            services.AddTransient<IEmployeesData, EmployeesClient>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IOrderService, SqlOrderService>();

            //EF
            services.AddDbContext<WebShopContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 

            services.AddIdentity<ApplicationUser, IdentityRole>()//Identity
                .AddEntityFrameworkStores<WebShopContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//корзина
            services.AddScoped<ICartService, CoocieCartService>();

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
                o.Cookie.Expiration = TimeSpan.FromDays(30);
                o.LoginPath = "/Account/Login";
                o.LogoutPath = "/Account/Logout";
                o.AccessDeniedPath = "/Account/AccessDenied";
                o.SlidingExpiration = true;
            });

            //добавление mvc-архитектуры
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
