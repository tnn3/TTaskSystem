using System;
using System.Collections.Generic;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class UserTitle
    {
        public int UserTitleId { get; set; }
        public string Title { get; set; }

        public List<UserTitleInProject> TitlesInProjects { get; set; }
    }
}
