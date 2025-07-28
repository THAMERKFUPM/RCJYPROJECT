<<<<<<< HEAD
// Controllers/UsersController.cs
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Data;
=======
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class UsersController : Controller
    {
<<<<<<< HEAD
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public UsersController(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        // GET: /Users
        public async Task<IActionResult> Index()
        {
            var users = await _ctx.AppUsers.ToListAsync();
=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            var vms = _mapper.Map<List<UserViewModel>>(users);
            return View(vms);
        }

<<<<<<< HEAD
        // GET: /Users/Create
        public IActionResult Create()
        {
            var vm = new UserViewModel();
            PopulateRoles();
            return View(vm);
        }

        // POST: /Users/Create
=======
        public async Task<IActionResult> Create()
        {
            var vm = new UserViewModel();
            await PopulateRoles();
            return View(vm);
        }

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
<<<<<<< HEAD
                PopulateRoles();
                return View(vm);
            }

            var entity = _mapper.Map<AppUser>(vm);
            entity.CreatedAt = DateTime.UtcNow;
            _ctx.AppUsers.Add(entity);
            await _ctx.SaveChangesAsync();
=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

            return RedirectToAction(nameof(Index));
        }

<<<<<<< HEAD
        // GET: /Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(entity);
            PopulateRoles();
=======
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            vm.Role = userRoles.FirstOrDefault();

            await PopulateRoles();
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
<<<<<<< HEAD
                PopulateRoles();
                return View(vm);
            }

            var entity = await _ctx.AppUsers.FindAsync(vm.UserID);
            if (entity == null) return NotFound();

            _mapper.Map(vm, entity);
            // if Password provided, hash manually or via UserManager (not shown here)
            await _ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(entity);
            return View(vm);
        }

        // POST: /Users/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity != null)
            {
                _ctx.AppUsers.Remove(entity);
                await _ctx.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Helper to populate roles into ViewData
        private void PopulateRoles()
        {
            ViewData["Roles"] = new List<SelectListItem>
            {
                new SelectListItem("HR","HR"),
                new SelectListItem("Supervisor","Supervisor"),
                new SelectListItem("SectionHead","SectionHead"),
                new SelectListItem("Intern","Intern"),
                new SelectListItem("Admin","Admin")
            };
=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
        }
    }
}
