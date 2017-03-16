using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CustomFieldInProject
    {
        public int CustomFieldInProjectId { get; set; }

        public CustomFieldValue FieldValue { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int CustomFieldId { get; set; }
        public CustomField CustomField { get; set; }
    }
}
