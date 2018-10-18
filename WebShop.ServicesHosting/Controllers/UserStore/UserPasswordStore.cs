using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserPasswordStore

        [HttpPost("getPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetPasswordHashAsync(user);
        }

        [HttpPost("hasPassword")]
        public async Task<bool> HasPasswordAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.HasPasswordAsync(user);
        }

        [HttpPost("setPasswordHash")]
        public async Task SetPasswordHashAsync([FromBody]PasswordHashDto hashDto)
        {
            await _userStore.SetPasswordHashAsync(hashDto.User, hashDto.Hash);
        }

        #endregion
    }
}
