using AramatBags.Data;
using AramatBags.Models;
using AramatBags.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
public class CartService : ICart
    {
        private readonly ApplicationDBContext _dbcontext;
        public CartService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddCart(Cart cart)
        {
            var addcart = new Cart()
            {
                Id = cart.Id,
                Quantity = cart.Quantity,
                TotalPrice = cart.TotalPrice,
            };
            await _dbcontext.Carts.AddAsync(addcart);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteCart(int id)
        {
            var p = _dbcontext.Carts.Find(id);
            if (p != null)
            {
                _dbcontext.Carts.Remove(p);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task EditCart(Cart cart)
        {
            if (cart != null)
            { 
                _dbcontext.Carts.Update(cart);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task<List<CartItem>> GetAllCartItems(CartItem cartItem)
        {
            var cartitem = await _dbcontext.CartItems.ToListAsync();
            return cartitem;
        }
        public async Task<Cart> GetCartsById(int id)
        {
            var cart = await _dbcontext.Carts.FindAsync(id);
            return cart;
        }

    Task<List<Cart>> ICart.GetAllCartItems()
    {
        throw new NotImplementedException();
    }
}

