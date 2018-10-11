using WebShop.Domain.Models.Cart;

namespace WebShop.Interfaces
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
