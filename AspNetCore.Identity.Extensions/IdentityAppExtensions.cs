﻿using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.Uow.Models;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Identity.Extensions
{
    public static class IdentityAppExtensions
    {
        public static async void EnsureDefaultUsersAndRoles(this IApplicationBuilder app)
        {
            var users = new List<IdentityUserWithRoles>()
            {
                new IdentityUserWithRoles(name: "admin@test.ee", email: "admin@test.ee", roles: new[] { "Admin" }, password: "test"),
                new IdentityUserWithRoles(name: "user@test.ee", email: "user@test.ee", roles: new[] { "User" }, password: "test"),
                new IdentityUserWithRoles(name: "regular@test.ee", email: "regular@test.ee", roles:null, password: "test"),
            };


            // get the rolemanager and usermanager from dependency injection engine
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();
            UserManager<ApplicationUser> userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();

            // managers can be null?, maybe there is no identity support
            if (roleManager == null || userManager == null)
            {
                return;
            }

            foreach (var appuser in users)
            {
                foreach (var roleName in appuser.Roles)
                {
                    // check for role and create, if needed
                    if (!await roleManager.RoleExistsAsync(roleName: roleName))
                    {
                        await roleManager.CreateAsync(role: new IdentityRole(roleName: roleName));
                    }
                }

                var user = await userManager.FindByEmailAsync(email: appuser.User.NormalizedEmail);
                if (user == null)
                {
                    var res = await userManager.CreateAsync(user: appuser.User);
                    // get the user, should exist now
                    user = await userManager.FindByEmailAsync(email: appuser.User.NormalizedEmail);
                }

                var resAddToRoles = await userManager.AddToRolesAsync(user: user, roles: appuser.Roles);
            }
        }
    }

    public class IdentityUserWithRoles
    {
        private readonly ApplicationUser _user;
        public ApplicationUser User => _user;
        public string[] Roles { get; set; }
        public IdentityUserWithRoles(string name, string email, string[] roles = null, string password = "secret")
        {
            Roles = roles ?? new string[] { };
            _user = new ApplicationUser
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = name,
                NormalizedUserName = name.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(format: "D"),
            };
            _user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user: _user, password: password);
        }
    }
}
