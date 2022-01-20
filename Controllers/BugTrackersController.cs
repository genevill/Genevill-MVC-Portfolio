using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Genevill_MVC_Portfolio.Data;
using Genevill_MVC_Portfolio.Models;

namespace Genevill_MVC_Portfolio.Controllers
{
    public class BugTrackersController : Controller
    {
        private readonly Genevill_MVC_PortfolioContext _context;

        public BugTrackersController(Genevill_MVC_PortfolioContext context)
        {
            _context = context;
        }

        // GET: BugTrackers
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["AssigneeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "assignee_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var bugs = from m in _context.BugTracker
                       select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                bugs = bugs.Where(s => s.Summary.Contains(searchString)
                    || s.Resolution.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "assignee_desc":
                    bugs = bugs.OrderByDescending(s => s.Assignee);
                    break;
                case "Date":
                    bugs = bugs.OrderBy(s => s.Created);
                    break;
                case "date_desc":
                    bugs = bugs.OrderByDescending(s => s.Created);
                    break;
                default:
                    bugs = bugs.OrderBy(s => s.Assignee);
                    break;
            }

            int pageSize = 6;
            return View(await PaginatedList<BugTracker>.CreateAsync(bugs.AsNoTracking(), pageNumber ?? 1, pageSize));
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
        public async Task<IActionResult> Create([Bind("Id,Summary,Assignee,AffectedUser,PhoneNumber,Status,Resolution,Created,Updated")] BugTracker bugTracker)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Summary,Assignee,AffectedUser,PhoneNumber,Status,Resolution,Created,Updated")] BugTracker bugTracker)
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
