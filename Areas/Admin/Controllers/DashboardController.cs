using AramatBags.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using AramatBags.Repositories;

namespace AramatBags.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IProduct _product;
        private readonly ICategory _category;
        private readonly ICart _cart;

        public DashboardController(IProduct product)
        {
            _product = product;
        }

        public IActionResult Index()
        {
            var products = _product.GetAllProducts();
            return View(products);
        }
    }
}
