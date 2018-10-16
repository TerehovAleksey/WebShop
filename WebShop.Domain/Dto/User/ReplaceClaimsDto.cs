using System.Security.Claims;
using WebShop.Domain.Entities;

namespace WebShop.Domain.Dto.User
{
    public class ReplaceClaimsDto
    {
        public IDentityRole User { get; set; }
        public Claim Claim { get; set; }
        public Claim NewClaim { get; set; }
    }
}
