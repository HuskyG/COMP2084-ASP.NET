using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Chravel.Data;
using Chravel.Models;

namespace Chravel.Controllers
{
    public class TripSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TripSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.TripSchedules.ToListAsync());
        }

        // GET: TripSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripSchedule = await _context.TripSchedules
                .FirstOrDefaultAsync(m => m.TripScheduleId == id);
            if (tripSchedule == null)
            {
                return NotFound();
            }

            return View(tripSchedule);
        }

        // GET: TripSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripScheduleId,TripName,Duration,UserId")] TripSchedule tripSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripSchedule);
        }

        // GET: TripSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripSchedule = await _context.TripSchedules.FindAsync(id);
            if (tripSchedule == null)
            {
                return NotFound();
            }
            return View(tripSchedule);
        }

        // POST: TripSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripScheduleId,TripName,Duration,UserId")] TripSchedule tripSchedule)
        {
            if (id != tripSchedule.TripScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripScheduleExists(tripSchedule.TripScheduleId))
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
            return View(tripSchedule);
        }

        // GET: TripSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tripSchedule = await _context.TripSchedules
                .FirstOrDefaultAsync(m => m.TripScheduleId == id);
            if (tripSchedule == null)
            {
                return NotFound();
            }

            return View(tripSchedule);
        }

        // POST: TripSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tripSchedule = await _context.TripSchedules.FindAsync(id);
            _context.TripSchedules.Remove(tripSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripScheduleExists(int id)
        {
            return _context.TripSchedules.Any(e => e.TripScheduleId == id);
        }
    }
}
