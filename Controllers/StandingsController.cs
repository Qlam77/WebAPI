using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLiteWeb.Data;
using SQLiteWeb.Models;

namespace SQLiteWeb.Controllers
{
    public class StandingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StandingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Standings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Standings.ToListAsync());
        }

        // GET: Standings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings
                .SingleOrDefaultAsync(m => m.StandingsId == id);
            if (standings == null)
            {
                return NotFound();
            }

            return View(standings);
        }

        // GET: Standings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Standings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StandingsId,Rank,Country,Gold,Silver,Bronze,Total")] Standings standings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(standings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(standings);
        }

        // GET: Standings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings.SingleOrDefaultAsync(m => m.StandingsId == id);
            if (standings == null)
            {
                return NotFound();
            }
            return View(standings);
        }

        // POST: Standings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StandingsId,Rank,Country,Gold,Silver,Bronze,Total")] Standings standings)
        {
            if (id != standings.StandingsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(standings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StandingsExists(standings.StandingsId))
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
            return View(standings);
        }

        // GET: Standings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var standings = await _context.Standings
                .SingleOrDefaultAsync(m => m.StandingsId == id);
            if (standings == null)
            {
                return NotFound();
            }

            return View(standings);
        }

        // POST: Standings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var standings = await _context.Standings.SingleOrDefaultAsync(m => m.StandingsId == id);
            _context.Standings.Remove(standings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StandingsExists(int id)
        {
            return _context.Standings.Any(e => e.StandingsId == id);
        }
    }
}
