using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Priority
    {
        public int PriorityId { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "Priority")]
        public string Name { get; set; }

        public List<ProjectTask> ProjectTasks { get; set; }
    }
}
