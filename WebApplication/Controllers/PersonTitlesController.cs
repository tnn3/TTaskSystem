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
    public class PersonTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonTitlesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PersonTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonTitles.ToListAsync());
        }

        // GET: PersonTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitle = await _context.PersonTitles
                .SingleOrDefaultAsync(m => m.PersonTitleId == id);
            if (personTitle == null)
            {
                return NotFound();
            }

            return View(personTitle);
        }

        // GET: PersonTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonTitleId,TitleName")] PersonTitle personTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personTitle);
        }

        // GET: PersonTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitle = await _context.PersonTitles.SingleOrDefaultAsync(m => m.PersonTitleId == id);
            if (personTitle == null)
            {
                return NotFound();
            }
            return View(personTitle);
        }

        // POST: PersonTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonTitleId,TitleName")] PersonTitle personTitle)
        {
            if (id != personTitle.PersonTitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonTitleExists(personTitle.PersonTitleId))
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
            return View(personTitle);
        }

        // GET: PersonTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitle = await _context.PersonTitles
                .SingleOrDefaultAsync(m => m.PersonTitleId == id);
            if (personTitle == null)
            {
                return NotFound();
            }

            return View(personTitle);
        }

        // POST: PersonTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personTitle = await _context.PersonTitles.SingleOrDefaultAsync(m => m.PersonTitleId == id);
            _context.PersonTitles.Remove(personTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonTitleExists(int id)
        {
            return _context.PersonTitles.Any(e => e.PersonTitleId == id);
        }
    }
}
