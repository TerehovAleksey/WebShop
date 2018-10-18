using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserLoginStore

        public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/addLogin";
            await PostAsync(url, new AddLoginDto() { User = user, UserLoginInfo = login });
        }

        public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/removeLogin/{loginProvider}/{providerKey}";
            await PostAsync(url, user);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getLogins";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<List<UserLoginInfo>>();
        }

        public async Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/user/findByLogin/{loginProvider}/{providerKey}";
            return await GetAsync<ApplicationUser>(url);
        }

        #endregion
    }
}
