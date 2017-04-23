using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string Location { get; set; }
        public DateTime UploadedOn { get; set; }

        public int ProjectTaskId { get; set; }
        public ProjectTask ProjectTask { get; set; }
        
    }
}
