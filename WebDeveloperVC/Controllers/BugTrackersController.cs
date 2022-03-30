#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDeveloperDataLayer.Model;
using WebDeveloperVC.Data;

namespace WebDeveloperVC.Controllers
{
    public class BugTrackersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BugTrackersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BugTrackers
        public async Task<IActionResult> Index()
        {
            return View(await _context.BugTracker.ToListAsync());
        }

        // GET: BugTrackers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTracker = await _context.BugTracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugTracker == null)
            {
                return NotFound();
            }

            return View(bugTracker);
        }

        // GET: BugTrackers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BugTrackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] BugTracker bugTracker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugTracker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugTracker);
        }

        // GET: BugTrackers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTracker = await _context.BugTracker.FindAsync(id);
            if (bugTracker == null)
            {
                return NotFound();
            }
            return View(bugTracker);
        }

        // POST: BugTrackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] BugTracker bugTracker)
        {
            if (id != bugTracker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugTracker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugTrackerExists(bugTracker.Id))
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
            return View(bugTracker);
        }

        // GET: BugTrackers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugTracker = await _context.BugTracker
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bugTracker == null)
            {
                return NotFound();
            }

            return View(bugTracker);
        }

        // POST: BugTrackers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugTracker = await _context.BugTracker.FindAsync(id);
            _context.BugTracker.Remove(bugTracker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugTrackerExists(int id)
        {
            return _context.BugTracker.Any(e => e.Id == id);
        }
    }
}
