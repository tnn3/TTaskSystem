using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
