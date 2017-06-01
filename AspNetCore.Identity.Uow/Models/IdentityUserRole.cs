using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNetCore.Identity.Uow.Models
{
    /// <summary>
    /// Represents the link between a user and a role.
    /// </summary>
    public class IdentityUserRole
    {
        [Key]
        public virtual int IdentityUserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the user that is linked to a role.
        /// </summary>
        public virtual int UserId { get; set; }
        [Display(ResourceType = typeof(Resources.Identity), Name = "User")]
        public virtual IdentityUser User { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the role that is linked to the user.
        /// </summary>
        public virtual int RoleId { get; set; }
        [Display(ResourceType = typeof(Resources.Identity), Name = "Role")]
        public virtual IdentityRole Role { get; set; }
    }
}
