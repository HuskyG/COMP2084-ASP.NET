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
    public class DailySchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DailySchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DailySchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DailySchedules.Include(d => d.Activities).Include(d => d.TripSchedule);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DailySchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailySchedule = await _context.DailySchedules
                .Include(d => d.Activities)
                .Include(d => d.TripSchedule)
                .FirstOrDefaultAsync(m => m.DailyScheduleId == id);
            if (dailySchedule == null)
            {
                return NotFound();
            }

            return View(dailySchedule);
        }

        // GET: DailySchedules/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityName");
            ViewData["TripScheduleId"] = new SelectList(_context.TripSchedules, "TripScheduleId", "TripName");
            return View();
        }

        // POST: DailySchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyScheduleId,Date,Time,Duration,ActivityId,TripScheduleId")] DailySchedule dailySchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailySchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityName", dailySchedule.ActivityId);
            ViewData["TripScheduleId"] = new SelectList(_context.TripSchedules, "TripScheduleId", "TripName", dailySchedule.TripScheduleId);
            return View(dailySchedule);
        }

        // GET: DailySchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailySchedule = await _context.DailySchedules.FindAsync(id);
            if (dailySchedule == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityName", dailySchedule.ActivityId);
            ViewData["TripScheduleId"] = new SelectList(_context.TripSchedules, "TripScheduleId", "TripName", dailySchedule.TripScheduleId);
            return View(dailySchedule);
        }

        // POST: DailySchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyScheduleId,Date,Time,Duration,ActivityId,TripScheduleId")] DailySchedule dailySchedule)
        {
            if (id != dailySchedule.DailyScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailySchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyScheduleExists(dailySchedule.DailyScheduleId))
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
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityName", dailySchedule.ActivityId);
            ViewData["TripScheduleId"] = new SelectList(_context.TripSchedules, "TripScheduleId", "TripName", dailySchedule.TripScheduleId);
            return View(dailySchedule);
        }

        // GET: DailySchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailySchedule = await _context.DailySchedules
                .Include(d => d.Activities)
                .Include(d => d.TripSchedule)
                .FirstOrDefaultAsync(m => m.DailyScheduleId == id);
            if (dailySchedule == null)
            {
                return NotFound();
            }

            return View(dailySchedule);
        }

        // POST: DailySchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailySchedule = await _context.DailySchedules.FindAsync(id);
            _context.DailySchedules.Remove(dailySchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyScheduleExists(int id)
        {
            return _context.DailySchedules.Any(e => e.DailyScheduleId == id);
        }
    }
}
