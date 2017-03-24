using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ChangeSet
    {
        public int ChangeSetId { get; set; }
        public ProjectTask Task { get; set; }
        public Person Changer { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
    }
}
