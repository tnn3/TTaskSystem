using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserTitleInProjectsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public UserTitleInProjectsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;    
        }

        // GET: UserTitleInProjects
        public async Task<IActionResult> Index(int? projectId)
        {
            if (projectId == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(await _uow.UserTitleInProjects.AllProjectsAsync(projectId.Value));
        }

        // GET: UserTitleInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userTitleInProject = await _uow.UserTitleInProjects.FindAsyncWithIncludes(id.Value);
            if (userTitleInProject == null)
            {
                return NotFound();
            }

            return View(userTitleInProject);
        }

        // GET: UserTitleInProjects/Create
        public async Task<IActionResult> Create()
        {
            var vm = new UserTitleInProjectCreateEditViewModel()
            {
                TitleSelectList = new SelectList(
                    items: await _uow.UserTitles.AllAsync(),
                    dataValueField: nameof(UserTitle.UserTitleId),
                    dataTextField: nameof(UserTitle.Title))
            };

            return View(vm);
        }

        // POST: UserTitleInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTitleInProjectCreateEditViewModel vm, int? projectId)
        {
            if (projectId == null || !_uow.Projects.Exists(projectId.Value))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                vm.UserTitleInProject.ProjectId = projectId.Value;
                _uow.UserTitleInProjects.Add(vm.UserTitleInProject);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            vm.TitleSelectList = new SelectList(
                items: await _uow.UserTitles.AllAsync(),
                dataValueField: nameof(UserTitle.UserTitleId),
                dataTextField: nameof(UserTitle.Title),
                selectedValue: vm.UserTitleInProject.TitleId);
            return View(vm);
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

            var vm = new UserTitleInProjectCreateEditViewModel()
            {
                UserTitleInProject = userTitleInProject,

                TitleSelectList = new SelectList(
                    items: await _uow.UserTitles.AllAsync(),
                    dataValueField: nameof(UserTitle.UserTitleId),
                    dataTextField: nameof(UserTitle.Title))
            };

            return View(vm);
        }

        // POST: UserTitleInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserTitleInProjectCreateEditViewModel vm, int? projectId)
        {
            if (id != vm.UserTitleInProject.UserTitleInProjectId || projectId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.UserTitleInProject.ProjectId = projectId.Value;
                    _uow.UserTitleInProjects.Update(vm.UserTitleInProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTitleInProjectExistsAsync(vm.UserTitleInProject.UserTitleInProjectId))
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

            vm.TitleSelectList = new SelectList(
                items: await _uow.UserTitles.AllAsync(),
                dataValueField: nameof(UserTitle.UserTitleId),
                dataTextField: nameof(UserTitle.Title),
                selectedValue: vm.UserTitleInProject.TitleId);

            return View(vm);
        }

        // GET: UserTitleInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
