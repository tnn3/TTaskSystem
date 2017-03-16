using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public string AttachmentLocation { get; set; }
        public Task Task { get; set; }
        public DateTime TimeUploaded { get; set; }
    }
}
