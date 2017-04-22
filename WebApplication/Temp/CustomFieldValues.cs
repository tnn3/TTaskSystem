using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class CustomFieldValues
    {
        public int CustomFieldValueId { get; set; }
        public int CustomFieldId { get; set; }
        public string FieldValue { get; set; }
        public int ProjectTaskId { get; set; }

        public virtual CustomFields CustomField { get; set; }
        public virtual ProjectTasks ProjectTask { get; set; }
    }
}
