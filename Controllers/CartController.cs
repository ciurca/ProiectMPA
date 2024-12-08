using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMPA.Helpers;
using ProiectMPA.Models;
using ProiectMPA.Models.Data;
using ProiectMPA.Services;

namespace ProiectMPA.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private readonly IUserService _userService;
        private readonly ProiectMPADbContext _context;
        private const string CartSessionKey = "ShoppingCart";
        public CartController(ProiectMPADbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetCurrentUser();
            var userAddresses = await _context.DeliveryAddresses.Where(d => d.User == user).ToListAsync();
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();

            // Load MenuItem data for each OrderItem in the cart
            foreach (var item in cart)
            {
                item.MenuItem = await _context.MenuItems.FindAsync(item.MenuItemId);
            }

            var viewModel = new CartViewModel
            {
                Cart = cart,
                DeliveryAddresses = userAddresses
            };

            ViewData["DeliveryAddressId"] = new SelectList(userAddresses, "Id", "Address");

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(List<OrderItem> orderItems, int deliveryAddressId, string? specialMentions)
        {
            var user = await _userService.GetCurrentUser();
            if (orderItems == null || !orderItems.Any())
            {
                ModelState.AddModelError("", "Your cart is empty.");
                var userAddresses = await _context.DeliveryAddresses.Where(d => d.User == user).ToListAsync();
                ViewData["DeliveryAddressId"] = new SelectList(userAddresses, "Id", "Address");
                return View("Index", new CartViewModel { Cart = orderItems, DeliveryAddresses = userAddresses });
            }

            // Load MenuItem data for each OrderItem in the cart
            foreach (var item in orderItems)
            {
                item.MenuItem = await _context.MenuItems.FindAsync(item.MenuItemId);
            }

            var order = new Order
            {
                UserId = user.Id,
                DeliveryAddressId = deliveryAddressId,
                CreatedAt = DateTime.Now,
                SpecialMentions = specialMentions ?? null,
                TotalPrice = orderItems.Sum(item => item.MenuItem.Price * item.Quantity),
                OrderItems = orderItems
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(int menuItemId, int quantity)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();

            var menuItem = _context.MenuItems.Find(menuItemId);
            if (menuItem != null)
            {
                var orderItem = cart.FirstOrDefault(c => c.MenuItemId == menuItemId);
                if (orderItem == null)
                {
                    cart.Add(new OrderItem
                    {
                        MenuItemId = menuItemId,
                        MenuItem = menuItem,
                        Quantity = quantity
                    });
                }
                else
                {
                    orderItem.Quantity += quantity;
                }

                HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int menuItemId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();

            cart.RemoveAll(c => c.MenuItemId == menuItemId);

            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction("Index");
        }
    }
}
