namespace UserManagement02.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Models;


    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments
                .Include(d => d.Supervisor)
                .Include(d => d.Trainee)
                .ToListAsync();

            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> AssignSupervisor(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            var supervisors = await _context.Supervisors
                .Where(s => s.DepartmentId == null || s.DepartmentId == id)
                .ToListAsync();

            ViewBag.DepartmentId = id;
            ViewBag.DepartmentName = department?.DepartmentName;
            return View(supervisors);
        }

        [HttpPost]
        public async Task<IActionResult> AssignSupervisor(int departmentId, int supervisorId)
        {
            var supervisor = await _context.Supervisors.FindAsync(supervisorId);
            if (supervisor != null)
            {
                supervisor.DepartmentId = departmentId;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }

