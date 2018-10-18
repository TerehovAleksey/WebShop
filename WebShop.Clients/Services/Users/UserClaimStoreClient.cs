using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.Clients.Services.Users
{
    public partial class UsersClient
    {
        #region IUserClaimStore

        public async Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/addClaims";
            await PostAsync(url, new AddClaimsDto() { User = user, Claims = claims });
        }

        public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getClaims";
            var result = await PostAsync(url, user);
            return await result.Content.ReadAsAsync<IList<Claim>>();
        }

        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getUsersForClaim";
            var result = await PostAsync(url, claim);
            return await result.Content.ReadAsAsync<IList<ApplicationUser>>();
        }

        public async Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/removeClaims";
            await PostAsync(url, new RemoveClaimsDto() { User = user, Claims = claims });
        }

        public async Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/replaceClaim";
            await PostAsync(url, new ReplaceClaimsDto() { User = user, Claim = claim, NewClaim = newClaim });
        }

        #endregion
    }
}
