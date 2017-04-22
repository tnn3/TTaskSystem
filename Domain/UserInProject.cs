using System;
using System.Collections.Generic;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class UserInProject
    {
        public int UserInProjectId { get; set; }

        public int UserTitleInProjectId { get; set; }
        public UserTitleInProject TitleInProject { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
