using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class UserTitleInProjectViewModel
    {

    }

    public class UserTitleInProjectCreateEditViewModel
    {
        public UserTitleInProject UserTitleInProject { get; set; }
        public SelectList ProjectSelectList { get; set; }
        public SelectList TitleSelectList { get; set; }
    }
}
