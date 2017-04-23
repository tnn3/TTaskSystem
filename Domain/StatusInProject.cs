using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class StatusInProject
    {
        public int StatusInProjectId { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
