using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FM_Secrets_Web_App.Data;
using FM_Secrets_Web_App.Models;

namespace FM_Secrets_Web_App.Controllers
{
    public class HairProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HairProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HairProducts
        public async Task<IActionResult> Index()
        {
              return View(await _context.HairProducts.ToListAsync());
        }

        // GET: HairProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HairProducts == null)
            {
                return NotFound();
            }

            var hairProducts = await _context.HairProducts
                .FirstOrDefaultAsync(m => m.HairProductsId == id);
            if (hairProducts == null)
            {
                return NotFound();
            }

            return View(hairProducts);
        }

        // GET: HairProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HairProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HairProductsId,HairProductsName,HairProduct_Description,HairProduct_Code,HairProduct_Quantity,HairProduct_Price")] HairProducts hairProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hairProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hairProducts);
        }

        // GET: HairProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HairProducts == null)
            {
                return NotFound();
            }

            var hairProducts = await _context.HairProducts.FindAsync(id);
            if (hairProducts == null)
            {
                return NotFound();
            }
            return View(hairProducts);
        }

        // POST: HairProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HairProductsId,HairProductsName,HairProduct_Description,HairProduct_Code,HairProduct_Quantity,HairProduct_Price")] HairProducts hairProducts)
        {
            if (id != hairProducts.HairProductsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairProductsExists(hairProducts.HairProductsId))
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
            return View(hairProducts);
        }

        // GET: HairProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HairProducts == null)
            {
                return NotFound();
            }

            var hairProducts = await _context.HairProducts
                .FirstOrDefaultAsync(m => m.HairProductsId == id);
            if (hairProducts == null)
            {
                return NotFound();
            }

            return View(hairProducts);
        }

        // POST: HairProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HairProducts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HairProducts'  is null.");
            }
            var hairProducts = await _context.HairProducts.FindAsync(id);
            if (hairProducts != null)
            {
                _context.HairProducts.Remove(hairProducts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairProductsExists(int id)
        {
          return _context.HairProducts.Any(e => e.HairProductsId == id);
        }
    }
}
