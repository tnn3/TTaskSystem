using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebApplication.ViewModels.ProjectTaskViewModel;
using AspNetCore.Identity.Extensions;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ProjectTasksController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public ProjectTasksController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: ProjectTasks
        public async Task<IActionResult> Index(int projectId)
        {
            return View(await _uow.ProjectTasks.AllInProject(projectId));
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

        // GET: Projects/5/Tasks/Create
        public async Task<IActionResult> Create(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            var projectStatuses = await _uow.StatusInProjects.GetProjectStatuses(projectId.Value);
            if (projectStatuses == null)
            {
                return NotFound();
            }
            var vm = new ProjectTaskViewModel
            {
                StatusSelectList = new SelectList(
                    items: projectStatuses,
                    dataValueField: nameof(StatusInProject.StatusId),
                    //TODO fix display
                    dataTextField: nameof(StatusInProject.StatusId)),
                AssignedToSelectList = new SelectList(
                    await _uow.UserInProjects.AllAsync(),
                    nameof(UserInProject.UserId),
                    nameof(UserInProject.UserId)),
                PrioritySelectList = new SelectList(
                    items: await _uow.Priorities.AllAsync(),
                    dataValueField: nameof(Priority.PriorityId),
                    dataTextField: nameof(Priority.Name)),
            };
            return View(vm);
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? projectId, ProjectTaskViewModel vm)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            //TODO check projectId valid
            if (ModelState.IsValid)
            {
                vm.ProjectTask.AuthorId = int.Parse(User.GetUserId());
                vm.ProjectTask.Created = DateTime.Now;
                vm.ProjectTask.ProjectId = projectId.Value;
                
                _uow.ProjectTasks.Add(vm.ProjectTask);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            vm.StatusSelectList = new SelectList(
                items: await _uow.StatusInProjects.GetProjectStatuses(vm.ProjectTask.ProjectId),
                dataValueField: nameof(StatusInProject.StatusId),
                //TODO fix display
                dataTextField: nameof(StatusInProject.StatusId));
            vm.AssignedToSelectList = new SelectList(
                await _uow.UserInProjects.AllAsync(),
                nameof(UserInProject.UserId),
                nameof(UserInProject.UserId));
            vm.PrioritySelectList = new SelectList(
                items: await _uow.Priorities.AllAsync(),
                dataValueField: nameof(Priority.PriorityId),
                dataTextField: nameof(Priority.Name));
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

            var vm = new ProjectTaskViewModel
            {
                ProjectTask = projectTask,
                StatusSelectList = new SelectList(
                    items: await _uow.StatusInProjects.GetProjectStatuses(projectTask.ProjectId),
                    dataValueField: nameof(StatusInProject.StatusId),
                    //TODO fix display
                    dataTextField: nameof(StatusInProject.StatusId)),
                AssignedToSelectList = new SelectList(
                    await _uow.UserInProjects.AllAsync(),
                    nameof(UserInProject.UserId),
                    nameof(UserInProject.UserId)),
                PrioritySelectList = new SelectList(
                    items: await _uow.Priorities.AllAsync(),
                    dataValueField: nameof(Priority.PriorityId),
                    dataTextField: nameof(Priority.Name)),
            };
            return View(vm);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectTaskViewModel vm)
        {
            if (id != vm.ProjectTask.ProjectTaskId)
            {
                return NotFound();
            }

            var prevTask = _uow.ProjectTasks.Find(id);
            prevTask.AssignedToId = vm.ProjectTask.AssignedToId;
            prevTask.Description = vm.ProjectTask.Description;
            prevTask.Name = vm.ProjectTask.Name;
            prevTask.DueDate = vm.ProjectTask.DueDate;
            prevTask.PriorityId = vm.ProjectTask.PriorityId;
            prevTask.StatusId = vm.ProjectTask.StatusId;

            if (ModelState.IsValid)
            {
                try
                {
                    prevTask.Changed = DateTime.Now;
                    _uow.ProjectTasks.Update(prevTask);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskExistsAsync(vm.ProjectTask.ProjectTaskId))
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

            vm.StatusSelectList = new SelectList(
                items: await _uow.StatusInProjects.GetProjectStatuses(vm.ProjectTask.ProjectId),
                dataValueField: nameof(StatusInProject.StatusId),
                //TODO fix display
                dataTextField: nameof(StatusInProject.StatusId));
            vm.AssignedToSelectList = new SelectList(
                await _uow.UserInProjects.AllAsync(),
                nameof(UserInProject.UserId),
                nameof(UserInProject.UserId));
            vm.PrioritySelectList = new SelectList(
                items: await _uow.Priorities.AllAsync(),
                dataValueField: nameof(Priority.PriorityId),
                dataTextField: nameof(Priority.Name));

            return View(vm);
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
