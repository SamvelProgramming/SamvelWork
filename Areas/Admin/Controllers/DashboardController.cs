using AramatBags.Data;
using AramatBags.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
namespace AramatBags.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDBContext _dbcontext;

        public DashBoardController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDBContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbcontext = db;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login", "User", new { area = "" });
        }

    }
}
