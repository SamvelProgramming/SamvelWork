using AramatBags.Models;
namespace AramatBags.Interfaces
{
    public interface IProduct
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task EditProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product>GetProductById(int id);
    }
}
