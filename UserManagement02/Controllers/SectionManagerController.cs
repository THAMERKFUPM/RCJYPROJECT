// Controllers/SectionManagerController.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement02.Interfaces;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class SectionManagerController : Controller
    {
        private readonly IDepartmentRepo _deptRepo;
        private readonly ISupervisorRepo _supRepo;

        public SectionManagerController(
            IDepartmentRepo deptRepo,
            ISupervisorRepo supRepo)
        {
            _deptRepo = deptRepo;
            _supRepo = supRepo;
        }

        // GET: /SectionManager/SectionManagerAssignment
        [HttpGet]
        public async Task<IActionResult> SectionManagerAssignment()
        {
            var vm = new SectionManagerAssignmentViewModel();

            // ملء قائمة الإدارات
            var depts = await _deptRepo.GetAllAsync();
            vm.Departments = depts
                .Select(d => new SelectListItem(d.DepartmentName, d.Id.ToString()))
                .ToList();

            // ملء قائمة مشرفي التدريب
            var sups = await _supRepo.GetAllSupervisor();
            vm.Supervisors = sups
                .Select(s => new SelectListItem(s.SupervisorFullName, s.SupervisorId.ToString()))
                .ToList();

            return View(vm);
        }

        // POST: /SectionManager/SectionManagerAssignment
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> SectionManagerAssignment(SectionManagerAssignmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // إذا فشل التحقق، أعدّ القوائم
                var depts = await _deptRepo.GetAllAsync();
                vm.Departments = depts
                    .Select(d => new SelectListItem(d.DepartmentName, d.Id.ToString()))
                    .ToList();

                var sups = await _supRepo.GetAllSupervisor();
                vm.Supervisors = sups
                    .Select(s => new SelectListItem(s.SupervisorFullName, s.SupervisorId.ToString()))
                    .ToList();

                return View(vm);
            }

            // حفظ التعيين
            var dept = await _deptRepo.GetByIdAsync(vm.SelectedDepartmentId);
            if (dept == null) return NotFound();

            dept.SupervisorId = vm.SelectedSupervisorId;
            await _deptRepo.UpdateAsync(dept);

            TempData["Success"] = "تم حفظ مسؤول التدريب بنجاح";
            return RedirectToAction(nameof(SectionManagerAssignment));
        }
    }
}
