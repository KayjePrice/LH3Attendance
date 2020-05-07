using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.ViewModels;

namespace web.Controllers
{
    public class TrailController : Controller
    {
        private readonly Context _context;

        public TrailController(Context context)
        {
            _context = context;
        }

        // GET: Trail
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trails.ToListAsync());
        }

        // GET: Trail/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trail = await _context.Trails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trail == null)
            {
                return NotFound();
            }

            return View(trail);
        }

        // GET: Trail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date")] Trail trail)
        {
            if (ModelState.IsValid)
            {
                trail.Id = Guid.NewGuid();
                _context.Add(trail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trail);
        }

        // GET: Trail/Edit/5
  
  public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trail = await _context.Trails.Include(x => x.HasherTrails).ThenInclude(x => x.Hasher).Where(x => x.Id == id).Select(x => new TrailEditViewModel { Id = x.Id, Date = x.Date, HasherIds = x.HasherTrails.Select(z => z.HasherId).ToList() }).FirstOrDefaultAsync();
            if (trail == null)
            {
                return NotFound();
            }
            ViewData["HasherIds"] = new SelectList(_context.Hashers, "Id", "HashName", trail.HasherIds ?? new List<Guid>());
            return View(trail);

        }

        // POST: Trail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: Trail/Delete/5
[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TrailEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var trail = await _context.Trails.FindAsync(vm.Id);
                    trail.HasherTrails = vm.HasherIds.Select(e => new HasherTrail { HasherId = e }).ToList();
                    _context.Update(trail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrailExists(vm.Id))
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
            return View(vm);
        }

        // POST: Trail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var trail = await _context.Trails.FindAsync(id);
            _context.Trails.Remove(trail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrailExists(Guid id)
        {
            return _context.Trails.Any(e => e.Id == id);
        }
    }
}
