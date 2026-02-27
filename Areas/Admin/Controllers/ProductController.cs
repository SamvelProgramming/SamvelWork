using AramatBags.Data;
using AramatBags.Models;
using AramatBags.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AramatBags.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProduct _productService;
        private readonly IProductCategory _categoryService;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDBContext _db;

        public ProductController(
            IProduct productService,
            ApplicationDBContext db,
            IWebHostEnvironment webHost,
            IProductCategory categoryService)
        {
            _productService = productService;
            _db = db;
            _env = webHost;
            _categoryService = categoryService;
        }

        // GET: Admin/Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            ViewBag.Products = products ?? new List<Product>();
            return View();
        }

        // GET: Admin/Product/Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllProductCategories();
            ViewBag.Categories = categories ?? new List<ProductCategory>();
            return View();
        }

        // POST: Admin/Product/Add
        [HttpPost]
        public async Task<IActionResult> Add(Product model, IFormFile photo)
        {
            if (photo != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "Images", "Product");

                // Ensure directory exists
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                string path = Path.Combine(folderPath, fileName);
                model.Image = fileName;

                await using var fileStream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(fileStream);
            }

            await _productService.AddProduct(model);
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Product/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Product/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) return NotFound();

            var categories = await _categoryService.GetAllProductCategories();
            ViewBag.Categories = categories ?? new List<ProductCategory>();
            ViewBag.Product = product;

            return View(product);
        }

        // POST: Admin/Product/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile photo)
        {
            if (photo != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "Images", "Product");

                // Ensure directory exists
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                string path = Path.Combine(folderPath, fileName);
                product.Image = fileName;

                await using var fileStream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(fileStream);
            }
            else
            {
                var existingProduct = await _productService.GetProductById(product.Id);
                if (existingProduct != null)
                {
                    product.Image = existingProduct.Image;
                }
            }

            await _productService.EditProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}