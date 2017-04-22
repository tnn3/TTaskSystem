using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class Changes
    {
        public int ChangeId { get; set; }
        public string After { get; set; }
        public string Before { get; set; }
        public int ChangeSetId { get; set; }

        public virtual ChangeSets ChangeSet { get; set; }
    }
}
