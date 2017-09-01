using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Enums
{
    public enum FieldType
    {
        [Display(ResourceType = typeof(Resources.Misc), Name = "TextField")]
        Text,
        /*Date,
        Datetime,
        Email,
        Number,
        Range,
        Time,
        Url,
        Month,
        Radio,
        Checkbox*/
    }
}
