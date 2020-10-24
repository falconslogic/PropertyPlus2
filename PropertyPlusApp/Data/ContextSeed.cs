using Microsoft.AspNetCore.Identity;
using PropertyPlusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Data
{
    public static class ContextSeed
    {
            public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                //Seed Roles
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.SuperAdmin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Moderator.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Enum.Roles.Basic.ToString()));
            }
        }
    }

