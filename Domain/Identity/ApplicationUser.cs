using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<UserTitleInProject> Titles { get; set; }
        [InverseProperty(nameof(ProjectTask.AssignedTo))]
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
