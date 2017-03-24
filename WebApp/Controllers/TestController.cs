using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using Domain;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        /*private readonly IUow _uow;

        public TestController(IUow uow)
        {
            _uow = uow;

        }

        public IActionResult Index()
        {
            var recordcount = _uow.Priorities.All.Count();
            ViewData["Message"] = $"There is {recordcount} in database.";
            return View();
        }*/
    }
}