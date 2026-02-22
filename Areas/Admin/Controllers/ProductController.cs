using AramatBags.Interfaces;
using AramatBags.Models;
using Microsoft.AspNetCore.Mvc;
namespace AramatBags.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }

        public IActionResult Index()
        {
            var products = _product.GetAllProducts();
            return View(products);
        }

        public IActionResult GetById(int id)
        {
            var product = _product.GetProductById(id);
            return View(product);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            _product.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _product.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _product.EditProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _product.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
