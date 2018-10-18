using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserLoginStore

        [HttpPost("addLogin")]
        public async Task AddLoginAsync([FromBody]AddLoginDto loginDto)
        {
            await _userStore.AddLoginAsync(loginDto.User, loginDto.UserLoginInfo);
        }

        [HttpGet("user/findByLogin/{loginProvider}/{providerKey}")]
        public async Task<ApplicationUser> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return await _userStore.FindByLoginAsync(loginProvider, providerKey);
        }

        [HttpPost("getLogins")]
        public async Task<IList<UserLoginInfo>> GetLoginsAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetLoginsAsync(user);
        }

        [HttpPost("removeLogin/{loginProvider}/{providerKey}")]
        public async Task RemoveLoginAsync([FromBody]ApplicationUser user, string loginProvider, string providerKey)
        {
            await _userStore.RemoveLoginAsync(user, loginProvider, providerKey);
        }

        #endregion
    }
}
