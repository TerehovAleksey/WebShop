using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserPasswordStore

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            var url = $"{ServiceAddress}/setPasswordHash";
            await PostAsync(url, new PasswordHashDto() { User = user, Hash = passwordHash });
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getPasswordHash";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/hasPassword";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<bool>();
        }

        #endregion
    }
}
