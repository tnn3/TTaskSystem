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
    public class CustomFieldInProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomFieldInProjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CustomFieldInProjects
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomFieldInProjects.Include(c => c.CustomField).Include(c => c.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomFieldInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldInProject = await _context.CustomFieldInProjects
                .Include(c => c.CustomField)
                .Include(c => c.Project)
                .SingleOrDefaultAsync(m => m.CustomFieldInProjectId == id);
            if (customFieldInProject == null)
            {
                return NotFound();
            }

            return View(customFieldInProject);
        }

        // GET: CustomFieldInProjects/Create
        public IActionResult Create()
        {
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: CustomFieldInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFieldInProjectId,ProjectId,CustomFieldId")] CustomFieldInProject customFieldInProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFieldInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldInProject.CustomFieldId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", customFieldInProject.ProjectId);
            return View(customFieldInProject);
        }

        // GET: CustomFieldInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldInProject = await _context.CustomFieldInProjects.SingleOrDefaultAsync(m => m.CustomFieldInProjectId == id);
            if (customFieldInProject == null)
            {
                return NotFound();
            }
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldInProject.CustomFieldId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", customFieldInProject.ProjectId);
            return View(customFieldInProject);
        }

        // POST: CustomFieldInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFieldInProjectId,ProjectId,CustomFieldId")] CustomFieldInProject customFieldInProject)
        {
            if (id != customFieldInProject.CustomFieldInProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customFieldInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFieldInProjectExists(customFieldInProject.CustomFieldInProjectId))
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
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldInProject.CustomFieldId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", customFieldInProject.ProjectId);
            return View(customFieldInProject);
        }

        // GET: CustomFieldInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldInProject = await _context.CustomFieldInProjects
                .Include(c => c.CustomField)
                .Include(c => c.Project)
                .SingleOrDefaultAsync(m => m.CustomFieldInProjectId == id);
            if (customFieldInProject == null)
            {
                return NotFound();
            }

            return View(customFieldInProject);
        }

        // POST: CustomFieldInProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customFieldInProject = await _context.CustomFieldInProjects.SingleOrDefaultAsync(m => m.CustomFieldInProjectId == id);
            _context.CustomFieldInProjects.Remove(customFieldInProject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFieldInProjectExists(int id)
        {
            return _context.CustomFieldInProjects.Any(e => e.CustomFieldInProjectId == id);
        }
    }
}
