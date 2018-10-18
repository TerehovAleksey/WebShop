using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserRoleStore

        public async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/role/{roleName}";
            await PostAsync(url, user);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/roles";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<IList<string>>();
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/usersInRole/{roleName}";
            return await GetAsync<List<ApplicationUser>>(url);
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/inRole/{roleName}";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<bool>();
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/role/delete/{roleName}";
            await PostAsync(url, user);
        }

        #endregion
    }
}
