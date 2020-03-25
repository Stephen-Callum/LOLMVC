using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LOLMVC;

namespace LOLMVC.Controllers
{
    public class ChampStatsController : Controller
    {
        private readonly LOLDBContext _context;

        public ChampStatsController(LOLDBContext context)
        {
            _context = context;
        }

        // GET: ChampStats
        public async Task<IActionResult> Index()
        {
            var lOLDBContext = _context.ChampStat.Include(c => c.Champ);
            return View(await lOLDBContext.ToListAsync());
        }

        // GET: ChampStats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champStat = await _context.ChampStat
                .Include(c => c.Champ)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (champStat == null)
            {
                return NotFound();
            }

            return View(champStat);
        }

        // GET: ChampStats/Create
        public IActionResult Create()
        {
            ViewData["ChampId"] = new SelectList(_context.Champion, "ChampId", "ChampId");
            return View();
        }

        // POST: ChampStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatId,ChampId,WinRate,PickRate,BanRate,Tier,LanePlayed")] ChampStat champStat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(champStat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampId"] = new SelectList(_context.Champion, "ChampId", "ChampId", champStat.ChampId);
            return View(champStat);
        }

        // GET: ChampStats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champStat = await _context.ChampStat.FindAsync(id);
            if (champStat == null)
            {
                return NotFound();
            }
            ViewData["ChampId"] = new SelectList(_context.Champion, "ChampId", "ChampId", champStat.ChampId);
            return View(champStat);
        }

        // POST: ChampStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatId,ChampId,WinRate,PickRate,BanRate,Tier,LanePlayed")] ChampStat champStat)
        {
            if (id != champStat.StatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(champStat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampStatExists(champStat.StatId))
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
            ViewData["ChampId"] = new SelectList(_context.Champion, "ChampId", "ChampId", champStat.ChampId);
            return View(champStat);
        }

        // GET: ChampStats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var champStat = await _context.ChampStat
                .Include(c => c.Champ)
                .FirstOrDefaultAsync(m => m.StatId == id);
            if (champStat == null)
            {
                return NotFound();
            }

            return View(champStat);
        }

        // POST: ChampStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var champStat = await _context.ChampStat.FindAsync(id);
            _context.ChampStat.Remove(champStat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampStatExists(int id)
        {
            return _context.ChampStat.Any(e => e.StatId == id);
        }
    }
}
