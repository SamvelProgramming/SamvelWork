using AramatBags.Interfaces;
using AramatBags.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AramatBags.Data;
using static System.Net.Mime.MediaTypeNames;
namespace AramatBags.Service
{
    public class ProductService : IProduct

    {
        private readonly ApplicationDBContext _dbcontext;
        public ProductService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void AddProduct(Product product)
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
            _dbcontext.Products.Add(Addproduct);
            _dbcontext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var p = _dbcontext.Products.Find(id);
            if (p != null)
            {
                _dbcontext.Products.Remove(p);
                _dbcontext.SaveChanges();
            }
        }

        public void EditProduct(Product product)
        {
            var p = _dbcontext.Products.Find(product.Id);
            if (p != null)
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
                p.Description = product.Description;
                p.Image = product.Image;
                p.ProductCategoryId = product.ProductCategoryId;
                p.ProductCount = product.ProductCount;
                _dbcontext.Products.Update(p);
                _dbcontext.SaveChanges();

            }

        }

        public List<Product> GetAllProducts()
        {
            var product = _dbcontext.Products
            .Select(c => new Product
            {
                Id = c.Id,
                ProductName = c.ProductName,
                Price = c.Price,
                Description = c.Description,
                Image = c.Image

            })
            .ToList();

            return product;
        }

        public Product GetProductById(int id)
        {
            var product = new Product();
            var newproduct = _dbcontext.Products.Find(id);
            if (newproduct != null)
            {
                product.Id = newproduct.Id;
                product.ProductName = newproduct.ProductName;
                product.Price = newproduct.Price;
                product.Description = newproduct.Description;
                product.Image = newproduct.Image;
            }
            return product;
        }
    }
}
