using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class CustomFieldValuesViewModel
    {
    }

    public class CustomFieldValuesCreateEditViewModel
    {
        public CustomFieldValue CustomFieldValue { get; set; }
        public SelectList CustomFieldSelectList { get; set; }
        public SelectList ProjectTaskSelectList { get; set; }
    }
}
