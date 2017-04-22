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
    public class PrioritiesController : Controller
    {
        private readonly IUOW _uow;

        public PrioritiesController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: Priorities
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Priorities.AllAsync());
        }

        // GET: Priorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _uow.Priorities.FindAsync(id.Value);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // GET: Priorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PriorityId,PriorityName")] Priority priority)
        {
            if (ModelState.IsValid)
            {
                _uow.Priorities.Add(priority);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(priority);
        }

        // GET: Priorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _uow.Priorities.FindAsync(id.Value);
            if (priority == null)
            {
                return NotFound();
            }
            return View(priority);
        }

        // POST: Priorities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PriorityId,PriorityName")] Priority priority)
        {
            if (id != priority.PriorityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Priorities.Update(priority);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriorityExistsAsync(priority.PriorityId))
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
            return View(priority);
        }

        // GET: Priorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priority = await _uow.Priorities.FindAsync(id.Value);
            if (priority == null)
            {
                return NotFound();
            }

            return View(priority);
        }

        // POST: Priorities/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var priority = await _uow.Priorities.FindAsync(id);
            _uow.Priorities.Remove(priority);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PriorityExistsAsync(int id)
        {
            return _uow.Priorities.Find(id) != null;
        }
    }
}
