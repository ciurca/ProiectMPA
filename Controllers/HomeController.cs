using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using ProiectMPA.Helpers;
using ProiectMPA.Models;
using ProiectMPA.Models.Data;

namespace ProiectMPA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProiectMPADbContext _context;

        private const string CartSessionKey = "ShoppingCart";

        public HomeController(ILogger<HomeController> logger, ProiectMPADbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var proiectMPADbContext = _context.Categories.Include(c => c.MenuItems);
            return View(await proiectMPADbContext.ToListAsync());
        }

        public IActionResult AddToCart(int menuItemId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();

            var menuItem = _context.MenuItems.Find(menuItemId);

            var cartItem = cart.Find(c => c.MenuItemId == menuItemId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
                TempData["SuccessMessage"] = $"Updated the quantity of {menuItem.Name}. Current quantity is {cartItem.Quantity}.";
            }
            else
            {
                cart.Add(new OrderItem
                {
                    MenuItemId = menuItemId,
                    MenuItem = menuItem,
                    Quantity = 1
                });
                TempData["SuccessMessage"] = $"Successfully added {menuItem.Name} to the cart.";
            }

            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);


            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
