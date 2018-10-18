using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    public partial class UsersApiController
    {
        #region IUserRoleStore

        [HttpPost("role/{roleName}")]
        public async Task AddToRoleAsync([FromBody]ApplicationUser user, string roleName)
        {
            await _userStore.AddToRoleAsync(user, roleName);
        }

        [HttpPost("roles")]
        public async Task<IList<string>> GetRolesAsync(ApplicationUser user)
        {
            return await _userStore.GetRolesAsync(user);
        }

        [HttpGet("usersInRole/{roleName}")]
        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName)
        {
            return await _userStore.GetUsersInRoleAsync(roleName);
        }

        [HttpPost("inrole/{roleName}")]
        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
        {
            return await _userStore.IsInRoleAsync(user, roleName);
        }

        [HttpPost("role/delete/{roleName}")]
        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
        {
            await _userStore.RemoveFromRoleAsync(user, roleName);
        }

        #endregion
    }
}
