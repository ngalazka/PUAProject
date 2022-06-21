﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PUAProject.Models;

namespace PUAProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly PUA20832Context _context;

        public UsersController(PUA20832Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var pUA20832Context = _context.Users.Include(u => u.Address);
            return View(await pUA20832Context.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return View("NotFound");
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.ShipAddresses, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Email,AddressId,Role,IsActive,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] User user)
        {
            //if (ModelState.IsValid)
            //}
            try
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }

            // GET: Users/Edit/5
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return View("NotFound");
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return View("NotFound");
            }
            ViewData["AddressId"] = new SelectList(_context.ShipAddresses, "Id", "Id", user.AddressId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Email,AddressId,Role,IsActive,CreatedDate,CreatedBy,LastModifiedDate,LastModifiedBy")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
           // ViewData["AddressId"] = new SelectList(_context.ShipAddresses, "Id", "Id", user.AddressId);
           // return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return View("NotFound");
            }

            var user = await _context.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return View("NotFound");
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'PUA20832Context.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
