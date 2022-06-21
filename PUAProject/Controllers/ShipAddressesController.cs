using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUAProject.Models;

namespace PUAProject.Controllers
{
    public class ShipAddressesController : Controller
    {
        private readonly PUA20832Context _context;

        public ShipAddressesController(PUA20832Context context)
        {
            _context = context;
        }

        // GET: ShipAddresses
        public async Task<IActionResult> Index()
        {
              return _context.ShipAddresses != null ? 
                          View(await _context.ShipAddresses.ToListAsync()) :
                          Problem("Entity set 'PUA20832Context.ShipAddresses'  is null.");
        }

        // GET: ShipAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShipAddresses == null)
            {
                return NotFound();
            }

            var shipAddress = await _context.ShipAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipAddress == null)
            {
                return NotFound();
            }

            return View(shipAddress);
        }

        // GET: ShipAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Street,PostalCode,City,Country,Phone")] ShipAddress shipAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipAddress);
        }

        // GET: ShipAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShipAddresses == null)
            {
                return NotFound();
            }

            var shipAddress = await _context.ShipAddresses.FindAsync(id);
            if (shipAddress == null)
            {
                return NotFound();
            }
            return View(shipAddress);
        }

        // POST: ShipAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Street,PostalCode,City,Country,Phone")] ShipAddress shipAddress)
        {
            if (id != shipAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipAddressExists(shipAddress.Id))
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
            return View(shipAddress);
        }

        // GET: ShipAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShipAddresses == null)
            {
                return NotFound();
            }

            var shipAddress = await _context.ShipAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shipAddress == null)
            {
                return NotFound();
            }

            return View(shipAddress);
        }

        // POST: ShipAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShipAddresses == null)
            {
                return Problem("Entity set 'PUA20832Context.ShipAddresses'  is null.");
            }
            var shipAddress = await _context.ShipAddresses.FindAsync(id);
            if (shipAddress != null)
            {
                _context.ShipAddresses.Remove(shipAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipAddressExists(int id)
        {
          return (_context.ShipAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
