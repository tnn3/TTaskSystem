using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApplication.Controllers
{
    public class CustomFieldValuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomFieldValuesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CustomFieldValues
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CustomFieldValues.Include(c => c.CustomField);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CustomFieldValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _context.CustomFieldValues
                .Include(c => c.CustomField)
                .SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // GET: CustomFieldValues/Create
        public IActionResult Create()
        {
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId");
            return View();
        }

        // POST: CustomFieldValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFieldValueId,FieldValue,CustomFieldId")] CustomFieldValue customFieldValue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customFieldValue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomFieldId"] = new SelectList(_context.CustomFields, "CustomFieldId", "CustomFieldId", customFieldValue.CustomFieldId);
            return View(customFieldValue);
        }

        // GET: CustomFieldValues/Edit/5
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
            return View(customFieldValue);
        }

        // POST: CustomFieldValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFieldValueId,FieldValue,CustomFieldId")] CustomFieldValue customFieldValue)
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
            return View(customFieldValue);
        }

        // GET: CustomFieldValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _context.CustomFieldValues
                .Include(c => c.CustomField)
                .SingleOrDefaultAsync(m => m.CustomFieldValueId == id);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // POST: CustomFieldValues/Delete/5
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
