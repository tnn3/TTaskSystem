﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.Uow.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Areas.Identity.ViewModels
{
    public class IdentityRoleClaimsCreateEditViewModel
    {
        public IdentityRoleClaim IdentityRoleClaim { get; set; }
        public SelectList RoleSelectList { get; set; }
    }
}
