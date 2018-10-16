using Microsoft.AspNetCore.Identity;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class AddLoginDto
    {
        public IDentityRole User { get; set; }
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}
