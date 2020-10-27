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
        public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Blake",
                LastName = "Baker",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enum.Roles.SuperAdmin.ToString());
                }
            }
        }
    }
    }

