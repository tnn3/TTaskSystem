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
    public class UserInProjectsController : Controller
    {
        private readonly IUOW _uow;

        public UserInProjectsController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: UserInProjects
        public async Task<IActionResult> Index()
        {
            //var uow = _uow.UserInProject.Include(u => u.Project).Include(u => u.TitleInProject);
            return View(await _uow.UserInProjects.AllAsync());
        }

        // GET: UserInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var userInProject = await _uow.UserInProjects
                .Include(u => u.Project)
                .Include(u => u.TitleInProject)
                .SingleOrDefaultAsync(m => m.UserInProjectId == id);*/
            var userInProject = await _uow.UserInProjects.FindAsync(id.Value);
            if (userInProject == null)
            {
                return NotFound();
            }

            return View(userInProject);
        }

        // GET: UserInProjects/Create
        public IActionResult Create()
        {
            //ViewData["ProjectId"] = new SelectList(_uow.Projects, "ProjectId", "ProjectId");
            //ViewData["UserTitleInProjectId"] = new SelectList(_context.UserTitleInProjects, "UserTitleInProjectId", "UserTitleInProjectId");
            return View();
        }

        // POST: UserInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserInProjectId,UserTitleInProjectId,UserId,ProjectId")] UserInProject userInProject)
        {
            if (ModelState.IsValid)
            {
                _uow.UserInProjects.Add(userInProject);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userInProject.ProjectId);
            //ViewData["UserTitleInProjectId"] = new SelectList(_context.UserTitleInProjects, "UserTitleInProjectId", "UserTitleInProjectId", userInProject.UserTitleInProjectId);
            return View(userInProject);
        }

        // GET: UserInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _uow.UserInProjects.FindAsync(id.Value);
            if (userInProject == null)
            {
                return NotFound();
            }
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userInProject.ProjectId);
            //ViewData["UserTitleInProjectId"] = new SelectList(_context.UserTitleInProjects, "UserTitleInProjectId", "UserTitleInProjectId", userInProject.UserTitleInProjectId);
            return View(userInProject);
        }

        // POST: UserInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserInProjectId,UserTitleInProjectId,UserId,ProjectId")] UserInProject userInProject)
        {
            if (id != userInProject.UserInProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.UserInProjects.Update(userInProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInProjectExistsAsync(userInProject.UserInProjectId))
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
            //ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", userInProject.ProjectId);
            //ViewData["UserTitleInProjectId"] = new SelectList(_context.UserTitleInProjects, "UserTitleInProjectId", "UserTitleInProjectId", userInProject.UserTitleInProjectId);
            return View(userInProject);
        }

        // GET: UserInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var userInProject = await _uow.UserInProjects
                .Include(u => u.Project)
                .Include(u => u.TitleInProject)
                .SingleOrDefaultAsync(m => m.UserInProjectId == id);*/
            var userInProject = await _uow.UserInProjects.FindAsync(id.Value);
            if (userInProject == null)
            {
                return NotFound();
            }

            return View(userInProject);
        }

        // POST: UserInProjects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userInProject = await _uow.UserInProjects.FindAsync(id);
            _uow.UserInProjects.Remove(userInProject);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserInProjectExistsAsync(int id)
        {
            return _uow.UserInProjects.FindAsync(id) != null;
        }
    }
}
