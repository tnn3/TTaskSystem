using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CustomFieldsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public CustomFieldsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: CustomFields
        public async Task<IActionResult> Index(int? projectId)
        {
            if (projectId == null)
            {
                return RedirectToAction("Index", "Projects");
            }
            return View(await _uow.CustomFields.AllInProject(projectId.Value));
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
        public IActionResult Create(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: CustomFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? projectId, CustomField customField)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                customField.ProjectId = projectId.Value;
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
        public async Task<IActionResult> Edit(int id, CustomField customField)
        {
            if (id != customField.CustomFieldId)
            {
                return NotFound();
            }
            var prevField = _uow.CustomFields.Find(id);

            if (ModelState.IsValid)
            {
                try
                {
                    prevField.FieldName = customField.FieldName;
                    prevField.FieldType = customField.FieldType;
                    prevField.IsRequired = customField.IsRequired;
                    prevField.MaxLength = customField.MaxLength;
                    prevField.MinLength = customField.MinLength;
                    prevField.PossibleValues = customField.PossibleValues;
                    _uow.CustomFields.Update(prevField);
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
