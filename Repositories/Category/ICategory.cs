using AramatBags.Models;
namespace AramatBags.Interfaces
{
    public interface ICategory
    {
        Task AddCategory(Category category);
        Task DeleteCategory(int id);
        Task EditCategory(Category category);
        Task<List<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int id);
    }
}
