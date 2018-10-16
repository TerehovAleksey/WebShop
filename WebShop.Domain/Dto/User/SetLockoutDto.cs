using System;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class SetLockoutDto
    {
        public IDentityRole User { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
