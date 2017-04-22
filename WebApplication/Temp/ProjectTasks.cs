using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class ProjectTasks
    {
        public ProjectTasks()
        {
            Attachments = new HashSet<Attachments>();
            ChangeSets = new HashSet<ChangeSets>();
            CustomFieldValues = new HashSet<CustomFieldValues>();
        }

        public int ProjectTaskId { get; set; }
        public DateTime Changed { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public string TaskName { get; set; }
        public int AssignedToId { get; set; }
        public string AssignedToId1 { get; set; }
        public int AuthorId { get; set; }
        public string AuthorId1 { get; set; }
        public int ProjectId { get; set; }

        public virtual ICollection<Attachments> Attachments { get; set; }
        public virtual ICollection<ChangeSets> ChangeSets { get; set; }
        public virtual ICollection<CustomFieldValues> CustomFieldValues { get; set; }
        public virtual AspNetUsers AssignedToId1Navigation { get; set; }
        public virtual AspNetUsers AuthorId1Navigation { get; set; }
        public virtual Priorities Priority { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Statuses Status { get; set; }
    }
}
