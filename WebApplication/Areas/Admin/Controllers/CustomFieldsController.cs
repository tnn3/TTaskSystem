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
    public class CustomFieldsController : Controller
    {
        private readonly IUOW _uow;

        public CustomFieldsController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: CustomFields
        public async Task<IActionResult> Index()
        {
            return View(await _uow.CustomFields.AllAsync());
        }

        // GET: CustomFields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customField = await _uow.CustomFields.FindAsync(id.Value);
            if (customField == null)
            {
                return NotFound();
            }

            return View(customField);
        }

        // GET: CustomFields/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomFieldId,FieldName,FieldType,PossibleValues,MinLength,MaxLength,IsRequired,CustomFieldValueId")] CustomField customField)
        {
            if (ModelState.IsValid)
            {
                _uow.CustomFields.Add(customField);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customField);
        }

        // GET: CustomFields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customField = await _uow.CustomFields.FindAsync(id.Value);
            if (customField == null)
            {
                return NotFound();
            }
            return View(customField);
        }

        // POST: CustomFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomFieldId,FieldName,FieldType,PossibleValues,MinLength,MaxLength,IsRequired,CustomFieldValueId")] CustomField customField)
        {
            if (id != customField.CustomFieldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.CustomFields.Update(customField);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFieldExistsAsync(customField.CustomFieldId))
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
            return View(customField);
        }

        // GET: CustomFields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customField = await _uow.CustomFields.FindAsync(id.Value);
            if (customField == null)
            {
                return NotFound();
            }

            return View(customField);
        }

        // POST: CustomFields/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customField = await _uow.CustomFields.FindAsync(id);
            _uow.CustomFields.Remove(customField);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFieldExistsAsync(int id)
        {
            return _uow.CustomFields.Find(id) != null;
        }
    }
}
