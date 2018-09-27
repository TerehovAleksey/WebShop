using WebShop.Models.Cart;

namespace WebShop.Infrastructure.Interfaces
{
    public interface ICartService
    {
        void DecrementFromCard(int id);

        void RemoveFromCard(int id);

        void RemoveAll();

        void AddToCard(int id);

        CartViewModel TransformCart();
    }
}
