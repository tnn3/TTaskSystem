using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; }

        public List<StatusInProject> StatusInProjects { get; set; }
    }
}
