using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class Statuses
    {
        public Statuses()
        {
            ProjectTasks = new HashSet<ProjectTasks>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
    }
}
