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
    public class AttachmentsController : Controller
    {
        private readonly IUOW _uow;

        public AttachmentsController(IUOW uow)
        {
            _uow = uow;    
        }

        // GET: Attachments
        public async Task<IActionResult> Index()
        {
            return View(await _uow.Attachments.AllAsync());
        }

        // GET: Attachments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _uow.Attachments.FindAsync(id.Value);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // GET: Attachments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attachments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttachmentId,AttachmentLocation,TimeUploaded")] Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                _uow.Attachments.Add(attachment);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attachment);
        }

        // GET: Attachments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _uow.Attachments.FindAsync(id.Value);
            if (attachment == null)
            {
                return NotFound();
            }
            return View(attachment);
        }

        // POST: Attachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttachmentId,AttachmentLocation,TimeUploaded")] Attachment attachment)
        {
            if (id != attachment.AttachmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _uow.Attachments.Update(attachment);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentExistsAsync(attachment.AttachmentId))
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
            return View(attachment);
        }

        // GET: Attachments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attachment = await _uow.Attachments.FindAsync(id.Value);
            if (attachment == null)
            {
                return NotFound();
            }

            return View(attachment);
        }

        // POST: Attachments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var attachment = await _uow.Attachments.FindAsync(id);
            _uow.Attachments.Remove(attachment);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttachmentExistsAsync(int id)
        {
            return _uow.Attachments.Find(id) != null;
        }
    }
}
