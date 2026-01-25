using AramatBags.Models;
namespace AramatBags.Interfaces
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        void EditProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
