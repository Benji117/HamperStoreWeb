using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamperStoreWeb.DataAcess.Models;

namespace HamperStoreWeb.Controllers
{
    public class HampersController : Controller
    {
        private readonly HamperStoreEntities _context;

        public HampersController(HamperStoreEntities context)
        {
            _context = context;
        }

        // GET: Hampers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hampers.ToListAsync());
        }

        // GET: Hampers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamper = await _context.Hampers
                .FirstOrDefaultAsync(m => m.HamperId == id);
            if (hamper == null)
            {
                return NotFound();
            }

            return View(hamper);
        }

        // GET: Hampers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hampers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HamperId,HamperName,TotalPrice")] Hamper hamper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hamper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hamper);
        }

        // GET: Hampers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamper = await _context.Hampers.FindAsync(id);
            if (hamper == null)
            {
                return NotFound();
            }
            return View(hamper);
        }

        // POST: Hampers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HamperId,HamperName,TotalPrice")] Hamper hamper)
        {
            if (id != hamper.HamperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hamper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HamperExists(hamper.HamperId))
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
            return View(hamper);
        }

        // GET: Hampers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamper = await _context.Hampers
                .FirstOrDefaultAsync(m => m.HamperId == id);
            if (hamper == null)
            {
                return NotFound();
            }

            return View(hamper);
        }

        // POST: Hampers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hamper = await _context.Hampers.FindAsync(id);
            _context.Hampers.Remove(hamper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HamperExists(int id)
        {
            return _context.Hampers.Any(e => e.HamperId == id);
        }
    }
}
