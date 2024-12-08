using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMPA.Models;
using ProiectMPA.Models.Data;
using ProiectMPA.Models.DTOs;
using ProiectMPA.Services;

namespace ProiectMPA.Controllers
{
    [Authorize(Roles = "User")]
    public class DeliveryAddressesController : Controller
    {
        private readonly ProiectMPADbContext _context;
        private readonly IUserService _userService;
        public DeliveryAddressesController(ProiectMPADbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: DeliveryAddresses
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetCurrentUser();

            return View(await _context.DeliveryAddresses.Where(d => d.UserId == user.Id).ToListAsync());
        }

        // GET: DeliveryAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetCurrentUser();

            var deliveryAddress = await _context.DeliveryAddresses.Include(d => d.User).Where(d => d.Id == id).FirstOrDefaultAsync();
            if (deliveryAddress == null || deliveryAddress.User.Id != user.Id)
            {
                return NotFound();
            }

            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Address")] DeliveryAddressCreateDto input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GetCurrentUser();
                var deliveryAddress = new DeliveryAddress() { UserId = user.Id, Address = input.Address, Description = input.Description };
                _context.Add(deliveryAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(input);
        }

        // GET: DeliveryAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _userService.GetCurrentUser();

            if (id == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses.Include(d => d.User).Where(d => d.Id == id).FirstOrDefaultAsync();
            if (deliveryAddress == null || deliveryAddress.User.Id != user.Id)
            {
                return NotFound();
            }
            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Description,Address")] DeliveryAddress deliveryAddress)
        {
            if (id != deliveryAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryAddressExists(deliveryAddress.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userService.GetCurrentUser();
            var deliveryAddress = await _context.DeliveryAddresses.Include(d => d.User).Where(d => d.Id == id).FirstOrDefaultAsync();
            if (deliveryAddress == null || deliveryAddress.User.Id != user.Id)
            {
                return NotFound();
            }

            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress != null)
            {
                _context.DeliveryAddresses.Remove(deliveryAddress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryAddressExists(int id)
        {
            return _context.DeliveryAddresses.Any(e => e.Id == id);
        }
    }
}
