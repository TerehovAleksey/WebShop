using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.DAL;
using WebShop.Domain.Dto.User;
using WebShop.Domain.Entities;

namespace WebShop.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly UserStore<IDentityRole> _userStore;

        public UsersApiController(WebShopContext context)
        {
            _userStore = new UserStore<IDentityRole>(context) { AutoSaveChanges = true };
        }

        #region IUserRoleStore

        [HttpPost("role/{roleName}")]
        public async Task AddToRoleAsync([FromBody]IDentityRole user, string roleName)
        {
            await _userStore.AddToRoleAsync(user, roleName);
        }

        [HttpPost("roles")]
        public async Task<IList<string>> GetRolesAsync(IDentityRole user)
        {
            return await _userStore.GetRolesAsync(user);
        }

        [HttpGet("usersInRole/{roleName}")]
        public async Task<IList<IDentityRole>> GetUsersInRoleAsync(string roleName)
        {
            return await _userStore.GetUsersInRoleAsync(roleName);
        }

        [HttpPost("inrole/{roleName}")]
        public async Task<bool> IsInRoleAsync(IDentityRole user, string roleName)
        {
            return await _userStore.IsInRoleAsync(user, roleName);
        }

        [HttpPost("role/delete/{roleName}")]
        public async Task RemoveFromRoleAsync(IDentityRole user, string roleName)
        {
            await _userStore.RemoveFromRoleAsync(user, roleName);
        }

        #endregion

        #region IUserClaimStore

        [HttpPost("addClaims")]
        public async Task AddClaimsAsync([FromBody]AddClaimsDto claimsDto)
        {
            await _userStore.AddClaimsAsync(claimsDto.User, claimsDto.Claims);
        }

        [HttpPost("getClaims")]
        public async Task<IList<Claim>> GetClaimsAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetClaimsAsync(user);
        }

        [HttpPost("getUsersForClaims")]
        public async Task<IList<IDentityRole>> GetUsersForClaimAsync([FromBody]Claim claim)
        {
            return await _userStore.GetUsersForClaimAsync(claim);
        }

        [HttpPost("removeClaims")]
        public async Task RemoveClaimsAsync([FromBody]RemoveClaimsDto claimsDto)
        {
            await _userStore.RemoveClaimsAsync(claimsDto.User, claimsDto.Claims);
        }

        [HttpPost("replaceClaim")]
        public async Task ReplaceClaimAsync([FromBody]ReplaceClaimsDto claimsDto)
        {
            await _userStore.ReplaceClaimAsync(claimsDto.User, claimsDto.Claim, claimsDto.NewClaim);
        }

        #endregion

        #region IUserPasswordStore

        [HttpPost("getPasswordHash")]
        public async Task<string> GetPasswordHashAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetPasswordHashAsync(user);
        }

        [HttpPost("hasPassword")]
        public async Task<bool> HasPasswordAsync([FromBody]IDentityRole user)
        {
            return await _userStore.HasPasswordAsync(user);
        }

        [HttpPost("setPasswordHash")]
        public async Task SetPasswordHashAsync([FromBody]PasswordHashDto hashDto)
        {
            await _userStore.SetPasswordHashAsync(hashDto.User, hashDto.Hash);
        }

        #endregion

        #region IUserTwoFactorStore

        [HttpPost("getTwoFactorEnabled")]
        public async Task<bool> GetTwoFactorEnabledAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetTwoFactorEnabledAsync(user);
        }

        [HttpPost("setTwoFactorEnabled/{enabled}")]
        public async Task SetTwoFactorEnabledAsync([FromBody]IDentityRole user, bool enabled)
        {
            await _userStore.SetTwoFactorEnabledAsync(user, enabled);
        }

        #endregion

        #region IUserEmailStore

        [HttpGet("user/findByEmail/{normalizedEmail}")]
        public async Task<IDentityRole> FindByEmailAsync(string normalizedEmail)
        {
            return await _userStore.FindByEmailAsync(normalizedEmail);
        }

        [HttpPost("getEmail")]
        public async Task<string> GetEmailAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetEmailAsync(user);
        }

        [HttpPost("getEmailConfirmed")]
        public async Task<bool> GetEmailConfirmedAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetEmailConfirmedAsync(user);
        }

        [HttpPost("getNormalizedEmail")]
        public async Task<string> GetNormalizedEmailAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetNormalizedEmailAsync(user);
        }

        [HttpPost("setEmail/{email}")]
        public async Task SetEmailAsync([FromBody]IDentityRole user, string email)
        {
            await _userStore.SetEmailAsync(user, email);
        }

        [HttpPost("setEmailConfirmed/{confirmated}")]
        public async Task SetEmailConfirmedAsync([FromBody]IDentityRole user, bool confirmed)
        {
            await _userStore.SetEmailConfirmedAsync(user, confirmed);
        }

        [HttpPost("setNormalizedEmail/{normalizedEmail}")]
        public async Task SetNormalizedEmailAsync([FromBody]IDentityRole user, string normalizedEmail)
        {
            await _userStore.SetNormalizedEmailAsync(user, normalizedEmail);
        }

        #endregion

        #region IUserPhoneNumberStore

        [HttpPost("getPhoneNumber")]
        public async Task<string> GetPhoneNumberAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetPhoneNumberAsync(user);
        }

        [HttpPost("getPhoneNumberConfirmed")]
        public async Task<bool> GetPhoneNumberConfirmedAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetPhoneNumberConfirmedAsync(user);
        }

        [HttpPost("setPhoneNumber/{phoneNumber}")]
        public async Task SetPhoneNumberAsync([FromBody]IDentityRole user, string phoneNumber)
        {
            await _userStore.SetPhoneNumberAsync(user, phoneNumber);
        }

        [HttpPost("setPhoneNumberConfirmed/{confirmed}")]
        public async Task SetPhoneNumberConfirmedAsync([FromBody]IDentityRole user, bool confirmed)
        {
            await _userStore.SetPhoneNumberConfirmedAsync(user, confirmed);
        }

        #endregion

        #region IUserLockoutStore

        [HttpPost("getAccessFailedCount")]
        public async Task<int> GetAccessFailedCountAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetAccessFailedCountAsync(user);
        }

        [HttpPost("getLockoutEnabled")]
        public async Task<bool> GetLockoutEnabledAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetLockoutEnabledAsync(user);
        }

        [HttpPost("getLockoutEndDate")]
        public async Task<DateTimeOffset?> GetLockoutEndDateAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetLockoutEndDateAsync(user);
        }

        [HttpPost("incrementAccessFailedCount")]
        public async Task<int> IncrementAccessFailedCountAsync([FromBody]IDentityRole user)
        {
            return await _userStore.IncrementAccessFailedCountAsync(user);
        }

        [HttpPost("resetAccessFailedCount")]
        public async Task ResetAccessFailedCountAsync([FromBody]IDentityRole user)
        {
            await _userStore.ResetAccessFailedCountAsync(user);
        }

        [HttpPost("setLockoutEnabled/{enabled}")]
        public async Task SetLockoutEnabledAsync(IDentityRole user, bool enabled)
        {
            await _userStore.SetLockoutEnabledAsync(user, enabled);
        }

        [HttpPost("setLockoutEndDate")]
        public async Task SetLockoutEndDateAsync([FromBody]SetLockoutDto lockoutDto)
        {
            await _userStore.SetLockoutEndDateAsync(lockoutDto.User, lockoutDto.LockoutEnd);
        }

        #endregion

        #region IUserLoginStore

        [HttpPost("addLogin")]
        public async Task AddLoginAsync([FromBody]AddLoginDto loginDto)
        {
            await _userStore.AddLoginAsync(loginDto.User, loginDto.UserLoginInfo);
        }

        [HttpGet("user/findByLogin/{loginProvider}/{providerKey}")]
        public async Task<IDentityRole> FindByLoginAsync(string loginProvider, string providerKey)
        {
            return await _userStore.FindByLoginAsync(loginProvider, providerKey);
        }

        [HttpPost("getLogins")]
        public async Task<IList<UserLoginInfo>> GetLoginsAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetLoginsAsync(user);
        }

        [HttpPost("removeLogin/{loginProvider}/{providerKey}")]
        public async Task RemoveLoginAsync([FromBody]IDentityRole user, string loginProvider, string providerKey)
        {
            await _userStore.RemoveLoginAsync(user, loginProvider, providerKey);
        }

        #endregion

        #region IUserStore

        [HttpPost("user")]
        public async Task<IdentityResult> CreateAsync([FromBody]IDentityRole user)
        {
            return await _userStore.CreateAsync(user);
        }

        [HttpPost("user/delete")]
        public async Task<IdentityResult> DeleteAsync([FromBody]IDentityRole user)
        {
            return await _userStore.DeleteAsync(user);
        }

        [HttpGet("user/find/{userId}")]
        public async Task<IDentityRole> FindByIdAsync(string userId)
        {
            return await _userStore.FindByIdAsync(userId);
        }

        [HttpGet("user/findByName/{normalizedUserName}")]
        public async Task<IDentityRole> FindByNameAsync(string normalizedUserName)
        {
            return await _userStore.FindByNameAsync(normalizedUserName);
        }

        [HttpPost("getNormalizedUserName")]
        public async Task<string> GetNormalizedUserNameAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetNormalizedUserNameAsync(user);
        }

        [HttpPost("getUserId")]
        public async Task<string> GetUserIdAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetUserIdAsync(user);
        }

        [HttpPost("getUserName")]
        public async Task<string> GetUserNameAsync([FromBody]IDentityRole user)
        {
            return await _userStore.GetUserNameAsync(user);
        }

        [HttpPost("setNormalizedUserName/{normalizedName}")]
        public async Task SetNormalizedUserNameAsync([FromBody]IDentityRole user, string normalizedName)
        {
            await _userStore.SetNormalizedUserNameAsync(user, normalizedName);
        }

        [HttpPost("setUserName/{userName}")]
        public async Task SetUserNameAsync([FromBody]IDentityRole user, string userName)
        {
            await _userStore.SetUserNameAsync(user, userName);
        }

        [HttpPut("user")]
        public async Task<IdentityResult> UpdateAsync([FromBody]IDentityRole user)
        {
            return await _userStore.UpdateAsync(user);
        }

        public void Dispose()
        {

        }

        #endregion
    }
}