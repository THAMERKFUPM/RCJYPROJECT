// Controllers/UsersController.cs
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Data;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class UsersController : Controller
    {
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
            var vms = _mapper.Map<List<UserViewModel>>(users);
            return View(vms);
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            var vm = new UserViewModel();
            PopulateRoles();
            return View(vm);
        }

        // POST: /Users/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                PopulateRoles();
                return View(vm);
            }

            var entity = _mapper.Map<AppUser>(vm);
            entity.CreatedAt = DateTime.UtcNow;
            _ctx.AppUsers.Add(entity);
            await _ctx.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity == null) return NotFound();

            var vm = _mapper.Map<UserViewModel>(entity);
            PopulateRoles();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel vm)
        {
            if (!ModelState.IsValid)
            {
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
        }
    }
}
