using System;
using System.Collections.Generic;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public List<CustomField> CustomFields { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<UserInProject> UsersInProject { get; set; }
        public List<UserTitleInProject> TitlesInProject { get; set; }
        public List<StatusInProject> StatusInProjects { get; set; }
    }
}
