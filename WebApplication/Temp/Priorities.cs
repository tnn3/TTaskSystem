using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class Priorities
    {
        public Priorities()
        {
            ProjectTasks = new HashSet<ProjectTasks>();
        }

        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
    }
}
