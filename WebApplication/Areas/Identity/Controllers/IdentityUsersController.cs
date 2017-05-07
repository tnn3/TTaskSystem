using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.Uow.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCore.Identity.Uow.Models;
using DAL;
using DAL.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Areas.Identity.ViewModels;

namespace WebApplication.Areas.Identity.Controllers
{
    [Area(areaName: "Identity")]
    [Authorize(Roles = "Admin")]
    public class IdentityUsersController : Controller
    {
        private readonly IIdentityUnitOfWork<ApplicationUser> _uow;

        public IdentityUsersController(IIdentityUnitOfWork<ApplicationUser> uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> ManageRoles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUser = await _uow.IdentityUsers.FindByIdIncludeRolesAsync(userId: id.Value);
            if (identityUser == null)
            {
                return NotFound();
            }

            var vm = new IdentityUsersManageRolesViewModel();
            vm.IdentityUser = identityUser;
            vm.AllRoles = await _uow.IdentityRoles.AllAsync();

            return View(model: vm);
        }

        // GET: Identity/IdentityUsers
        public async Task<IActionResult> Index()
        {
            return View(model: await _uow.IdentityUsers.AllIncludeRolesAsync());
        }

        // GET: Identity/IdentityUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUser = await _uow.IdentityUsers.FindByIdIncludeRolesAsync(userId: id.Value);
            if (identityUser == null)
            {
                return NotFound();
            }

            return View(model: identityUser);
        }

        // GET: Identity/IdentityUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Identity/IdentityUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser identityUser)
        {
            if (ModelState.IsValid)
            {
                _uow.IdentityUsers.Add(entity: identityUser);
                await _uow.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(model: identityUser);
        }

        // GET: Identity/IdentityUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUser = await _uow.IdentityUsers.FindAsync(id.Value);
            if (identityUser == null)
            {
                return NotFound();
            }
            return View(model: identityUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUser identityUser)
        {
            if (id != identityUser.IdentityUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.IdentityUsers.Update(entity: identityUser);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityUserExists(id: identityUser.IdentityUserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(model: identityUser);
        }

        // GET: Identity/IdentityUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUser = await _uow.IdentityUsers.FindByIdIncludeRolesAsync(userId: id.Value);
            if (identityUser == null)
            {
                return NotFound();
            }

            return View(model: identityUser);
        }

        // POST: Identity/IdentityUsers/Delete/5
        [HttpPost, ActionName(name: "Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _uow.IdentityUsers.Remove(id);
            await _uow.SaveChangesAsync();
            return RedirectToAction(actionName: nameof(Index));
        }

        private bool IdentityUserExists(int id)
        {
            return _uow.IdentityUsers.Exists(id: id);
        }
    }
}
