using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserInProjectsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public UserInProjectsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: UserInProjects
        public async Task<IActionResult> Index(int? projectId)
        {
            if (projectId == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(await _uow.UserInProjects.AllInProject(projectId.Value));
        }

        // GET: UserInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _uow.UserInProjects.FindAsyncWithIncludes(id.Value);
            if (userInProject == null)
            {
                return NotFound();
            }

            return View(userInProject);
        }

        // GET: UserInProjects/Create
        public async Task<IActionResult> Create(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            var vm = new UserInProjectsViewModel()
            {
                UserSelectList = new SelectList(
                    items: await _uow.ApplicationUsers.AllAsync(),
                    dataValueField: nameof(ApplicationUser.IdentityUserId),
                    dataTextField: nameof(ApplicationUser.UserName)),
                TitleSelectList = new SelectList(
                    items: await _uow.UserTitleInProjects.AllProjectsAsync(projectId.Value),
                    dataValueField: nameof(UserTitleInProject.UserTitleInProjectId),
                    dataTextField: nameof(UserTitleInProject.Title) + "." + nameof(UserTitle.Title))
            };
            return View(vm);
        }

        // POST: UserInProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserInProjectsViewModel vm, int? projectId)
        {
            if (projectId == null || !_uow.Projects.Exists(projectId.Value))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                vm.UserInProject.ProjectId = projectId.Value;
                _uow.UserInProjects.Add(vm.UserInProject);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            vm.UserSelectList = new SelectList(
                items: await _uow.ApplicationUsers.AllAsync(),
                dataValueField: nameof(ApplicationUser.IdentityUserId),
                dataTextField: nameof(ApplicationUser.UserName));
            vm.TitleSelectList = new SelectList(
                items: await _uow.UserTitleInProjects.AllProjectsAsync(projectId.Value),
                dataValueField: nameof(UserTitleInProject.UserTitleInProjectId),
                dataTextField: nameof(UserTitleInProject.Title) + "." + nameof(UserTitle.Title));

            return View(vm);
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

            var vm = new UserInProjectsViewModel()
            {
                UserInProject = userInProject,
                UserSelectList = new SelectList(
                    items: await _uow.ApplicationUsers.AllAsync(),
                    dataValueField: nameof(ApplicationUser.IdentityUserId),
                    dataTextField: nameof(ApplicationUser.UserName)),
                TitleSelectList = new SelectList(
                    items: await _uow.UserTitleInProjects.AllProjectsAsync(userInProject.ProjectId),
                    dataValueField: nameof(UserTitleInProject.UserTitleInProjectId),
                    dataTextField: nameof(UserTitleInProject.Title) + "." + nameof(UserTitle.Title))
            };
            return View(vm);
        }

        // POST: UserInProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserInProjectsViewModel vm, int? projectId)
        {
            if (id != vm.UserInProject.UserInProjectId || projectId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vm.UserInProject.ProjectId = projectId.Value;
                    _uow.UserInProjects.Update(vm.UserInProject);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserInProjectExistsAsync(vm.UserInProject.UserInProjectId))
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
            vm.UserSelectList = new SelectList(
                items: await _uow.ApplicationUsers.AllAsync(),
                dataValueField: nameof(ApplicationUser.IdentityUserId),
                dataTextField: nameof(ApplicationUser.UserName));
            vm.TitleSelectList = new SelectList(
                items: await _uow.UserTitleInProjects.AllProjectsAsync(vm.UserInProject.ProjectId),
                dataValueField: nameof(UserTitleInProject.UserTitleInProjectId),
                dataTextField: nameof(UserTitleInProject) + "." + nameof(UserTitle.Title));
            return View(vm);
        }

        // GET: UserInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userInProject = await _uow.UserInProjects.FindAsyncWithIncludes(id.Value);
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
