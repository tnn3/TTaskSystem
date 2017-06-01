using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class UserTitleInProject
    {
        public int UserTitleInProjectId { get; set; }

        public int ProjectId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Project")]
        public Project Project { get; set; }

        public int TitleId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Title")]
        public UserTitle Title { get; set; }

        public List<UserInProject> UsersWithTitleInProject { get; set; }
    }
}
