using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Clients.Base;

namespace WebShop.Clients.Services.Users
{
    public class RolesClient : BaseClient, IRoleStore<IdentityRole>
    {
        protected sealed override string ServiceAddress { get; set; }

        public RolesClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/roles";
        }

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}";
            var result = await PostAsync(url, role);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}";
            var result = await PutAsync(url, role);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/delete";
            var result = await PostAsync(url, role);
            return await result.Content.ReadAsAsync<IdentityResult>();
        }

        public async Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getRoleId";
            var result = await PostAsync(url, role);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getRoleName";
            var result = await PostAsync(url, role);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Name = roleName;
            var url = $"{ServiceAddress}/setRoleName/{roleName}";
            await PostAsync(url, role);
        }

        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/getNormalizedRoleName";
            var result = await PostAsync(url, role);
            return await result.Content.ReadAsAsync<string>();
        }

        public async Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
        {
            role.NormalizedName = normalizedName;
            var url = $"{ServiceAddress}/setNormalizedRoleName/{normalizedName}";
            await PostAsync(url, role);
        }

        public async Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/findById/{roleId}";
            return await GetAsync<IdentityRole>(url);
        }

        public async Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var url = $"{ServiceAddress}/findByName/{normalizedRoleName}";
            return await GetAsync<IdentityRole>(url);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
