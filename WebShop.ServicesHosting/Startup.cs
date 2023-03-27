using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebShop.DAL;
using WebShop.Domain.Entities;
using WebShop.Interfaces;
using WebShop.Logger;
using WebShop.Services.InMemory;
using WebShop.Services.Middleware;
using WebShop.Services.Sql;

namespace WebShop.ServicesHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //внедрение зависимостей
            services.AddSingleton<IEmployeesData, InMemoryEmployeeData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IOrderService, SqlOrderService>();

            //EF
            services.AddDbContext<WebShopContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WebShopContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
