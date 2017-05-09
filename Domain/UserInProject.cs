using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class UserInProject
    {
        public int UserInProjectId { get; set; }

        public int UserTitleInProjectId { get; set; }
        public UserTitleInProject TitleInProject { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
