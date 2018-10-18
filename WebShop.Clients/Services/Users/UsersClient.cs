using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Clients.Base;
using WebShop.Domain.Entities;
using WebShop.Interfaces.Api;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient : BaseClient, IUserIdentity
    {
        protected sealed override string ServiceAddress { get; set; }

        public UsersClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/users";
        }

        #region IUserStore

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getUserId";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getUserName";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            var url = $"{ServiceAddress}/setUserName/{userName}";
            await PostAsync(url, user);
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getNormalizedUserName";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizedUserName = normalizedName;
            var url = $"{ServiceAddress}/setNormalizedUserName/{normalizedName}";
            await PostAsync(url, user);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user";
            var result = await PutAsync(url, user);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user/delete";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user/find/{userId}";
            var result = await GetAsync<ApplicationUser>(url);
            return result;
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user/findByName/{normalizedUserName}";
            var result = await GetAsync<ApplicationUser>(url);
            return result;
        }

        public void Dispose()
        {
            client.Dispose();
        }

        #endregion
    }
}
