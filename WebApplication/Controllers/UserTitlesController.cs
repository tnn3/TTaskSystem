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
    public class UserTitlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTitlesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserTitles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserTitles.ToListAsync());
        }

        // GET: UserTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _context.UserTitles
                .SingleOrDefaultAsync(m => m.UserTitleId == id);
            if (userTitle == null)
            {
                return NotFound();
            }

            return View(userTitle);
        }

        // GET: UserTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTitleId,TitleName")] UserTitle userTitle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTitle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userTitle);
        }

        // GET: UserTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _context.UserTitles.SingleOrDefaultAsync(m => m.UserTitleId == id);
            if (userTitle == null)
            {
                return NotFound();
            }
            return View(userTitle);
        }

        // POST: UserTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTitleId,TitleName")] UserTitle userTitle)
        {
            if (id != userTitle.UserTitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTitleExists(userTitle.UserTitleId))
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
            return View(userTitle);
        }

        // GET: UserTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _context.UserTitles
                .SingleOrDefaultAsync(m => m.UserTitleId == id);
            if (userTitle == null)
            {
                return NotFound();
            }

            return View(userTitle);
        }

        // POST: UserTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTitle = await _context.UserTitles.SingleOrDefaultAsync(m => m.UserTitleId == id);
            _context.UserTitles.Remove(userTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserTitleExists(int id)
        {
            return _context.UserTitles.Any(e => e.UserTitleId == id);
        }
    }
}
