using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using WebShop.DAL;
using WebShop.Data;
using WebShop.Domain;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            //вызов метода заполнения БД начальными значениями
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<WebShopContext>();
                    DbInitializer.Initialize(context);

                    //создание ролей
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>
                        (roleStore,
                        Array.Empty<IRoleValidator<IdentityRole>>(),
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(), null);
                    if (!roleManager.RoleExistsAsync(Constants.Roles.User).Result)
                    {
                        var role = new IdentityRole(Constants.Roles.User);
                        var result = roleManager.CreateAsync(role).Result;
                    }
                    if (!roleManager.RoleExistsAsync(Constants.Roles.Administrator).Result)
                    {
                        var role = new IdentityRole(Constants.Roles.Administrator);
                        var result = roleManager.CreateAsync(role).Result;
                    }
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>
                        (userStore,
                        new OptionsManager<IdentityOptions>
                        (new OptionsFactory<IdentityOptions>(Array.Empty<IConfigureOptions<IdentityOptions>>(), Array.Empty<IPostConfigureOptions<IdentityOptions>>())),
                        new PasswordHasher<ApplicationUser>(),
                        Array.Empty<IUserValidator<ApplicationUser>>(),
                        Array.Empty<IPasswordValidator<ApplicationUser>>(),
                        new UpperInvariantLookupNormalizer(),
                        new IdentityErrorDescriber(),
                        null, null
                        );
                    if (userStore.FindByEmailAsync("admin@mail.com", CancellationToken.None).Result == null)
                    {
                        var user = new ApplicationUser() { UserName = "Admin", Email = "admin@mail.com" };
                        var result = userManager.CreateAsync(user).Result;
                        if (result.Succeeded)
                        {
                            var roleResult = userManager.AddToRoleAsync(user, Constants.Roles.Administrator).Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, ex.Message + "\n Ошибка при заполнении базы данных");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
