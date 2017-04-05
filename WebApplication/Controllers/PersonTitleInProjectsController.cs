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
    public class PersonTitleInProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonTitleInProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PersonTitleInProjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonTitleInProjects.Include(p => p.Project).Include(p => p.Title);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonTitleInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitleInProject = await _context.PersonTitleInProjects
                .Include(p => p.Project)
                .Include(p => p.Title)
                .SingleOrDefaultAsync(m => m.PersonTitleInProjectId == id);
            if (personTitleInProject == null)
            {
                return NotFound();
            }

            return View(personTitleInProject);
        }

        // GET: PersonTitleInProjects/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["TitleId"] = new SelectList(_context.PersonTitles, "PersonTitleId", "PersonTitleId");
            return View();
        }

        // POST: PersonTitleInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonTitleInProjectId,ProjectId,TitleId")] PersonTitleInProject personTitleInProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personTitleInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", personTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.PersonTitles, "PersonTitleId", "PersonTitleId", personTitleInProject.TitleId);
            return View(personTitleInProject);
        }

        // GET: PersonTitleInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitleInProject = await _context.PersonTitleInProjects.SingleOrDefaultAsync(m => m.PersonTitleInProjectId == id);
            if (personTitleInProject == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", personTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.PersonTitles, "PersonTitleId", "PersonTitleId", personTitleInProject.TitleId);
            return View(personTitleInProject);
        }

        // POST: PersonTitleInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonTitleInProjectId,ProjectId,TitleId")] PersonTitleInProject personTitleInProject)
        {
            if (id != personTitleInProject.PersonTitleInProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personTitleInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonTitleInProjectExists(personTitleInProject.PersonTitleInProjectId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", personTitleInProject.ProjectId);
            ViewData["TitleId"] = new SelectList(_context.PersonTitles, "PersonTitleId", "PersonTitleId", personTitleInProject.TitleId);
            return View(personTitleInProject);
        }

        // GET: PersonTitleInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personTitleInProject = await _context.PersonTitleInProjects
                .Include(p => p.Project)
                .Include(p => p.Title)
                .SingleOrDefaultAsync(m => m.PersonTitleInProjectId == id);
            if (personTitleInProject == null)
            {
                return NotFound();
            }

            return View(personTitleInProject);
        }

        // POST: PersonTitleInProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personTitleInProject = await _context.PersonTitleInProjects.SingleOrDefaultAsync(m => m.PersonTitleInProjectId == id);
            _context.PersonTitleInProjects.Remove(personTitleInProject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonTitleInProjectExists(int id)
        {
            return _context.PersonTitleInProjects.Any(e => e.PersonTitleInProjectId == id);
        }
    }
}
