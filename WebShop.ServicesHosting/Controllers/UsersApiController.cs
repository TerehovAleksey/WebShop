using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.DAL;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public partial class UsersApiController : ControllerBase
    {
        private readonly UserStore<ApplicationUser> _userStore;

        public UsersApiController(WebShopContext context)
        {
            _userStore = new UserStore<ApplicationUser>(context) { AutoSaveChanges = true };
        }

        #region IUserStore

        [HttpPost("user")]
        public async Task<IdentityResult> CreateAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.CreateAsync(user);
        }

        [HttpPost("user/delete")]
        public async Task<IdentityResult> DeleteAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.DeleteAsync(user);
        }

        [HttpGet("user/find/{userId}")]
        public async Task<ApplicationUser> FindByIdAsync(string userId)
        {
            return await _userStore.FindByIdAsync(userId);
        }

        [HttpGet("user/findByName/{normalizedUserName}")]
        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName)
        {
            return await _userStore.FindByNameAsync(normalizedUserName);
        }

        [HttpPost("getNormalizedUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetNormalizedUserNameAsync(user);
        }

        [HttpPost("getUserId")]
        public async Task<string> GetUserIdAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetUserIdAsync(user);
        }

        [HttpPost("getUserName")]
        public async Task<string> GetUserNameAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.GetUserNameAsync(user);
        }

        [HttpPost("setNormalizedUserName/{normalizedName}")]
        public async Task SetNormalizedUserNameAsync([FromBody]ApplicationUser user, string normalizedName)
        {
            await _userStore.SetNormalizedUserNameAsync(user, normalizedName);
        }

        [HttpPost("setUserName/{userName}")]
        public async Task SetUserNameAsync([FromBody]ApplicationUser user, string userName)
        {
            await _userStore.SetUserNameAsync(user, userName);
        }

        [HttpPut("user")]
        public async Task<IdentityResult> UpdateAsync([FromBody]ApplicationUser user)
        {
            return await _userStore.UpdateAsync(user);
        }

        public void Dispose()
        {

        }

        #endregion
    }
}