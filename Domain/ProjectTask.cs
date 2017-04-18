using System;
using System.Collections.Generic;
using Domain.Identity;

namespace Domain
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }

        public int PriorityId { get; set; }
        public Priority Priority { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int AuthorId { get; set; }
        public ApplicationUser Author { get; set; }

        public int AssignedToId { get; set; }
        public ApplicationUser AssignedTo { get; set; }

        public List<Attachment> Attachments { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public List<ChangeSet> ChangeSets { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List<CustomFieldValue> CustomFieldValue { get; set; }
    }
}
