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
        [Display(ResourceType = typeof(Resources.Misc), Name = "Title")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.DateTime, ErrorMessageResourceType = typeof(Resources.Common), ErrorMessageResourceName = "FieldMustBeDataTypeDateTime")]
        [Display(ResourceType = typeof(Resources.Misc), Name = "DueDate")]
        public DateTime? DueDate { get; set; }

        [Display(ResourceType = typeof(Resources.Misc), Name = "Created")]
        public DateTime Created { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Changed")]
        public DateTime? Changed { get; set; }


        #region ForeignKeys

        public int PriorityId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Priority")]
        public Priority Priority { get; set; }

        public int StatusId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Status")]
        public StatusInProject Status { get; set; }

        public int AuthorId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Author")]
        public ApplicationUser Author { get; set; }

        public int? AssignedToId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "AssignedTo")]
        public ApplicationUser AssignedTo { get; set; }

        public int ProjectId { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Project")]
        public Project Project { get; set; }

        public List<CustomFieldValue> CustomFieldValue { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "Attachments")]
        public List<Attachment> Attachments { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "ChangeSets")]
        public List<ChangeSet> ChangeSets { get; set; }
        #endregion
    }
}
