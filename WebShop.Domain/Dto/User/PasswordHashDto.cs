using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class PasswordHashDto
    {
        public IDentityRole User { get; set; }
        public string Hash { get; set; }
    }
}
