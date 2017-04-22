using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain
{
    //Fields for task price, task location, client information etc
    public class CustomField
    {
        public int CustomFieldId { get; set; }
        public string FieldName { get; set; }
        public FieldType FieldType { get; set; }
        public string PossibleValues { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public bool IsRequired { get; set; }


        public Project Project { get; set; }

        public List<CustomFieldValue> CustomFieldValues { get; set; }
    }
}
