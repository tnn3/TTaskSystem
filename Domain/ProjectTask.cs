using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Display(Name = "Due date")]
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }


        #region ForeignKeys

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int StatusId { get; set; }
        public StatusInProject Status { get; set; }

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public int? AssignedToId { get; set; }
        [Display(Name = "Assigned to")]
        public ApplicationUser AssignedTo { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }


        public List<CustomFieldValue> CustomFieldValue { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<ChangeSet> ChangeSets { get; set; }
        #endregion
    }
}
