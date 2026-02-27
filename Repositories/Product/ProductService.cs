using AramatBags.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AramatBags.Data;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using AramatBags.Repositories;
namespace AramatBags.Service
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDBContext _dbcontext;
        public ProductService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddProduct(Product product)
        {
            var Addproduct = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ProductCategoryId = product.ProductCategoryId,
                ProductCount = product.ProductCount,
                Image = product.Image

            };
            await _dbcontext.Products.AddAsync(Addproduct);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var p = _dbcontext.Products.Find(id);
            if (p != null)
            {
                _dbcontext.Products.Remove(p);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task EditProduct(Product product)
        {
            if (product != null)
            {
                _dbcontext.Products.Update(product);
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var product = await _dbcontext.Products.ToListAsync();
            return product;
        }
        public async Task<Product> GetProductById(int id)
        {;
            var product = await _dbcontext.Products.FindAsync(id);
            return product;
        }

    }
}
