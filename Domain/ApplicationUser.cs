using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using AspNetCore.Identity.Uow.Models;

namespace Domain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }

        [InverseProperty(nameof(ProjectTask.Author))]
        public List<ProjectTask> AuthorOfTasks { get; set; }

        [InverseProperty(nameof(ProjectTask.AssignedTo))]
        public List<ProjectTask> AssignedTasks { get; set; }

        public List<ChangeSet> ChangeSets { get; set; }

        public List<UserInProject> UserInProjects { get; set; }
    }
}
