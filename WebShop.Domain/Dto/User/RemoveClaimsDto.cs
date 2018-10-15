using System.Collections.Generic;
using System.Security.Claims;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class RemoveClaimsDto
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
