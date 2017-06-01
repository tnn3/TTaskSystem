using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class UserInProject
    {
        public int UserInProjectId { get; set; }

        public int UserTitleInProjectId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Title")]
        public UserTitleInProject TitleInProject { get; set; }

        public int UserId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Username")]
        public ApplicationUser User { get; set; }

        public int ProjectId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Project")]
        public Project Project { get; set; }
    }
}
