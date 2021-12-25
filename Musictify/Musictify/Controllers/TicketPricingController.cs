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
    public class TicketPricingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketPricingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketPricing
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketPricings.ToListAsync());
        }

        // GET: TicketPricing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPricing = await _context.TicketPricings
                .FirstOrDefaultAsync(m => m.TicketPricingID == id);
            if (ticketPricing == null)
            {
                return NotFound();
            }

            return View(ticketPricing);
        }

        // GET: TicketPricing/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketPricing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketPricingID,VipPrice,BackstagePrice,EarlyBirdPrice,NormalPrice")] TicketPricing ticketPricing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPricing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPricing);
        }

        // GET: TicketPricing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPricing = await _context.TicketPricings.FindAsync(id);
            if (ticketPricing == null)
            {
                return NotFound();
            }
            return View(ticketPricing);
        }

        // POST: TicketPricing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketPricingID,VipPrice,BackstagePrice,EarlyBirdPrice,NormalPrice")] TicketPricing ticketPricing)
        {
            if (id != ticketPricing.TicketPricingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketPricing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPricingExists(ticketPricing.TicketPricingID))
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
            return View(ticketPricing);
        }

        // GET: TicketPricing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPricing = await _context.TicketPricings
                .FirstOrDefaultAsync(m => m.TicketPricingID == id);
            if (ticketPricing == null)
            {
                return NotFound();
            }

            return View(ticketPricing);
        }

        // POST: TicketPricing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketPricing = await _context.TicketPricings.FindAsync(id);
            _context.TicketPricings.Remove(ticketPricing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketPricingExists(int id)
        {
            return _context.TicketPricings.Any(e => e.TicketPricingID == id);
        }
    }
}
