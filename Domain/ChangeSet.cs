using System;
using System.Collections.Generic;
using System.Text;
using Domain.Identity;

namespace Domain
{
    public class ChangeSet
    {
        public int ChangeSetId { get; set; }

        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser Changer { get; set; }

        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public List<Change> Changes { get; set; }
    }
}
