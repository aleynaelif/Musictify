using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musictify.Data;
using Musictify.Models;

namespace Musictify.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shop.Include(s => s.CD).Include(s => s.Vinyl);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.CD)
                .Include(s => s.Vinyl)
                .FirstOrDefaultAsync(m => m.ShopID == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            ViewData["CDID"] = new SelectList(_context.CD, "CDID", "CDName");
            ViewData["VinylID"] = new SelectList(_context.Vinyl, "VinylID", "VinylName");
            return View();
        }

        // POST: Shop/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopID,VinylID,CDID")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CDID"] = new SelectList(_context.CD, "CDID", "CDName", shop.CDID);
            ViewData["VinylID"] = new SelectList(_context.Vinyl, "VinylID", "VinylName", shop.VinylID);
            return View(shop);
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["CDID"] = new SelectList(_context.CD, "CDID", "CDName", shop.CDID);
            ViewData["VinylID"] = new SelectList(_context.Vinyl, "VinylID", "VinylName", shop.VinylID);
            return View(shop);
        }

        // POST: Shop/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopID,VinylID,CDID")] Shop shop)
        {
            if (id != shop.ShopID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.ShopID))
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
            ViewData["CDID"] = new SelectList(_context.CD, "CDID", "CDName", shop.CDID);
            ViewData["VinylID"] = new SelectList(_context.Vinyl, "VinylID", "VinylName", shop.VinylID);
            return View(shop);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop
                .Include(s => s.CD)
                .Include(s => s.Vinyl)
                .FirstOrDefaultAsync(m => m.ShopID == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // POST: Shop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shop.FindAsync(id);
            _context.Shop.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shop.Any(e => e.ShopID == id);
        }
    }
}
