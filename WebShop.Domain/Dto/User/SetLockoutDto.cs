using System;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class SetLockoutDto
    {
        public ApplicationUser User { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
