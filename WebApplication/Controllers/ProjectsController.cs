using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IApplicationUnitOfWork _uow;

        public ProjectsController(IApplicationUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            var projects = await _uow.Projects.AllUserProjectsAsync(int.Parse(User.GetUserId()));
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _uow.Projects.FindUserProjectAsync(id.Value, int.Parse(User.GetUserId()));
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }
    }

}
