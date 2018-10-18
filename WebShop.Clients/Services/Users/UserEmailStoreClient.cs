using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserEmailStore

        public async Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            var url = $"{ServiceAddress}/setEmail/{email}";
            await PostAsync(url, user);
        }

        public async Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getEmail";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getEmailConfirmed";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<bool>();
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = confirmed;
            var url = $"{ServiceAddress}/setEmailConfirmed/{confirmed}";
            await PostAsync(url, user);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user/findByEmail/{normalizedEmail}";
            return await GetAsync<ApplicationUser>(url);
        }

        public async Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getNormalizedEmail";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.NormalizedEmail = normalizedEmail;
            var url = $"{ServiceAddress}/setNormalizedEmail/{normalizedEmail}";
            await PostAsync(url, user);
        }

        #endregion
    }
}
