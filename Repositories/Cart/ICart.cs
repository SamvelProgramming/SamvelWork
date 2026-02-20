using AramatBags.Models;
namespace AramatBags.Repositories
{
    public interface ICart
    {
        Task AddCart(Cart Cart);
        Task DeleteCart(int id);
        Task EditCart(Cart Cart);
        Task<List<Cart>> GetAllCartItems();
        Task<Cart> GetCartsById(int id);
    }
}
