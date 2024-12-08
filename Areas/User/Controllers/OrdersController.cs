using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProiectMPA.Models.Data;
using ProiectMPA.Services;

namespace ProiectMPA.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "User")]
    public class OrdersController : Controller
    {
        private readonly ProiectMPADbContext _context;
        private readonly IUserService _userService;

        public OrdersController(ProiectMPADbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userService.GetCurrentUser();
            return View(_context.Orders.Where(o => o.User == user).ToList());
        }
    }
}
