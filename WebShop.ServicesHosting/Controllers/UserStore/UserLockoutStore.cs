using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserLockoutStore

        [HttpPost("getAccessFailedCount")]
        public async Task<int> GetAccessFailedCountAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetAccessFailedCountAsync(user);
        }

        [HttpPost("getLockoutEnabled")]
        public async Task<bool> GetLockoutEnabledAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetLockoutEnabledAsync(user);
        }

        [HttpPost("getLockoutEndDate")]
        public async Task<DateTimeOffset?> GetLockoutEndDateAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetLockoutEndDateAsync(user);
        }

        [HttpPost("incrementAccessFailedCount")]
        public async Task<int> IncrementAccessFailedCountAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.IncrementAccessFailedCountAsync(user);
        }

        [HttpPost("resetAccessFailedCount")]
        public async Task ResetAccessFailedCountAsync([FromBody]ApplicationUser user)
        {
            await _userStore.ResetAccessFailedCountAsync(user);
        }

        [HttpPost("setLockoutEnabled/{enabled}")]
        public async Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
        {
            await _userStore.SetLockoutEnabledAsync(user, enabled);
        }

        [HttpPost("setLockoutEndDate")]
        public async Task SetLockoutEndDateAsync([FromBody]SetLockoutDto lockoutDto)
        {
            await _userStore.SetLockoutEndDateAsync(lockoutDto.User, lockoutDto.LockoutEnd);
        }

        #endregion
    }
}
