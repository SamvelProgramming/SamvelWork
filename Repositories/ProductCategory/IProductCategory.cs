using AramatBags.Models;
namespace AramatBags.Repositories
{
    public interface IProductCategory
    {
        Task AddProductCategory(ProductCategory productCategory);
        Task DeleteProductCategory(int id);
        Task EditProductCategory(ProductCategory productCategory);
        Task<List<ProductCategory>> GetAllProductCategories();
        Task<ProductCategory> GetProductCategoryById(int id);
    }
}
