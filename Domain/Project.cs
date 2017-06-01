using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "ProjectName")]
        public string Name { get; set; }

        [MaxLength(300)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.Misc), Name = "Created")]
        public DateTime CreatedOn { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Changed")]
        public DateTime? UpdatedOn { get; set; }


        public List<CustomField> CustomFields { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public List<UserInProject> UsersInProject { get; set; }
        public List<UserTitleInProject> TitlesInProject { get; set; }
        public List<StatusInProject> StatusInProjects { get; set; }
    }
}
