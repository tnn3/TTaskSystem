using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomFieldValuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomFieldValuesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Admin/CustomFieldValues
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomFieldValues.Include(c => c.CustomField).Include(c => c.ProjectTask);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/CustomFieldValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _context.CustomFieldValues
                .Include(c => c.CustomField)
                .Include(c => c.ProjectTask)
                .SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // GET: Admin/CustomFieldValues/Create
        public IActionResult Create()
        {
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId");
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTasks, "ProjectTaskId", "ProjectTaskId");
            return View();
        }

        // POST: Admin/CustomFieldValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFieldValueId,FieldValue,CustomFieldId,ProjectTaskId")] CustomFieldValue customFieldValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFieldValue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldValue.CustomFieldId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTasks, "ProjectTaskId", "ProjectTaskId", customFieldValue.ProjectTaskId);
            return View(customFieldValue);
        }

        // GET: Admin/CustomFieldValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _context.CustomFieldValues.SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            if (customFieldValue == null)
            {
                return NotFound();
            }
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldValue.CustomFieldId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTasks, "ProjectTaskId", "ProjectTaskId", customFieldValue.ProjectTaskId);
            return View(customFieldValue);
        }

        // POST: Admin/CustomFieldValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFieldValueId,FieldValue,CustomFieldId,ProjectTaskId")] CustomFieldValue customFieldValue)
        {
            if (id != customFieldValue.CustomFieldValueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customFieldValue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFieldValueExists(customFieldValue.CustomFieldValueId))
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
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldValue.CustomFieldId);
            ViewData["ProjectTaskId"] = new SelectList(_context.ProjectTasks, "ProjectTaskId", "ProjectTaskId", customFieldValue.ProjectTaskId);
            return View(customFieldValue);
        }

        // GET: Admin/CustomFieldValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _context.CustomFieldValues
                .Include(c => c.CustomField)
                .Include(c => c.ProjectTask)
                .SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // POST: Admin/CustomFieldValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customFieldValue = await _context.CustomFieldValues.SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            _context.CustomFieldValues.Remove(customFieldValue);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFieldValueExists(int id)
        {
            return _context.CustomFieldValues.Any(e => e.CustomFieldValueId == id);
        }
    }
}
