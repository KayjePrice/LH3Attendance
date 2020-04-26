using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class HasherController : Controller
    {
        private readonly Context _context;

        public HasherController(Context context)
        {
            _context = context;
        }

        // GET: Hasher
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hashers.ToListAsync());
        }

        // GET: Hasher/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasher = await _context.Hashers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasher == null)
            {
                return NotFound();
            }

            return View(hasher);
        }

        // GET: Hasher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hasher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HashName,FirstName,LastName,City")] Hasher hasher)
        {
            if (ModelState.IsValid)
            {
                hasher.Id = Guid.NewGuid();
                _context.Add(hasher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hasher);
        }

        // GET: Hasher/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasher = await _context.Hashers.FindAsync(id);
            if (hasher == null)
            {
                return NotFound();
            }
            return View(hasher);
        }

        // POST: Hasher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,HashName,FirstName,LastName,City")] Hasher hasher)
        {
            if (id != hasher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hasher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HasherExists(hasher.Id))
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
            return View(hasher);
        }

        // GET: Hasher/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hasher = await _context.Hashers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hasher == null)
            {
                return NotFound();
            }

            return View(hasher);
        }

        // POST: Hasher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hasher = await _context.Hashers.FindAsync(id);
            _context.Hashers.Remove(hasher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HasherExists(Guid id)
        {
            return _context.Hashers.Any(e => e.Id == id);
        }
    }
}
