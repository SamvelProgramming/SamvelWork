using AramatBags.Data;
using AramatBags.Interfaces;
using AramatBags.Models;
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
        public void AddCategory(Category category)
        {
            var Addcategory = new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                Image = category.Image
            };
            _dbcontext.Categories.Add(Addcategory);
            _dbcontext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var p = _dbcontext.Categories.Find(id);
            if (p != null)
            {
                _dbcontext.Categories.Remove(p);
                _dbcontext.SaveChanges();
            }
        }

        public void EditCategory(Category category)
        {
            var p = _dbcontext.Categories.Find(category.CategoryId);
            if (p != null)
            {
                p.CategoryId = category.CategoryId;
                p.Name = category.Name;
                p.Description = category.Description;
                p.Image = category.Image;
                _dbcontext.Categories.Update(p);
                _dbcontext.SaveChanges();
            }

        }

        public List<Category> GetAllCategories()
        {
            var categories = _dbcontext.Categories
            .Select(c => new Category
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description,
                Image = c.Image,
            })
            .ToList();

            return categories;
        }
        public Category GetCategoryById(int id)
        {
            var product = new Category();
            var newproduct = _dbcontext.Categories.Find(id);
            if (newproduct != null)
            {
                product.CategoryId = newproduct.CategoryId;
                product.Name = newproduct.Name;
                product.Description = newproduct.Description;
                product.Image = newproduct.Image;
            }
            return product;
        }

    }
}
