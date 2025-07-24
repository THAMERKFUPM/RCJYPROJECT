using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UsersController(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var vms = _mapper.Map<List<UserViewModel>>(users);
            return View(vms);
        }

        public async Task<IActionResult> Create()
        {
            var vm = new UserViewModel();
            await PopulateRoles();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateRoles();
                return View(vm);
            }
            //move to repo
            var user = new AppUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                FullName = vm.FullName,
                UniversityName = vm.University,
                PhoneNumber = vm.PhoneNumber,
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            var createResult = await _userManager.CreateAsync(user, vm.Password);
            if (!createResult.Succeeded)
            {
                foreach (var err in createResult.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);

                await PopulateRoles();
                return View(vm);
            }

            if (!await _roleManager.RoleExistsAsync(vm.Role))
            {
                ModelState.AddModelError(string.Empty, "Role does not exist");
                await PopulateRoles();
                return View(vm);
            }

            var addRoleResult = await _userManager.AddToRoleAsync(user, vm.Role);
            if (!addRoleResult.Succeeded)
            {
                foreach (var err in addRoleResult.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);

                await PopulateRoles();
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            vm.Role = userRoles.FirstOrDefault();

            await PopulateRoles();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateRoles();
                return View(vm);
            }

            var user = await _userManager.FindByIdAsync(vm.UserID);
            if (user == null) return NotFound();

            user.FullName = vm.FullName;
            user.Email = vm.Email;
            user.UserName = vm.Email;
            user.PhoneNumber = vm.PhoneNumber;
            user.UniversityName = vm.University;
            user.IsActive = vm.IsActive;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                foreach (var err in updateResult.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);

                await PopulateRoles();
                return View(vm);
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(vm.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, vm.Role);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(user);
            vm.Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            return View(vm);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateRoles()
        {
            var roles = await _roleManager.Roles
                                          .Select(r => new SelectListItem(r.Name, r.Name))
                                          .ToListAsync();

            ViewData["Roles"] = roles;
        }
    }
}
