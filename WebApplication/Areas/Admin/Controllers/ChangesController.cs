using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ChangesController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public ChangesController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Changes
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Changes.AllAsync());
        }

        // GET: Changes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _uow.Changes.FindAsync(id.Value);
            if (change == null)
            {
                return NotFound();
            }

            return View(change);
        }

        // GET: Changes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Changes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChangeId,Before")] Change change)
        {
            if (ModelState.IsValid)
            {
                _uow.Changes.Add(change);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(change);
        }

        // GET: Changes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _uow.Changes.FindAsync(id.Value);
            if (change == null)
            {
                return NotFound();
            }
            return View(change);
        }

        // POST: Changes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChangeId,Before")] Change change)
        {
            if (id != change.ChangeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Changes.Update(change);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangeExistsAsync(change.ChangeId))
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
            return View(change);
        }

        // GET: Changes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var change = await _uow.Changes.FindAsync(id.Value);
            if (change == null)
            {
                return NotFound();
            }

            return View(change);
        }

        // POST: Changes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var change = await _uow.Changes.FindAsync(id);
            _uow.Changes.Remove(change);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChangeExistsAsync(int id)
        {
            return _uow.Changes.Find(id) != null;
        }
    }

}
