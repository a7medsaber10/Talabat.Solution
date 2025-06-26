using AdminDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }


        [HttpPost]
        public async Task<IActionResult> Create(RoleFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Name);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Name.Trim()));
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Role is Already Exists");
                    return View("Index",await _roleManager.Roles.ToListAsync());
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var mappedRole = new RoleViewModel()
            {
                Name = role.Name
            };

            return View(mappedRole); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,RoleViewModel model)
        { 
            if (ModelState.IsValid)
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Name);

                if (!roleExists)
                {
                    var role = await _roleManager.FindByIdAsync(id);

                    role.Name = model.Name;

                    await _roleManager.UpdateAsync(role);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Name", "Role is Already Exists");
                    return View("Index", await _roleManager.Roles.ToListAsync());
                }
            }
            return RedirectToAction("Index");
        }
    }
}
