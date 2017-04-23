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
using WebApplication.Areas.Regular.ViewModels;

namespace WebApplication.Areas.Regular.Controllers
{
    [Area("Regular")]
    public class ProjectTasksController : Controller
    {
        private readonly IUOW _uow;

        public ProjectTasksController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: ProjectTasks
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ProjectTasks.AllAsync());
        }

        // GET: ProjectTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _uow.ProjectTasks.FindAsync(id.Value);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // GET: ProjectTasks/Create
        public async Task<IActionResult> Create()
        {
            var vm = new ProjectTaskViewModelCreateEdit()
            {
                StatusSelectList = new SelectList(
                    items: await _uow.Statuses.AllAsync(),
                    dataValueField: nameof(Status.StatusId),
                    dataTextField: nameof(Status.Name)),
                AssignedToSelectList = new SelectList(
                    await _uow.UserInProjects.AllAsync(),
                    nameof(UserInProject.UserId),
                    nameof(UserInProject.UserId)),
                PrioritySelectList = new SelectList(
                    items: await _uow.Priorities.AllAsync(),
                    dataValueField: nameof(Priority.PriorityId),
                    dataTextField: nameof(Priority.Name))
            };
            return View(vm);
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectTaskViewModelCreateEdit vm)
        {
            if (ModelState.IsValid)
            {
                _uow.ProjectTasks.Add(vm.ProjectTask);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: ProjectTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _uow.ProjectTasks.FindAsync(id.Value);
            if (projectTask == null)
            {
                return NotFound();
            }
            return View(projectTask);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectTaskId,TaskName,Description,DueDate,Changed")] ProjectTask projectTask)
        {
            if (id != projectTask.ProjectTaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ProjectTasks.Update(projectTask);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskExistsAsync(projectTask.ProjectTaskId))
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
            return View(projectTask);
        }

        // GET: ProjectTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _uow.ProjectTasks.FindAsync(id.Value);
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var projectTask = await _uow.ProjectTasks.FindAsync(id);
            _uow.ProjectTasks.Remove(projectTask);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectTaskExistsAsync(int id)
        {
            return _uow.ProjectTasks.Find(id) != null;
        }
    }
}
