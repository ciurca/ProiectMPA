using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.MenuItem).Where(o => o.User == user).OrderByDescending(o => o.CreatedAt).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetCurrentUser();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Statuses)
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == user.Id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
