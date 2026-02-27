using AramatBags.Models;
using AramatBags.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AramatBags.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IProductCategory _service;
        private readonly IWebHostEnvironment _env;
        public CategoryController(IProductCategory service, IWebHostEnvironment webHost)
        {
            _service = service;
            _env = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllProductCategories();
            ViewBag.GetAll = categories ?? new List<ProductCategory>();
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductCategory model, IFormFile photo)
        {
            if (photo != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "Images", "Category");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                string path = Path.Combine(folderPath, fileName);
                model.Image = fileName;

                await using var fileStream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(fileStream);
            }

            await _service.AddProductCategory(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteProductCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _service.GetProductCategoryById(id);
            if (category == null)
                return NotFound();

            ViewBag.Product = category;
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductCategory product, IFormFile photo)
        {
            if (photo != null)
            {
                string folderPath = Path.Combine(_env.WebRootPath, "Images", "Category");
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
                var img = await _service.GetProductCategoryById(product.CategoryId);
                if (img != null)
                    product.Image = img.Image;
            }
            await _service.EditProductCategory(product);
            return RedirectToAction(nameof(Index));
        }
    }
}