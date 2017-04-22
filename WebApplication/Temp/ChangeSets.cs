using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class ChangeSets
    {
        public ChangeSets()
        {
            Changes = new HashSet<Changes>();
        }

        public int ChangeSetId { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public int ApplicationUserId { get; set; }
        public string ChangerId { get; set; }
        public int ProjectTaskId { get; set; }

        public virtual ICollection<Changes> Changes { get; set; }
        public virtual AspNetUsers Changer { get; set; }
        public virtual ProjectTasks ProjectTask { get; set; }
    }
}
