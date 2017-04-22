using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Areas.Identity.ViewModels;

namespace WebApplication.Areas.Identity.Controllers
{
    [Area(areaName: "Identity")]
    public class UserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Identity/UserRoles
        public async Task<IActionResult> Index()
        {
            var vm = new UserRolesIndexViewModel();

            var roles = _context.UserRoles;
            foreach (var identityUserRole in roles)
            {
                vm.UserRoles.Add(
                    item: new UserRole()
                    {
                        IdentityUser = _context.Users.Find(identityUserRole.UserId),
                        IdentityRole = _context.Roles.Find(identityUserRole.RoleId)
                    }
                );
            }
            return View(model: vm);
        }


        // GET: Identity/UserRoles/Details/5
        public async Task<IActionResult> Details(string userId, string roleId)
        {
            if (userId == null || roleId == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles
                .SingleOrDefaultAsync(predicate: m => m.UserId == userId && m.RoleId == roleId);
            if (userRole == null)
            {
                return NotFound();
            }

            return View(model: userRole);
        }

        // GET: Identity/UserRoles/Create
        public IActionResult Create()
        {
            var vm = new UserRolesCreateEditViewModel()
            {
                UserSelectList = new SelectList(
                    items: _context.Users,
                    dataValueField: nameof(ApplicationUser.Id),
                    dataTextField: nameof(ApplicationUser.Email)),
                RoleSelectList = new SelectList(
                    items: _context.Roles,
                    dataValueField: nameof(IdentityRole.Id),
                    dataTextField: nameof(IdentityRole.Name))
            };

            return View(model: vm);
        }

        // POST: Identity/UserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserRolesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entity: vm.IdentityUserRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(actionName: "Index");
            }

            vm.UserSelectList = new SelectList(
                items: _context.Users,
                dataValueField: nameof(ApplicationUser.Id),
                dataTextField: nameof(ApplicationUser.Email),
                selectedValue: vm.IdentityUserRole.UserId);

            vm.RoleSelectList = new SelectList(
                items: _context.Roles,
                dataValueField: nameof(IdentityRole.Id),
                dataTextField: nameof(IdentityRole.Name),
                selectedValue: vm.IdentityUserRole.RoleId);

            return View(model: vm);
        }

        // GET: Identity/UserRoles/Edit/5
        public async Task<IActionResult> Edit(string userId, string roleId)
        {
            if (userId == null || roleId == null)
            {
                return NotFound();
            }

            var userRole = await _context.UserRoles.SingleOrDefaultAsync(predicate: m => m.UserId == userId && m.RoleId == roleId);
            if (userRole == null)
            {
                return NotFound();
            }

            var vm = new UserRolesCreateEditViewModel()
            {
                IdentityUserRole = userRole,
                PreviousIdentityUserRole = userRole,

                UserSelectList = new SelectList(
                    items: _context.Users,
                    dataValueField: nameof(ApplicationUser.Id),
                    dataTextField: nameof(ApplicationUser.Email),
                    selectedValue: userRole.UserId),

                RoleSelectList = new SelectList(
                    items: _context.Roles,
                    dataValueField: nameof(IdentityRole.Id),
                    dataTextField: nameof(IdentityRole.Name),
                    selectedValue: userRole.RoleId)
            };
            return View(model: vm);
        }

        // POST: Identity/UserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userId, string roleId, UserRolesCreateEditViewModel vm)
        {
            if (userId != vm.PreviousIdentityUserRole.UserId || roleId != vm.PreviousIdentityUserRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var identityUserRole = _context.UserRoles.Find(userId, roleId);
                    _context.UserRoles.Remove(identityUserRole);
                    _context.UserRoles.Add(entity: vm.IdentityUserRole);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRoleExists(userId: vm.IdentityUserRole.UserId, roleId: vm.IdentityUserRole.RoleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(actionName: "Index");
            }


            vm.UserSelectList = new SelectList(
                items: _context.Users,
                dataValueField: nameof(ApplicationUser.Id),
                dataTextField: nameof(ApplicationUser.Email),
                selectedValue: vm.IdentityUserRole.UserId);

            vm.RoleSelectList = new SelectList(
                items: _context.Roles,
                dataValueField: nameof(IdentityRole.Id),
                dataTextField: nameof(IdentityRole.Name),
                selectedValue: vm.IdentityUserRole.RoleId);

            return View(model: vm);
        }

        //// GET: Identity/UserRoles/Delete/5
        //public async Task<IActionResult> Delete(string? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var aspNetUserRoles = await _context.AspNetUserRoles
        //        .Include(a => a.Role)
        //        .Include(a => a.User)
        //        .SingleOrDefaultAsync(m => m.UserId == id);
        //    if (aspNetUserRoles == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(aspNetUserRoles);
        //}

        //// POST: Identity/UserRoles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var aspNetUserRoles = await _context.AspNetUserRoles.SingleOrDefaultAsync(m => m.UserId == id);
        //    _context.AspNetUserRoles.Remove(aspNetUserRoles);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        private bool UserRoleExists(string userId, string roleId)
        {
            return _context.UserRoles.Any(predicate: e => e.UserId == userId && e.RoleId == roleId);
        }
    }
}