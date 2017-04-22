using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;
using Interfaces.UOW;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserTitleInProjectsController : Controller
    {
        private readonly IUOW _uow;

        public UserTitleInProjectsController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: UserTitleInProjects
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.UserTitleInProjects.Include(u => u.Project).Include(u => u.Title);
            return View(await _uow.UserTitleInProjects.AllAsync());
        }

        // GET: UserTitleInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var userTitleInProject = await _context.UserTitleInProjects
                .Include(u => u.Project)
                .Include(u => u.Title)
                .SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);*/
            var userTitleInProject = await _uow.UserTitleInProjects.FindAsync(id);
            if (userTitleInProject == null)
            {
                return NotFound();
            }

            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Create
        public IActionResult Create()
        {
            //ViewData["ProjectId"] = new SelectList(_uow.Projects., "ProjectId", "ProjectId");
            //ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId");
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
                _uow.UserTitleInProjects.Add(userTitleInProject);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            //ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitleInProject = await _uow.UserTitleInProjects.FindAsync(id.Value);
            if (userTitleInProject == null)
            {
                return NotFound();
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            //ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
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
                    _uow.UserTitleInProjects.Update(userTitleInProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTitleInProjectExistsAsync(userTitleInProject.UserTitleInProjectId))
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
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userTitleInProject.ProjectId);
            //ViewData["TitleId"] = new SelectList(_context.UserTitles, "UserTitleId", "UserTitleId", userTitleInProject.TitleId);
            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var userTitleInProject = await _context.UserTitleInProjects
                .Include(u => u.Project)
                .Include(u => u.Title)
                .SingleOrDefaultAsync(m => m.UserTitleInProjectId == id);*/
            var userTitleInProject = await _uow.UserTitleInProjects.FindAsync(id.Value);

            if (userTitleInProject == null)
            {
                return NotFound();
            }

            return View(userTitleInProject);
        }

        // POST: UserTitleInProjects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userTitleInProject = await _uow.UserTitleInProjects.FindAsync(id);
            _uow.UserTitleInProjects.Remove(userTitleInProject);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserTitleInProjectExistsAsync(int id)
        {
            return _uow.UserTitleInProjects.Find(id) != null;
        }
    }
}
