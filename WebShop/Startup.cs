using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebShop.DAL;
using WebShop.Domain.Entities;
using WebShop.Infrastructure;
using WebShop.Infrastructure.Implementations;
using WebShop.Infrastructure.Interfaces;

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
            services.AddSingleton<IEmployeesData, InMemoryEmployeeData>();
            services.AddScoped<IProductData, SqlProductData>();

            services.AddDbContext<WebShopContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //EF

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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
