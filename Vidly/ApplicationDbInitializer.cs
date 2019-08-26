using System;
using Microsoft.AspNetCore.Identity;

namespace Vidly
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@vidly.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@vidly.com",
                    Email = "admin@vidly.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Password#1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
