using AramatBags.Data;
using AramatBags.Models;
using AramatBags.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AramatBags.Service
{
    public class ProductCategoryService : IProductCategory
    {
        private readonly ApplicationDBContext _dbcontext;

        public ProductCategoryService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddProductCategory(ProductCategory productcategory)
        {
            var newCategory = new ProductCategory
            {
                CategoryName = productcategory.CategoryName,
                CategoryDescription = productcategory.CategoryDescription,
                Image = productcategory.Image
            };

            await _dbcontext.ProductCategory.AddAsync(newCategory);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            var category = await _dbcontext.ProductCategory.FindAsync(id);
            if (category != null)
            {
                _dbcontext.ProductCategory.Remove(category);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task EditProductCategory(ProductCategory productcategory)
        {
            var category = await _dbcontext.ProductCategory.FindAsync(productcategory.CategoryId);
            if (category != null)
            {
                category.CategoryName = productcategory.CategoryName;
                category.CategoryDescription = productcategory.CategoryDescription;
                category.Image = productcategory.Image;

                _dbcontext.ProductCategory.Update(category);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task<List<ProductCategory>> GetAllProductCategories()
        {
            return await _dbcontext.ProductCategory.ToListAsync();
        }
        public async Task<ProductCategory> GetProductCategoryById(int id)
        {
            var category = await _dbcontext.ProductCategory.FindAsync(id);
            if (category != null)
            {
                return new ProductCategory
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                    Image = category.Image
                };
            }
            return null;
        }
    }
}