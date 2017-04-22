using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class UserTitles
    {
        public UserTitles()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
            UserTitleInProjects = new HashSet<UserTitleInProjects>();
        }

        public int UserTitleId { get; set; }
        public string TitleName { get; set; }

        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<UserTitleInProjects> UserTitleInProjects { get; set; }
    }
}
