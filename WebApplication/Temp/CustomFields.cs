using System;
using System.Collections.Generic;

namespace WebApplication.temp
{
    public partial class CustomFields
    {
        public CustomFields()
        {
            CustomFieldValues = new HashSet<CustomFieldValues>();
        }

        public int CustomFieldId { get; set; }
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public string PossibleValues { get; set; }
        public int CustomFieldValueId { get; set; }
        public int? ProjectId { get; set; }

        public virtual ICollection<CustomFieldValues> CustomFieldValues { get; set; }
        public virtual Projects Project { get; set; }
    }
}
