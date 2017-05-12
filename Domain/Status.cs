using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Status
    {
        public int StatusId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Status")]
        public string Name { get; set; }

        public List<StatusInProject> StatusInProjects { get; set; }
    }
}
