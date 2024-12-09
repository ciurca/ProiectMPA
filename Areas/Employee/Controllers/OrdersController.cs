using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectMPA.Models;
using ProiectMPA.Models.Data;
using ProiectMPA.Models.Enums;
using ProiectMPA.Services;

namespace ProiectMPA.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee, Admin")]
    public class OrdersController : Controller
    {
        private readonly ProiectMPADbContext _context;
        private readonly IUserService _userService;

        public OrdersController(ProiectMPADbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .Include(o => o.Statuses)
                .ThenInclude(s => s.User)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderStatusEnum status)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.MenuItem)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.GetCurrentUser();
                    if (user == null || string.IsNullOrEmpty(user.Id))
                    {
                        ModelState.AddModelError(string.Empty, "Invalid user.");
                        return View(existingOrder);
                    }

                    var newStatus = new OrderStatus
                    {
                        OrderId = existingOrder.Id,
                        Status = status,
                        Timestamp = DateTime.UtcNow,
                        UserId = user.Id
                    };

                    _context.OrderStatuses.Add(newStatus);
                    await _context.SaveChangesAsync();

                    existingOrder.Status = status;
                    _context.Update(existingOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving changes. Please try again.");
                    Console.WriteLine(ex.InnerException?.Message);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(existingOrder);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
