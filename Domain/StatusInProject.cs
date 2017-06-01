using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class StatusInProject
    {
        public int StatusInProjectId { get; set; }

        public int StatusId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Status")]
        public Status Status { get; set; }

        public int ProjectId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Project")]
        public Project Project { get; set; }
    }
}
