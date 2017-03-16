using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<CustomFieldInProject> CustomFields { get; set; }
    }
}
