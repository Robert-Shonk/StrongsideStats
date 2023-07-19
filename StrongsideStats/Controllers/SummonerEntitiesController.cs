using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StrongsideStats.Data;
using StrongsideStats.Models.Entities;

namespace StrongsideStats.Controllers
{
    public class SummonerEntitiesController : Controller
    {
        private readonly StrongsideStatsContext _context;

        public SummonerEntitiesController(StrongsideStatsContext context)
        {
            _context = context;
        }

        // GET: SummonerEntities
        public async Task<IActionResult> Index()
        {
              return _context.SummonerEntity != null ? 
                          View(await _context.SummonerEntity.ToListAsync()) :
                          Problem("Entity set 'StrongsideStatsContext.SummonerEntity'  is null.");
        }

        // GET: SummonerEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SummonerEntity == null)
            {
                return NotFound();
            }

            var summonerEntity = await _context.SummonerEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summonerEntity == null)
            {
                return NotFound();
            }

            return View(summonerEntity);
        }

        // GET: SummonerEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SummonerEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountId,ProfileIconId,RevisionDate,Name,SummonerId,Puuid,SummonerLevel")] SummonerEntity summonerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(summonerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(summonerEntity);
        }

        // GET: SummonerEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SummonerEntity == null)
            {
                return NotFound();
            }

            var summonerEntity = await _context.SummonerEntity.FindAsync(id);
            if (summonerEntity == null)
            {
                return NotFound();
            }
            return View(summonerEntity);
        }

        // POST: SummonerEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountId,ProfileIconId,RevisionDate,Name,SummonerId,Puuid,SummonerLevel")] SummonerEntity summonerEntity)
        {
            if (id != summonerEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(summonerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SummonerEntityExists(summonerEntity.Id))
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
            return View(summonerEntity);
        }

        // GET: SummonerEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SummonerEntity == null)
            {
                return NotFound();
            }

            var summonerEntity = await _context.SummonerEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (summonerEntity == null)
            {
                return NotFound();
            }

            return View(summonerEntity);
        }

        // POST: SummonerEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SummonerEntity == null)
            {
                return Problem("Entity set 'StrongsideStatsContext.SummonerEntity'  is null.");
            }
            var summonerEntity = await _context.SummonerEntity.FindAsync(id);
            if (summonerEntity != null)
            {
                _context.SummonerEntity.Remove(summonerEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SummonerEntityExists(int id)
        {
          return (_context.SummonerEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
