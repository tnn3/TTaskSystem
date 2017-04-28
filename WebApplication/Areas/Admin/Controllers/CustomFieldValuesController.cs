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
using WebApplication.Areas.Admin.ViewModels;

namespace WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomFieldValuesController : Controller
    {
        private readonly IUOW _uow;

        public CustomFieldValuesController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: Admin/CustomFieldValues
        public async Task<IActionResult> Index()
        {
            return View(await _uow.CustomFieldValues.AllAsyncWithIncludes());
        }

        // GET: Admin/CustomFieldValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customFieldValue = await _uow.CustomFieldValues.FindAsyncWithIncludes(id.Value);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // GET: Admin/CustomFieldValues/Create
        public async Task<IActionResult> Create()
        {
            var vm = new CustomFieldValuesCreateEditViewModel()
            {
                ProjectTaskSelectList = new SelectList(
                    items: await _uow.ProjectTasks.AllAsync(),
                    dataValueField: nameof(ProjectTask.ProjectTaskId),
                    dataTextField: nameof(ProjectTask.Name)),
                CustomFieldSelectList = new SelectList(
                    items: await _uow.CustomFields.AllAsync(),
                    dataValueField: nameof(CustomField.CustomFieldId),
                    dataTextField: nameof(CustomField.FieldName))
            };
            return View(vm);
        }

        // POST: Admin/CustomFieldValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomFieldValuesCreateEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _uow.CustomFieldValues.Add(vm.CustomFieldValue);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            vm.ProjectTaskSelectList = new SelectList(
                items: await _uow.ProjectTasks.AllAsync(),
                dataValueField: nameof(ProjectTask.ProjectTaskId),
                dataTextField: nameof(ProjectTask.Name));

            vm.CustomFieldSelectList = new SelectList(
                items: await _uow.CustomFields.AllAsync(),
                dataValueField: nameof(CustomField.CustomFieldId),
                dataTextField: nameof(CustomField.FieldName));
            return View(vm);
        }

        // GET: Admin/CustomFieldValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customFieldValue = await _uow.CustomFieldValues.FindAsyncWithIncludes(id.Value);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            var vm = new CustomFieldValuesCreateEditViewModel()
            {
                CustomFieldValue = customFieldValue,
                ProjectTaskSelectList = new SelectList(
                    items: await _uow.ProjectTasks.AllAsync(),
                    dataValueField: nameof(ProjectTask.ProjectTaskId),
                    dataTextField: nameof(ProjectTask.Name)),
                CustomFieldSelectList = new SelectList(
                    items: await _uow.CustomFields.AllAsync(),
                    dataValueField: nameof(CustomField.CustomFieldId),
                    dataTextField: nameof(CustomField.FieldName))
            };
            return View(vm);
        }

        // POST: Admin/CustomFieldValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomFieldValuesCreateEditViewModel vm)
        {
            if (id != vm.CustomFieldValue.CustomFieldValueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.CustomFieldValues.Update(vm.CustomFieldValue);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomFieldValueExistsAsync(vm.CustomFieldValue.CustomFieldValueId))
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

            vm.ProjectTaskSelectList = new SelectList(
                items: await _uow.ProjectTasks.AllAsync(),
                dataValueField: nameof(ProjectTask.ProjectTaskId),
                dataTextField: nameof(ProjectTask.Name));

            vm.CustomFieldSelectList = new SelectList(
                items: await _uow.CustomFields.AllAsync(),
                dataValueField: nameof(CustomField.CustomFieldId),
                dataTextField: nameof(CustomField.FieldName));

            return View(vm);
        }

        // GET: Admin/CustomFieldValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customFieldValue = await _uow.CustomFieldValues.FindAsyncWithIncludes(id.Value);
            if (customFieldValue == null)
            {
                return NotFound();
            }

            return View(customFieldValue);
        }

        // POST: Admin/CustomFieldValues/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customFieldValue = await _uow.CustomFieldValues.FindAsyncWithIncludes(id);
            _uow.CustomFieldValues.Remove(customFieldValue);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CustomFieldValueExistsAsync(int id)
        {
            return _uow.CustomFieldValues.FindAsync(id) != null;
        }
    }
}
