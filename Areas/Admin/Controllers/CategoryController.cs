using AramatBags.Interfaces;
using AramatBags.Models;
using Microsoft.AspNetCore.Mvc;
namespace AramatBags.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            var categories = _category.GetAllCategory();
            return View(categories);
        }

        public IActionResult GetById(int id)
        {
            var category = _category.GetCategoryById(id);
            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _category.AddCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _category.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _category.EditCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _category.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
