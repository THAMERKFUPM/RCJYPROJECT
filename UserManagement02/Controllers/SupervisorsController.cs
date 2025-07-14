using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using UserManagement02.Interfaces;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class SupervisorsController : Controller
    {
        private readonly ISupervisorRepo _repo;
        private readonly IDepartmentRepo _deptRepo;
        private readonly IMapper _mapper;

        public SupervisorsController(
            ISupervisorRepo repo,
            IDepartmentRepo deptRepo,
            IMapper mapper)
        {
            _repo = repo;
            _deptRepo = deptRepo;
            _mapper = mapper;
        }

        // GET: /Supervisors
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _repo.GetAllSupervisors();
            var vms = _mapper.Map<List<SupervisorsViewModel>>(list);
            return View(vms);
        }

        // GET: /Supervisors/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new SupervisorsViewModel();
            await PopulateDepartments(vm);
            return View(vm);
        }

        // POST: /Supervisors/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupervisorsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDepartments(vm);
                return View(vm);
            }

            var ent = _mapper.Map<Supervisor>(vm);
            ent.DepartmentId = vm.SelectedDepartmentId;
            await _repo.CreateAsync(ent);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Supervisors/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ent = await _repo.GetSupervisor(id);
            if (ent == null) return NotFound();

            var vm = _mapper.Map<SupervisorsViewModel>(ent);
            vm.SelectedDepartmentId = ent.DepartmentId;
            await PopulateDepartments(vm);
            return View(vm);
        }

        // POST: /Supervisors/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupervisorsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDepartments(vm);
                return View(vm);
            }

            var ent = _mapper.Map<Supervisor>(vm);
            ent.DepartmentId = vm.SelectedDepartmentId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Supervisors/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ent = await _repo.GetSupervisor(id);
            if (ent == null) return NotFound();

            var vm = _mapper.Map<SupervisorsViewModel>(ent);
            return View(vm);
        }

        // POST: /Supervisors/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Loads your real departments into the VM's Departments list,
        /// including a placeholder and pre-selecting the current one.
        /// </summary>
        private async Task PopulateDepartments(SupervisorsViewModel vm)
        {
            // 1) load all real departments
            var depts = await _deptRepo.GetAllAsync();

            // 2) map to SelectListItem, flagging Selected as needed
            var items = depts
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                    Selected = (d.Id == vm.SelectedDepartmentId)
                })
                .ToList();

            // 3) insert a placeholder at the top
            items.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- اختر إدارة --"
            });

            vm.Departments = items;
        }
    }
}

