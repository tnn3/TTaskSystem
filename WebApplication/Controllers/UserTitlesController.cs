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

namespace WebApplication.Controllers
{
    public class UserTitlesController : Controller
    {
        private readonly IUOW _uow;

        public UserTitlesController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: UserTitles
        public async Task<IActionResult> Index()
        {
            return View(await _uow.UserTitles.AllAsync());
        }

        // GET: UserTitles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _uow.UserTitles.FindAsync(id.Value);
            if (userTitle == null)
            {
                return NotFound();
            }

            return View(userTitle);
        }

        // GET: UserTitles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTitleId,TitleName")] UserTitle userTitle)
        {
            if (ModelState.IsValid)
            {
                _uow.UserTitles.Add(userTitle);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userTitle);
        }

        // GET: UserTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _uow.UserTitles.FindAsync(id.Value);
            if (userTitle == null)
            {
                return NotFound();
            }
            return View(userTitle);
        }

        // POST: UserTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTitleId,TitleName")] UserTitle userTitle)
        {
            if (id != userTitle.UserTitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.UserTitles.Update(userTitle);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTitleExistsAsync(userTitle.UserTitleId))
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
            return View(userTitle);
        }

        // GET: UserTitles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTitle = await _uow.UserTitles.FindAsync(id.Value);
            if (userTitle == null)
            {
                return NotFound();
            }

            return View(userTitle);
        }

        // POST: UserTitles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userTitle = await _uow.UserTitles.FindAsync(id);
            _uow.UserTitles.Remove(userTitle);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserTitleExistsAsync(int id)
        {
            return _uow.UserTitles.Find(id) != null;
        }
    }
}
