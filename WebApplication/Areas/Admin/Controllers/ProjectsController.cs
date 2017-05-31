using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProjectsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public ProjectsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Projects.AllAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.FindAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [Authorize(Roles = "Admin")]
        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                project.CreatedOn = DateTime.Now;
                _uow.Projects.Add(project);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.FindAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,Description")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var prevProject = await _uow.Projects.FindAsync(id);
                try
                {
                    prevProject.Name = project.Name;
                    prevProject.Description = project.Description;
                    prevProject.UpdatedOn = DateTime.Now;
                    _uow.Projects.Update(prevProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_uow.Projects.Exists(project.ProjectId))
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
            return View(project);
        }

        [Authorize(Roles = "Admin")]
        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.FindAsync(id.Value);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        [Authorize(Roles = "Admin")]
        // POST: Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _uow.Projects.FindAsync(id);
            _uow.Projects.Remove(project);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}
