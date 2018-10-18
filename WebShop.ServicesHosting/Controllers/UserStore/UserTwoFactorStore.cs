using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserTwoFactorStore

        [HttpPost("getTwoFactorEnabled")]
        public async Task<bool> GetTwoFactorEnabledAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetTwoFactorEnabledAsync(user);
        }

        [HttpPost("setTwoFactorEnabled/{enabled}")]
        public async Task SetTwoFactorEnabledAsync([FromBody]ApplicationUser user, bool enabled)
        {
            await _userStore.SetTwoFactorEnabledAsync(user, enabled);
        }

        #endregion
    }
}
