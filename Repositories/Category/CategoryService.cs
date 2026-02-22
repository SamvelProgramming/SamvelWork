using AramatBags.Data;
using AramatBags.Interfaces;
using AramatBags.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
namespace AramatBags.Service
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDBContext _dbcontext;
        public CategoryService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddCategory(Category category)
        {
            var Addcategory = new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                Image = category.Image
            };
            await _dbcontext.Categories.AddAsync(Addcategory);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var p = await _dbcontext.Categories.FindAsync(id);
            if (p != null)
            {
                _dbcontext.Categories.Remove(p);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task EditCategory(Category category)
        { 
            _dbcontext.Categories.Update(category);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Category>> GetAllCategory()
        {
            var categories = await _dbcontext.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var product = await _dbcontext.Categories.FindAsync(id);
            return product;
        }

    }
}
