using WebShop.Domain.Models.Cart;

namespace WebShop.Interfaces
{
    public interface ICartStore
    {
        Cart Cart { get; set; }
    }
}
