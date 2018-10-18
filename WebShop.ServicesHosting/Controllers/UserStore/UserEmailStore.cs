using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserEmailStore

        [HttpGet("user/findByEmail/{normalizedEmail}")]
        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail)
        {
            return await _userStore.FindByEmailAsync(normalizedEmail);
        }

        [HttpPost("getEmail")]
        public async Task<string> GetEmailAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetEmailAsync(user);
        }

        [HttpPost("getEmailConfirmed")]
        public async Task<bool> GetEmailConfirmedAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetEmailConfirmedAsync(user);
        }

        [HttpPost("getNormalizedEmail")]
        public async Task<string> GetNormalizedEmailAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetNormalizedEmailAsync(user);
        }

        [HttpPost("setEmail/{email}")]
        public async Task SetEmailAsync([FromBody]ApplicationUser user, string email)
        {
            await _userStore.SetEmailAsync(user, email);
        }

        [HttpPost("setEmailConfirmed/{confirmated}")]
        public async Task SetEmailConfirmedAsync([FromBody]ApplicationUser user, bool confirmed)
        {
            await _userStore.SetEmailConfirmedAsync(user, confirmed);
        }

        [HttpPost("setNormalizedEmail/{normalizedEmail}")]
        public async Task SetNormalizedEmailAsync([FromBody]ApplicationUser user, string normalizedEmail)
        {
            await _userStore.SetNormalizedEmailAsync(user, normalizedEmail);
        }

        #endregion
    }
}
