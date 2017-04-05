using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Controllers
{
    public class ChangesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChangesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Changes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Changes.ToListAsync());
        }

        // GET: Changes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _context.Changes
                .SingleOrDefaultAsync(m => m.ChangeId == id);
            if (change == null)
            {
                return NotFound();
            }

            return View(change);
        }

        // GET: Changes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeId,Before,After")] Change change)
        {
            if (ModelState.IsValid)
            {
                _context.Add(change);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(change);
        }

        // GET: Changes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _context.Changes.SingleOrDefaultAsync(m => m.ChangeId == id);
            if (change == null)
            {
                return NotFound();
            }
            return View(change);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeId,Before,After")] Change change)
        {
            if (id != change.ChangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(change);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeExists(change.ChangeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(change);
        }

        // GET: Changes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _context.Changes
                .SingleOrDefaultAsync(m => m.ChangeId == id);
            if (change == null)
            {
                return NotFound();
            }

            return View(change);
        }

        // POST: Changes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var change = await _context.Changes.SingleOrDefaultAsync(m => m.ChangeId == id);
            _context.Changes.Remove(change);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChangeExists(int id)
        {
            return _context.Changes.Any(e => e.ChangeId == id);
        }
    }
}
