using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserManagement02.Models;

namespace UserManagement02.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly ISupervisorRepo _repo;
        public SupervisorController(ISupervisorRepo repo)
        {
            _repo = repo;
        }

        // GET: /Supervisor
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _repo.GetAllSupervisors();
                return View(list);
            }
            catch
            {
                TempData["Error"] = "عذراً، تعذّر تحميل قائمة المشرفين.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Supervisor/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Supervisor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supervisor model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "يرجى تصحيح المدخلات ثم المحاولة مجدداً.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _repo.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "عذراً، لم نتمكن من إضافة المشرف.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Supervisor/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var sup = await _repo.GetSupervisor(id);
                if (sup == null)
                {
                    TempData["Error"] = "المشرف المطلوب غير موجود.";
                    return RedirectToAction(nameof(Index));
                }
                return View(sup);
            }
            catch
            {
                TempData["Error"] = "تعذّر جلب بيانات المشرف.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Supervisor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Supervisor model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "يرجى تصحيح المدخلات ثم المحاولة مجدداً.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                await _repo.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "عذراً، لم نتمكن من تحديث بيانات المشرف.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Supervisor/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var sup = await _repo.GetSupervisor(id);
                if (sup == null)
                {
                    TempData["Error"] = "المشرف المطلوب غير موجود.";
                    return RedirectToAction(nameof(Index));
                }
                return View(sup);
            }
            catch
            {
                TempData["Error"] = "تعذّر جلب بيانات الحذف.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Supervisor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "عذراً، لم نتمكن من حذف المشرف.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
