using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasketBD.Models.Data;

namespace BasketBD.Controllers
{
    public class ItemsController : Controller
    {
        private readonly BasketBDContext _context;

        public ItemsController(BasketBDContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var basketBDContext = _context.Items.Include(i => i.Brand).Include(i => i.CategoryNavigation).Include(i => i.Supplier);
            return View(await basketBDContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.CategoryNavigation)
                .Include(i => i.Supplier)
                .SingleOrDefaultAsync(m => m.ItemCode == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId");
            ViewData["Category"] = new SelectList(_context.Category, "CategoryName", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCode,ItemName,Category,SubCategory,SupplierId,BrandId,PurchasePrice,SalePrice,EexpireDate,SlideTitle,NewArrivalTitle,Picture")] Items items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", items.BrandId);
            ViewData["Category"] = new SelectList(_context.Category, "CategoryName", "CategoryName", items.Category);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", items.SupplierId);
            return View(items);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.SingleOrDefaultAsync(m => m.ItemCode == id);
            if (items == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", items.BrandId);
            ViewData["Category"] = new SelectList(_context.Category, "CategoryName", "CategoryName", items.Category);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", items.SupplierId);
            return View(items);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ItemCode,ItemName,Category,SubCategory,SupplierId,BrandId,PurchasePrice,SalePrice,EexpireDate,SlideTitle,NewArrivalTitle,Picture")] Items items)
        {
            if (id != items.ItemCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.ItemCode))
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
            ViewData["BrandId"] = new SelectList(_context.Brand, "BrandId", "BrandId", items.BrandId);
            ViewData["Category"] = new SelectList(_context.Category, "CategoryName", "CategoryName", items.Category);
            ViewData["SupplierId"] = new SelectList(_context.Supplier, "SupplierId", "SupplierId", items.SupplierId);
            return View(items);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .Include(i => i.Brand)
                .Include(i => i.CategoryNavigation)
                .Include(i => i.Supplier)
                .SingleOrDefaultAsync(m => m.ItemCode == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var items = await _context.Items.SingleOrDefaultAsync(m => m.ItemCode == id);
            _context.Items.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(string id)
        {
            return _context.Items.Any(e => e.ItemCode == id);
        }
    }
}
