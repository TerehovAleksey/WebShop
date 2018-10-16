using Microsoft.AspNetCore.Identity;
using WebShop.Domain.Entities;

namespace WebShop.Interfaces.Api
{
    public interface IUserIdentity : IUserRoleStore<IDentityRole>, IUserClaimStore<IDentityRole>,
        IUserPasswordStore<IDentityRole>, IUserTwoFactorStore<IDentityRole>, IUserEmailStore<IDentityRole>,
        IUserPhoneNumberStore<IDentityRole>, IUserLockoutStore<IDentityRole>, IUserLoginStore<IDentityRole>
    {

    }
}
