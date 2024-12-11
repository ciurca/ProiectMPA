using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index(string sortOrder, string searchString, int? categoryId)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCategory"] = categoryId;

            var menuItems = from m in _context.MenuItems.Include(m => m.Category)
                            select m;

            if (categoryId.HasValue)
            {
                menuItems = menuItems.Where(m => m.CategoryId == categoryId.Value);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                menuItems = menuItems.Where(m => m.Name.Contains(searchString) || m.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    menuItems = menuItems.OrderByDescending(m => m.Name);
                    break;
                case "Price":
                    menuItems = menuItems.OrderBy(m => m.Price);
                    break;
                case "price_desc":
                    menuItems = menuItems.OrderByDescending(m => m.Price);
                    break;
                default:
                    menuItems = menuItems.OrderBy(m => m.Name);
                    break;
            }

            var categories = await _context.Categories.ToListAsync();
            ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            return View(await menuItems.ToListAsync());
        }

        [Authorize(Roles = "User")]
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
