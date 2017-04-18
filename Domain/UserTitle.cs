using System;
using System.Collections.Generic;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class UserTitle
    {
        public int UserTitleId { get; set; }
        public string TitleName { get; set; }
        public List<ApplicationUser> UsersWithTitle { get; set; }
    }
}
