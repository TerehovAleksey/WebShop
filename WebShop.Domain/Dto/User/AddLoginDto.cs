using Microsoft.AspNetCore.Identity;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class AddLoginDto
    {
        public ApplicationUser User { get; set; }
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
