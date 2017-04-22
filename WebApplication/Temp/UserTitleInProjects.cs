using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class UserTitleInProjects
    {
        public int UserTitleInProjectId { get; set; }
        public string ApplicationUserId { get; set; }
        public int ProjectId { get; set; }
        public int TitleId { get; set; }

        public virtual AspNetUsers ApplicationUser { get; set; }
        public virtual Projects Project { get; set; }
        public virtual UserTitles Title { get; set; }
    }
}
