using AramatBags.Interfaces;
using AramatBags.Models;
using Microsoft.AspNetCore.Mvc;

namespace AramatBags.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _product.GetAllProducts();
            return View(products);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _product.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _product.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _product.GetProductById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
                return View(product);

            await _product.EditProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _product.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}