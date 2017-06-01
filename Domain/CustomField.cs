using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Enums;

namespace Domain
{
    public class CustomField
    {
        public int CustomFieldId { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "CustomFieldName")]
        public string FieldName { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "CustomFieldType")]
        public FieldType FieldType { get; set; }
        [MaxLength(50)]
        [Display(ResourceType = typeof(Resources.Misc), Name = "CustomFieldPossibleValues")]
        public string PossibleValues { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "MinLength")]
        public int MinLength { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "MaxLength")]
        public int MaxLength { get; set; }
        [Display(ResourceType = typeof(Resources.Misc), Name = "IsRequired")]
        public bool IsRequired { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public List<CustomFieldValue> CustomFieldValues { get; set; }
    }
}
