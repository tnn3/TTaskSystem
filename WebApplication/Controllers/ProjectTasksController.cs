using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebApplication.ViewModels.ProjectTaskViewModel;
using AspNetCore.Identity.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ProjectTasksController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;
        private readonly IHostingEnvironment _environment;

        public ProjectTasksController(IApplicationUnitOfWork uow, IHostingEnvironment environment)
        {
            _uow = uow;
            _environment = environment;
        }

        // GET: ProjectTasks
        public async Task<IActionResult> Index(int? projectId)
        {
            if (projectId == null)
            {
                return User.IsInRole("Admin") ?
                 RedirectToAction("Index", "Projects", new {area = "Admin"}) :
                    RedirectToAction("Index", "Projects");
            }
            return User.IsInRole("Admin") ? 
                View(await _uow.ProjectTasks.AllInProject(projectId.Value)) : 
                View(await _uow.ProjectTasks.AllInProjectWithUser(projectId.Value, User.GetUserId<int>()));
        }

        // GET: ProjectTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = User.IsInRole("Admin") ? 
                await _uow.ProjectTasks.FindWithIncludesAsync(id.Value) : 
                await _uow.ProjectTasks.FindAsyncWithIncludesAndUser(id.Value, User.GetUserId<int>());
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // GET: Projects/5/Tasks/Create
        public async Task<IActionResult> Create(int? projectId)
        {
            if (projectId == null)
            {
                return NotFound();
            }

            //TODO optimize
            var projectStatuses = await _uow.StatusInProjects.GetProjectStatuses(projectId.Value);
            var project = await _uow.Projects.FindUserProjectAsync(projectId.Value, User.GetUserId<int>());

            if (projectStatuses == null || project == null)
            {
                return NotFound();
            }
            var vm = new ProjectTaskViewModel
            {
                StatusSelectList = new SelectList(
                    items: projectStatuses,
                    dataValueField: nameof(StatusInProject.StatusInProjectId),
                    dataTextField: nameof(StatusInProject.Status) + "." + nameof(Status.Name)),
                AssignedToSelectList = new SelectList(
                    await _uow.UserInProjects.AllInProject(projectId.Value),
                    nameof(UserInProject.UserId),
                    nameof(UserInProject.User) + "." + nameof(ApplicationUser.UserName)),
                PrioritySelectList = new SelectList(
                    items: await _uow.Priorities.AllAsync(),
                    dataValueField: nameof(Priority.PriorityId),
                    dataTextField: nameof(Priority.Name)),
                CustomFields = project.CustomFields
            };
            return View(vm);
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? projectId, ProjectTaskViewModel vm, ICollection<IFormFile> files)
        {
            if (projectId == null)
            {
                return NotFound();
            }
            var project = await _uow.Projects.FindUserProjectAsync(projectId.Value, User.GetUserId<int>());
            if (project == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                vm.ProjectTask.AuthorId = int.Parse(User.GetUserId());
                vm.ProjectTask.Created = DateTime.Now;
                vm.ProjectTask.ProjectId = projectId.Value;
                
                _uow.ProjectTasks.Add(vm.ProjectTask);

                //TODO fix for existing filename
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        _uow.Attachments.Add(new Attachment
                        {
                            ProjectTaskId = vm.ProjectTask.ProjectTaskId,
                            Location = file.FileName,
                            UploadedOn = DateTime.Now,
                        });
                    }
                }
                
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            vm.StatusSelectList = new SelectList(
                items: await _uow.StatusInProjects.GetProjectStatuses(vm.ProjectTask.ProjectId),
                dataValueField: nameof(StatusInProject.StatusId),
                dataTextField: nameof(StatusInProject.Status) + "." + nameof(Status.Name));
            vm.AssignedToSelectList = new SelectList(
                await _uow.UserInProjects.AllInProject(projectId.Value),
                nameof(UserInProject.UserId),
                nameof(UserInProject.User) + "." + nameof(ApplicationUser.UserName));
            vm.PrioritySelectList = new SelectList(
                items: await _uow.Priorities.AllAsync(),
                dataValueField: nameof(Priority.PriorityId),
                dataTextField: nameof(Priority.Name));
            vm.CustomFields = project.CustomFields;

            return View(vm);
        }

        // GET: ProjectTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _uow.ProjectTasks.FindAsyncWithIncludesAndUser(id.Value, User.GetUserId<int>());
            if (projectTask == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.FindAsyncWithIncludes(projectTask.ProjectId);
            var vm = new ProjectTaskViewModel
            {
                ProjectTask = projectTask,
                StatusSelectList = new SelectList(
                    items: await _uow.StatusInProjects.GetProjectStatuses(projectTask.ProjectId),
                    dataValueField: nameof(StatusInProject.StatusId),
                    dataTextField: nameof(StatusInProject.Status) + "." + nameof(Status.Name)),
                AssignedToSelectList = new SelectList(
                    await _uow.UserInProjects.AllInProject(projectTask.ProjectId),
                    nameof(UserInProject.UserId),
                    nameof(UserInProject.User) + "." + nameof(ApplicationUser.UserName)),
                PrioritySelectList = new SelectList(
                    items: await _uow.Priorities.AllAsync(),
                    dataValueField: nameof(Priority.PriorityId),
                    dataTextField: nameof(Priority.Name)),
                CustomFields = project.CustomFields
            };
            return View(vm);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectTaskViewModel vm, List<IFormFile> files)
        {
            if (id != vm.ProjectTask.ProjectTaskId)
            {
                return NotFound();
            }

            var prevTask = await _uow.ProjectTasks.FindAsyncWithIncludesAndUser(id, User.GetUserId<int>());
            if (prevTask == null)
            {
                return NotFound();
            }

            var changeSet = new ChangeSet
            {
                ProjectTaskId = prevTask.ProjectTaskId,
                ChangerId = User.GetUserId<int>(),
                Comment = "",
                Time = DateTime.Now,
                Changes = new List<Change>()
            };

            if (prevTask.AssignedToId != vm.ProjectTask.AssignedToId)
            {
                changeSet.Changes.Add(new Change{ Before = prevTask.AssignedTo.UserName});
            }
            prevTask.AssignedToId = vm.ProjectTask.AssignedToId;

            if (prevTask.Description != vm.ProjectTask.Description)
            {
                changeSet.Changes.Add(new Change { Before = prevTask.Description});
            }
            prevTask.Description = vm.ProjectTask.Description;

            if (prevTask.Name != vm.ProjectTask.Name)
            {
                changeSet.Changes.Add(new Change { Before = prevTask.Name });
            }
            prevTask.Name = vm.ProjectTask.Name;

            if (prevTask.DueDate != vm.ProjectTask.DueDate)
            {
                changeSet.Changes.Add(new Change { Before = prevTask.DueDate.ToString() });
            }
            prevTask.DueDate = vm.ProjectTask.DueDate;

            if (prevTask.PriorityId != vm.ProjectTask.PriorityId)
            {
                changeSet.Changes.Add(new Change { Before = prevTask.Priority.Name });
            }
            prevTask.PriorityId = vm.ProjectTask.PriorityId;

            if (prevTask.StatusId != vm.ProjectTask.StatusId)
            {
                changeSet.Changes.Add(new Change { Before = prevTask.Status.Status.Name });
            }
            prevTask.StatusId = vm.ProjectTask.StatusId;

            for (var i = 0; i < prevTask.CustomFieldValue.Count; i++)
            {
                //TODO logic when position changes
                if (prevTask.CustomFieldValue[i].FieldValue != vm.ProjectTask.CustomFieldValue[i].FieldValue)
                {
                    changeSet.Changes.Add(new Change { Before = prevTask.CustomFieldValue[i].FieldValue });
                }
                prevTask.CustomFieldValue[i].FieldValue = vm.ProjectTask.CustomFieldValue[i].FieldValue;
            }

            var oldAttachments = prevTask.Attachments;

            var newAttachments = new List<string>();

            foreach (var file in files)
            {
                var exists = false;
                //remove existing items from delete array
                foreach (var attachment in prevTask.Attachments)
                {
                    if (attachment.Location.Equals(file.FileName))
                    {
                        oldAttachments.Remove(attachment);
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    newAttachments.Add(file.FileName);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (oldAttachments.Count == 0)
                    {
                        prevTask.Attachments = vm.ProjectTask.Attachments;
                    }
                    else
                    {
                        //delete removed attachments
                        foreach (var attachment in oldAttachments)
                        {
                            _uow.Attachments.Remove(attachment);
                            changeSet.Changes.Add(new Change { Before = attachment.Location });
                            //TODO remove from disk
                        }

                        //add new attachments
                        foreach (var attachment in newAttachments)
                        {
                            _uow.Attachments.Add(new Attachment
                            {
                                Location = attachment,
                                ProjectTaskId = prevTask.ProjectTaskId,
                                UploadedOn = DateTime.Now
                            });
                            changeSet.Changes.Add(new Change { Before = attachment });
                        }
                    }
                    _uow.ChangeSets.Add(changeSet);
                    prevTask.Changed = DateTime.Now;
                    _uow.ProjectTasks.Update(prevTask);
                    await _uow.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectTaskExistsAsync(vm.ProjectTask.ProjectTaskId))
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
            var project = await _uow.Projects.FindAsyncWithIncludes(prevTask.ProjectId);
            vm.StatusSelectList = new SelectList(
                items: await _uow.StatusInProjects.GetProjectStatuses(vm.ProjectTask.ProjectId),
                dataValueField: nameof(StatusInProject.StatusId),
                dataTextField: nameof(StatusInProject.Status) + "." + nameof(Status.Name));
            vm.AssignedToSelectList = new SelectList(
                await _uow.UserInProjects.AllInProject(prevTask.ProjectId),
                nameof(UserInProject.UserId),
                nameof(UserInProject.User) + "." + nameof(ApplicationUser.UserName));
            vm.PrioritySelectList = new SelectList(
                items: await _uow.Priorities.AllAsync(),
                dataValueField: nameof(Priority.PriorityId),
                dataTextField: nameof(Priority.Name));
            vm.CustomFields = project.CustomFields;

            return View(vm);
        }

        // GET: ProjectTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectTask = await _uow.ProjectTasks.FindWithUserAsync(id.Value, User.GetUserId<int>());
            if (projectTask == null)
            {
                return NotFound();
            }

            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var projectTask = await _uow.ProjectTasks.FindAsyncWithIncludesAndUser(id, User.GetUserId<int>());
            if (projectTask == null)
            {
                return NotFound();
            }
            //delete related attachments
            foreach (var attachment in projectTask.Attachments)
            {
                _uow.Attachments.Remove(attachment);
            }

            //delete related changes
            foreach (var changeset in projectTask.ChangeSets)
            {
                foreach (var change in changeset.Changes)
                {
                    _uow.Changes.Remove(change);
                }
                _uow.ChangeSets.Remove(changeset);
            }

            _uow.ProjectTasks.Remove(projectTask);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjectTaskExistsAsync(int id)
        {
            return _uow.ProjectTasks.Find(id) != null;
        }
    }
}
