using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebShop.Clients.Base;
using WebShop.Domain.Entities;
using WebShop.Interfaces.Api;

namespace WebShop.Clients.Services.Users
{
    public class UsersClient : BaseClient, IUserIdentity
    {
        protected sealed override string ServiceAddress { get; set; }

        public UsersClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/user";
        }

        #region IUserRoleStore

        public Task AddToRoleAsync(IDentityRole user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IDentityRole>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(IDentityRole user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IDentityRole user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserClaimStore

        public Task AddClaimsAsync(IDentityRole user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Claim>> GetClaimsAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IDentityRole>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(IDentityRole user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(IDentityRole user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(IDentityRole user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactorStore

        public Task SetTwoFactorEnabledAsync(IDentityRole user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserEmailStore

        public Task SetEmailAsync(IDentityRole user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IDentityRole user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IDentityRole> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(IDentityRole user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPhoneNumberStore

        public Task SetPhoneNumberAsync(IDentityRole user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(IDentityRole user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(IDentityRole user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(IDentityRole user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLoginStore

        public Task AddLoginAsync(IDentityRole user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(IDentityRole user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IDentityRole> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserStore

        public Task<string> GetUserIdAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(IDentityRole user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(IDentityRole user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(IDentityRole user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IDentityRole> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IDentityRole> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
