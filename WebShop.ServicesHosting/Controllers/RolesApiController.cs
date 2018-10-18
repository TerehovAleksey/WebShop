using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebShop.DAL;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/roles")]
    [ApiController]
    public class RolesApiController : ControllerBase
    {
        private readonly RoleStore<IdentityRole> _rolesStore;

        public RolesApiController(WebShopContext context)
        {
            _rolesStore = new RoleStore<IdentityRole>(context);
        }

        [HttpPost]
        public async Task<IdentityResult> CreateAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.CreateAsync(role);
        }

        [HttpPost("delete")]
        public async Task<IdentityResult> DeleteAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.DeleteAsync(role);
        }

        public void Dispose()
        {

        }

        [HttpGet("findById/{roleId}")]
        public async Task<IdentityRole> FindByIdAsync(string roleId)
        {
            return await _rolesStore.FindByIdAsync(roleId);
        }

        [HttpGet("findByName/{normalizedRoleName}")]
        public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName)
        {
            return await _rolesStore.FindByNameAsync(normalizedRoleName);
        }

        [HttpPost("getNormalizedRoleName")]
        public async Task<string> GetNormalizedRoleNameAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.GetNormalizedRoleNameAsync(role);
        }

        [HttpPost("getRoleId")]
        public async Task<string> GetRoleIdAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.GetRoleIdAsync(role);
        }

        [HttpPost("getRoleName")]
        public async Task<string> GetRoleNameAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.GetRoleNameAsync(role);
        }

        [HttpPost("setNormalizedRoleName/{normalizedName}")]
        public async Task SetNormalizedRoleNameAsync([FromBody]IdentityRole role, string normalizedName)
        {
            await _rolesStore.SetNormalizedRoleNameAsync(role, normalizedName);
        }

        [HttpPost("setRoleName/{roleName}")]
        public async Task SetRoleNameAsync([FromBody]IdentityRole role, string roleName)
        {
            await _rolesStore.SetRoleNameAsync(role, roleName);
        }

        [HttpPut]
        public async Task<IdentityResult> UpdateAsync([FromBody]IdentityRole role)
        {
            return await _rolesStore.UpdateAsync(role);
        }
    }
}