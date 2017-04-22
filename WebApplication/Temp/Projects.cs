using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class Projects
    {
        public Projects()
        {
            CustomFields = new HashSet<CustomFields>();
            ProjectTasks = new HashSet<ProjectTasks>();
            UserTitleInProjects = new HashSet<UserTitleInProjects>();
        }

        public int ProjectId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectName { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<CustomFields> CustomFields { get; set; }
        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
        public virtual ICollection<UserTitleInProjects> UserTitleInProjects { get; set; }
    }
}
