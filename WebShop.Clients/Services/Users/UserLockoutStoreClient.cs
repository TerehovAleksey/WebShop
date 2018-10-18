using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserLockoutStore

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getLockoutEndDate";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<DateTimeOffset?>();
        }

        public async Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            user.LockoutEnd = lockoutEnd;
            var url = $"{ServiceAddress}/setLockoutEndDate";
            await PostAsync(url, new SetLockoutDto() { User = user, LockoutEnd = lockoutEnd });
        }

        public async Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/incrementAccessFailedCount";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<int>();
        }

        public async Task ResetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/resetAccessFailedCount";
            await PostAsync(url, user);
        }

        public async Task<int> GetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getAccessFailedCount";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<int>();
        }

        public async Task<bool> GetLockoutEnabledAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getLockoutEnabled";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<bool>();
        }

        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken)
        {
            user.LockoutEnabled = enabled;
            var url = $"{ServiceAddress}/setLockoutEnabled/{enabled}";
            await PostAsync(url, user);
        }

        #endregion
    }
}
