using System;
using Microsoft.AspNetCore.Identity;

namespace Vidly
{
    public class MyIdentityDbInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync
                ("user@vidly.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "user@vidly.com";
                user.Email = "user1@localhost";

                IdentityResult result = userManager.CreateAsync
                (user, "Password#1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "User").Wait();
                }
            }
            
            if (userManager.FindByNameAsync
            ("admin@vidly.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@vidly.com";
                user.Email = "admin@vidly.com";
          
                IdentityResult result = userManager.CreateAsync
                (user, "Password#1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
            ("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
