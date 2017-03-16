﻿using System;
using System.Collections.Generic;

namespace Domain
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public Person Author { get; set; }
        public Person AssignedTo { get; set; }
        public List<Attachment> Attachments { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public List<ChangeSet> ChangeSets { get; set; }
    }
}
