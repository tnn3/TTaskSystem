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
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StatusInProjectsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public StatusInProjectsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Admin/StatusInProjects
        public async Task<IActionResult> Index()
        {
            return View(await _uow.StatusInProjects.AllAsyncWithIncludes());
        }

        // GET: Admin/StatusInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInProject = await _uow.StatusInProjects.FindAsyncWithIncludes(id.Value);
            if (statusInProject == null)
            {
                return NotFound();
            }

            return View(statusInProject);
        }

        // GET: Admin/StatusInProjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new StatusInProjectsCreateEditViewModel()
            {
                ProjectSelectList = new SelectList(
                    items: await _uow.Projects.AllAsync(),
                    dataValueField: nameof(Project.ProjectId),
                    dataTextField: nameof(Project.Name)),
                StatusSelectList = new SelectList(
                    items: await _uow.Statuses.AllAsync(),
                    dataValueField: nameof(Status.StatusId),
                    dataTextField: nameof(Status.Name))
            };
            return View(vm);
        }

        // POST: Admin/StatusInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusInProjectsCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.StatusInProjects.Add(vm.StatusInProject);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            vm.ProjectSelectList = new SelectList(
                items: await _uow.Projects.AllAsync(),
                dataValueField: nameof(Project.ProjectId),
                dataTextField: nameof(Project.Name));
            vm.StatusSelectList = new SelectList(
                items: await _uow.Statuses.AllAsync(),
                dataValueField: nameof(Status.StatusId),
                dataTextField: nameof(Status.Name));

            return View(vm);
        }

        // GET: Admin/StatusInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInProject = await _uow.StatusInProjects.FindAsync(id.Value);
            if (statusInProject == null)
            {
                return NotFound();
            }
            var vm = new StatusInProjectsCreateEditViewModel()
            {
                StatusInProject = statusInProject,

                ProjectSelectList = new SelectList(
                    items: await _uow.Projects.AllAsync(),
                    dataValueField: nameof(Project.ProjectId),
                    dataTextField: nameof(Project.Name)),
                StatusSelectList = new SelectList(
                    items: await _uow.Statuses.AllAsync(),
                    dataValueField: nameof(Status.StatusId),
                    dataTextField: nameof(Status.Name))
            };
            return View(vm);
        }

        // POST: Admin/StatusInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StatusInProjectsCreateEditViewModel vm)
        {
            if (id != vm.StatusInProject.StatusInProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.StatusInProjects.Update(vm.StatusInProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusInProjectExistsAsync(vm.StatusInProject.StatusInProjectId))
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

            vm.ProjectSelectList = new SelectList(
                items: await _uow.Projects.AllAsync(),
                dataValueField: nameof(Project.ProjectId),
                dataTextField: nameof(Project.Name));
            vm.StatusSelectList = new SelectList(
                items: await _uow.Statuses.AllAsync(),
                dataValueField: nameof(Status.StatusId),
                dataTextField: nameof(Status.Name));

            return View(vm);
        }

        // GET: Admin/StatusInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusInProject = await _uow.StatusInProjects.FindAsyncWithIncludes(id.Value);
            if (statusInProject == null)
            {
                return NotFound();
            }

            return View(statusInProject);
        }

        // POST: Admin/StatusInProjects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var statusInProject = await _uow.StatusInProjects.FindAsync(id);
            _uow.StatusInProjects.Remove(statusInProject);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StatusInProjectExistsAsync(int id)
        {
            return _uow.StatusInProjects.FindAsync(id) != null;
        }
    }

}
