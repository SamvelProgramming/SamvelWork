using AramatBags.Repositories;
using AramatBags.Models;
using Microsoft.AspNetCore.Mvc;
namespace AramatBags.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        public CartController(ICart cart)
        {
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await _cart.GetAllCartItems();
            return View(cart);
        }

        public IActionResult GetById(int id)
        {
            var cart = _cart.GetCartsById(id);
            return View(cart);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cart cart)
        {
            _cart.AddCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var cart = _cart.GetCartsById(id);
            return View(cart);
        }

        [HttpPost]
        public IActionResult Edit(Cart cart)
        {
            _cart.EditCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _cart.DeleteCart(id);
            return RedirectToAction("Index");
        }
    }
}
