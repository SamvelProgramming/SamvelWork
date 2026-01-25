using AramatBags.Models;
namespace AramatBags.Interfaces
{
    public interface ICategory
    {
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void EditCategory(Category category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
