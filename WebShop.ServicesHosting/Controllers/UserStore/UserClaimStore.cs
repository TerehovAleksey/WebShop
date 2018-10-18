using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserClaimStore

        [HttpPost("addClaims")]
        public async Task AddClaimsAsync([FromBody]AddClaimsDto claimsDto)
        {
            await _userStore.AddClaimsAsync(claimsDto.User, claimsDto.Claims);
        }

        [HttpPost("getClaims")]
        public async Task<IList<Claim>> GetClaimsAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetClaimsAsync(user);
        }

        [HttpPost("getUsersForClaims")]
        public async Task<IList<ApplicationUser>> GetUsersForClaimAsync([FromBody]Claim claim)
        {
            return await _userStore.GetUsersForClaimAsync(claim);
        }

        [HttpPost("removeClaims")]
        public async Task RemoveClaimsAsync([FromBody]RemoveClaimsDto claimsDto)
        {
            await _userStore.RemoveClaimsAsync(claimsDto.User, claimsDto.Claims);
        }

        [HttpPost("replaceClaim")]
        public async Task ReplaceClaimAsync([FromBody]ReplaceClaimsDto claimsDto)
        {
            await _userStore.ReplaceClaimAsync(claimsDto.User, claimsDto.Claim, claimsDto.NewClaim);
        }

        #endregion
    }
}
