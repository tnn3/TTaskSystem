using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Priority
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
