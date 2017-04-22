using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            ChangeSets = new HashSet<ChangeSets>();
            ProjectTasksAssignedToId1Navigation = new HashSet<ProjectTasks>();
            ProjectTasksAuthorId1Navigation = new HashSet<ProjectTasks>();
            UserTitleInProjects = new HashSet<UserTitleInProjects>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }
        public int? UserTitleId { get; set; }

        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<ChangeSets> ChangeSets { get; set; }
        public virtual ICollection<ProjectTasks> ProjectTasksAssignedToId1Navigation { get; set; }
        public virtual ICollection<ProjectTasks> ProjectTasksAuthorId1Navigation { get; set; }
        public virtual ICollection<UserTitleInProjects> UserTitleInProjects { get; set; }
        public virtual UserTitles UserTitle { get; set; }
    }
}
