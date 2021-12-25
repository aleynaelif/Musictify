﻿using System;
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
    public class SingerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Singer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Singer.ToListAsync());
        }

        // GET: Singer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singer
                .FirstOrDefaultAsync(m => m.SingerID == id);
            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        // GET: Singer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Singer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SingerID,SingerName,Birthday,SingerAge,SingerDescription,ImageUrl")] Singer singer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(singer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(singer);
        }

        // GET: Singer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singer.FindAsync(id);
            if (singer == null)
            {
                return NotFound();
            }
            return View(singer);
        }

        // POST: Singer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SingerID,SingerName,Birthday,SingerAge,SingerDescription,ImageUrl")] Singer singer)
        {
            if (id != singer.SingerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingerExists(singer.SingerID))
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
            return View(singer);
        }

        // GET: Singer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = await _context.Singer
                .FirstOrDefaultAsync(m => m.SingerID == id);
            if (singer == null)
            {
                return NotFound();
            }

            return View(singer);
        }

        // POST: Singer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singer = await _context.Singer.FindAsync(id);
            _context.Singer.Remove(singer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SingerExists(int id)
        {
            return _context.Singer.Any(e => e.SingerID == id);
        }
    }
}
