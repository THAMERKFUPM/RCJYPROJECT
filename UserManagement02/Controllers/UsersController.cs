using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper             _mapper;

        public UsersController(ApplicationDbContext ctx, IMapper mapper)
        {
            _ctx    = ctx;
            _mapper = mapper;
        }

        // GET: /Users
        public async Task<IActionResult> Index()
        {
            var users = await _ctx.AppUsers.ToListAsync();
            var vms   = _mapper.Map<List<UserViewModel>>(users);
            return View(vms);
        }

        // GET: /Users/Create
        public IActionResult Create()
        {
            // initialize any default values if needed
            return View(new UserViewModel());
        }

        // POST: /Users/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = _mapper.Map<AppUser>(vm);
            _ctx.AppUsers.Add(entity);
            await _ctx.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity == null)
                return NotFound();

            var vm = _mapper.Map<UserViewModel>(entity);
            return View(vm);
        }

        // POST: /Users/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = _mapper.Map<AppUser>(vm);
            _ctx.AppUsers.Update(entity);
            await _ctx.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _ctx.AppUsers.FindAsync(id);
            if (entity == null)
                return NotFound();

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
    }
}
