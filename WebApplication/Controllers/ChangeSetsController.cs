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
    public class ChangeSetsController : Controller
    {
        private readonly IUOW _uow;

        public ChangeSetsController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: ChangeSets
        public async Task<IActionResult> Index()
        {
            return View(await _uow.ChangeSets.AllAsync());
        }

        // GET: ChangeSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _uow.ChangeSets.FindAsync(id.Value);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // GET: ChangeSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChangeSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeSetId,Comment,Time")] ChangeSet changeSet)
        {
            if (ModelState.IsValid)
            {
                _uow.ChangeSets.Add(changeSet);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(changeSet);
        }

        // GET: ChangeSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _uow.ChangeSets.FindAsync(id.Value);
            if (changeSet == null)
            {
                return NotFound();
            }
            return View(changeSet);
        }

        // POST: ChangeSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeSetId,Comment,Time")] ChangeSet changeSet)
        {
            if (id != changeSet.ChangeSetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.ChangeSets.Update(changeSet);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeSetExistsAsync(changeSet.ChangeSetId))
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
            return View(changeSet);
        }

        // GET: ChangeSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changeSet = await _uow.ChangeSets.FindAsync(id.Value);
            if (changeSet == null)
            {
                return NotFound();
            }

            return View(changeSet);
        }

        // POST: ChangeSets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var changeSet = await _uow.ChangeSets.FindAsync(id);
            _uow.ChangeSets.Remove(changeSet);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChangeSetExistsAsync(int id)
        {
            return _uow.ChangeSets.Find(id) != null;
        }
    }
}
