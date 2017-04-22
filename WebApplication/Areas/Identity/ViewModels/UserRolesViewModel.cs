using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Identity.ViewModels
{
    public class UserRole
    {
        public IdentityUser IdentityUser { get; set; }
        public IdentityRole IdentityRole { get; set; }
    }


    public class UserRolesIndexViewModel
    {
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

    public class UserRolesCreateEditViewModel
    {
        public IdentityUserRole<string> IdentityUserRole { get; set; }
        public IdentityUserRole<string> PreviousIdentityUserRole { get; set; }
        public SelectList UserSelectList { get; set; }
        public SelectList RoleSelectList { get; set; }
    }
}
