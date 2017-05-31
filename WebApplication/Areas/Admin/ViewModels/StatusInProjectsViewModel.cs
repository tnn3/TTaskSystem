using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class StatusInProjectsViewModel
    {

    }

    public class StatusInProjectsCreateEditViewModel
    {
        public StatusInProject StatusInProject { get; set; }
        public SelectList StatusSelectList { get; set; }
    }
}
