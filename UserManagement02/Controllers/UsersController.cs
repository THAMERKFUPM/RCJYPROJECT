using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Models;
using UserManagement02.Repositories;

namespace UserManagement02.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly IUserRepo _userRepo;

        public UsersController(ApplicationDbContext context/*IUserRepo userRepo*/)
        {
            _context = context;
            //_userRepo = userRepo;
        }
          

        public async Task<IActionResult> Index()
        {
            //var list =await _userRepo.GetAllUsers();
            //return View(list);
            var list =await _context.AppUsers.ToListAsync();
            return View(list);
        }
    
        public IActionResult Create()
            => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUser user)
        {
            if (!ModelState.IsValid) return View(user);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var u = await _context.AppUsers.FindAsync(id);
            return u == null ? NotFound() : View(u);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AppUser user)
        {
            if (id != user.UserID) return NotFound();
            if (!ModelState.IsValid) return View(user);
            _context.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var u = await _context.AppUsers.FindAsync(id);
            return u == null ? NotFound() : View(u);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var u = await _context.AppUsers.FindAsync(id);
            if (u != null)
            {
                _context.AppUsers.Remove(u);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
