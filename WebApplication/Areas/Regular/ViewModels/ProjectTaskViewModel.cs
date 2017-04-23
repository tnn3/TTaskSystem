using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Regular.ViewModels
{
    public class ProjectTaskViewModel
    {
    }

    public class ProjectTaskViewModelCreateEdit
    {
        public ProjectTask ProjectTask { get; set; }
        public SelectList PrioritySelectList { get; set; }
        public SelectList StatusSelectList { get; set; }
        public SelectList AssignedToSelectList { get; set; }
    }
}
