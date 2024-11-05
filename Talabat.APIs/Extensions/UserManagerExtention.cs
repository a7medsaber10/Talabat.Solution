using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Talabat.Core.Entities.Identity;

namespace Talabat.APIs.Extensions
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser> FindUserWithAddressByEmailAsync(this UserManager<AppUser> userManager, ClaimsPrincipal User )
        {
            var email = User.FindFirstValue(ClaimTypes.Email) ?? string.Empty;

            var user = userManager.Users.Include(x => x.Address).FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());

            return user;
        }
    }
}
