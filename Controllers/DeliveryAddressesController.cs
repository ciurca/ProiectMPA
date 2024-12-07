using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMPA.Models;
using ProiectMPA.Models.Data;

namespace ProiectMPA.Controllers
{
    public class DeliveryAddressesController : Controller
    {
        private readonly ProiectMPADbContext _context;

        public DeliveryAddressesController(ProiectMPADbContext context)
        {
            _context = context;
        }

        // GET: DeliveryAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryAddresses.ToListAsync());
        }

        // GET: DeliveryAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAddress == null)
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
        public async Task<IActionResult> Create([Bind("Id,UserId,Description,Address")] DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAddress = await _context.DeliveryAddresses.FindAsync(id);
            if (deliveryAddress == null)
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

            var deliveryAddress = await _context.DeliveryAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryAddress == null)
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
