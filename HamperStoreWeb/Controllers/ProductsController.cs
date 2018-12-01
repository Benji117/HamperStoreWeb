using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamperStoreWeb.DataAcess.Models;
using HamperStoreWeb.ViewModels;

namespace HamperStoreWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HamperStoreEntities _context;

        public ProductsController(HamperStoreEntities context)
        {
            _context = context;
        }
        //Create Random number
        public string GenerateRandomNumber()
        {
            Random randomNumber = new Random();
            string r = "";
            int i;
            for (i = 1; i < 11; i++)
            {
                r += randomNumber.Next(0, 9).ToString();
            }
            return r;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var hamperStoreEntities = _context.Products.Include(p => p.Category);
            return View(await hamperStoreEntities.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            //We use A STRONGLY TYPE VIEW TO PRESENT THE CREATE GET: VIEW
            var prodCreateViewModel = new ProductCreateViewModel();
            //use a list of categories from context instead of using viewData below
            //NOT USED: ViewData["CategoryList"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            prodCreateViewModel.categoriesList = _context.Categories.ToList();
            return View(prodCreateViewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel productCreateViewModel)
        //SCAFFOLDED USED: public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductCOde,Price,Discontinued,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    ProductName = productCreateViewModel.ProductName.ToString(),
                    ProductCOde = Convert.ToInt32(GenerateRandomNumber()),
                    Discontinued = productCreateViewModel.Discontinued,
                    Price = Convert.ToDecimal(productCreateViewModel.Price)        
                };
                              
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductCOde,Price,Discontinued,CategoryId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
