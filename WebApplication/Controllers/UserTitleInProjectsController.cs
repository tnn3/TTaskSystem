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
    public class UserTitleInProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTitleInProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserTitleInProjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserTitleInProjects.Include(u => u.Project).Include(u => u.Title);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserTitleInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitleInProject = await _context.UserTitleInProjects
                .Include(u => u.Project)
                .Include(u => u.Title)
                .SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);
            if (userTitleInProject == null)
            {
                return NotFound();
            }

            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId");
            return View();
        }

        // POST: UserTitleInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTitleInProjectId,ProjectId,TitleId")] UserTitleInProject userTitleInProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTitleInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitleInProject = await _context.UserTitleInProjects.SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);
            if (userTitleInProject == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
            return View(userTitleInProject);
        }

        // POST: UserTitleInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTitleInProjectId,ProjectId,TitleId")] UserTitleInProject userTitleInProject)
        {
            if (id != userTitleInProject.UserTitleInProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTitleInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTitleInProjectExists(userTitleInProject.UserTitleInProjectId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitleInProject = await _context.UserTitleInProjects
                .Include(u => u.Project)
                .Include(u => u.Title)
                .SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);
            if (userTitleInProject == null)
            {
                return NotFound();
            }

            return View(userTitleInProject);
        }

        // POST: UserTitleInProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTitleInProject = await _context.UserTitleInProjects.SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);
            _context.UserTitleInProjects.Remove(userTitleInProject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserTitleInProjectExists(int id)
        {
            return _context.UserTitleInProjects.Any(e => e.UserTitleInProjectId == id);
        }
    }
}
