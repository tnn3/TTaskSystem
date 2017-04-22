using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class Attachments
    {
        public int AttachmentId { get; set; }
        public string AttachmentLocation { get; set; }
        public DateTime UploadedOn { get; set; }
        public int ProjectTaskId { get; set; }

        public virtual ProjectTasks ProjectTask { get; set; }
    }
}
