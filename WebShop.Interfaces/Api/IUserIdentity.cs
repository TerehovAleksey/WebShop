using Microsoft.AspNetCore.Identity;
using WebShop.Domain.Entities;

namespace WebShop.Interfaces.Api
{
    public interface IUserIdentity : IUserRoleStore<ApplicationUser>, IUserClaimStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>, IUserTwoFactorStore<ApplicationUser>, IUserEmailStore<ApplicationUser>,
        IUserPhoneNumberStore<ApplicationUser>, IUserLockoutStore<ApplicationUser>, IUserLoginStore<ApplicationUser>
    {

    }
}
