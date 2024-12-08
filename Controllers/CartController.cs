using Microsoft.AspNetCore.Mvc;
using ProiectMPA.Helpers;
using ProiectMPA.Models;

namespace ProiectMPA.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();
            return View(cart);
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
