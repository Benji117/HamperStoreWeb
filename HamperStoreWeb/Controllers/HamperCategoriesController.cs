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
    public class HamperCategoriesController : Controller
    {
        private readonly HamperStoreEntities _context;

        public HamperCategoriesController(HamperStoreEntities context)
        {
            _context = context;
        }

        // GET: HamperCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.HamperCategories.ToListAsync());
        }

        // GET: HamperCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamperCategory = await _context.HamperCategories
                .FirstOrDefaultAsync(m => m.HamperCategoryId == id);
            if (hamperCategory == null)
            {
                return NotFound();
            }

            return View(hamperCategory);
        }

        // GET: HamperCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HamperCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HamperCategoryId,HamperCategoryName,Description,Discontinued")] HamperCategory hamperCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hamperCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hamperCategory);
        }

        // GET: HamperCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamperCategory = await _context.HamperCategories.FindAsync(id);
            if (hamperCategory == null)
            {
                return NotFound();
            }
            return View(hamperCategory);
        }

        // POST: HamperCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HamperCategoryId,HamperCategoryName,Description,Discontinued")] HamperCategory hamperCategory)
        {
            if (id != hamperCategory.HamperCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hamperCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HamperCategoryExists(hamperCategory.HamperCategoryId))
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
            return View(hamperCategory);
        }

        // GET: HamperCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hamperCategory = await _context.HamperCategories
                .FirstOrDefaultAsync(m => m.HamperCategoryId == id);
            if (hamperCategory == null)
            {
                return NotFound();
            }

            return View(hamperCategory);
        }

        // POST: HamperCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hamperCategory = await _context.HamperCategories.FindAsync(id);
            _context.HamperCategories.Remove(hamperCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HamperCategoryExists(int id)
        {
            return _context.HamperCategories.Any(e => e.HamperCategoryId == id);
        }
    }
}
