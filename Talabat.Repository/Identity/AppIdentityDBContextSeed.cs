using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public static class AppIdentityDBContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new AppUser()
                {
                    DisplayName = "Ahmed Saber",
                    Email = "Ahmed.saber@gmail.com",
                    UserName = "Ahmed.Saber",
                    PhoneNumber = "01155668978"
                };
                await _userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
