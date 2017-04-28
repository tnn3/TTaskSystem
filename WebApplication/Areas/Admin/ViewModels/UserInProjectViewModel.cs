using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Admin.ViewModels
{
    public class UserInProjectViewModel
    {

    }

    public class UserInProjectCreateEditViewModel
    {
        public UserInProject UserInProject { get; set; }
        public SelectList ProjectSelectList { get; set; }
        public SelectList ProjectTitleSelectList { get; set; }
    }
}
