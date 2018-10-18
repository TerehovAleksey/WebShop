using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class PasswordHashDto
    {
        public ApplicationUser User { get; set; }
        public string Hash { get; set; }
    }
}
