using AramatBags.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AramatBags.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProduct _product;
        private readonly IProductCategory _category;

        public HomeController(IProduct product, IProductCategory category)
        {
            _product = product;
            _category = category;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _product.GetAllProducts();
            ViewBag.Products = products;
            var categories = await _category.GetAllProductCategories();
            ViewBag.ProductCategory = categories;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}