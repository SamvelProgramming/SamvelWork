using AramatBags.Interfaces;
using AramatBags.Models;
using AramatBags.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace AramatBags.Controllers
{
    public class CartController : Controller
    {
        private readonly ICart _cart;
        public CartController(ICart cart)
        {
            _cart = cart;
        }

        public IActionResult Index()
        {
            var cart = _cart.GetAllCarts();
            return View(cart);
        }

        public IActionResult GetById(int id)
        {
            var cart = _cart.GetCartById(id);
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
            var cart = _cart.GetCartById(id);
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
