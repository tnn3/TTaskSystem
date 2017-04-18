using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserTitleInProject
    {
        public int UserTitleInProjectId { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int TitleId { get; set; }
        public UserTitle Title { get; set; }
    }
}
