using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserPhoneNumberStore


        public async Task SetPhoneNumberAsync(ApplicationUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;
            var url = $"{ServiceAddress}/setPhoneNumber/{phoneNumber}";
            await PostAsync(url, user);
        }

        public async Task<string> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getPhoneNumber";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getPhoneNumberConfirmed";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<bool>();
        }

        public async Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.PhoneNumberConfirmed = confirmed;
            var url = $"{ServiceAddress}/setPhoneNumberConfirmed/{confirmed}";
            await PostAsync(url, user);
        }

        #endregion
    }
}
