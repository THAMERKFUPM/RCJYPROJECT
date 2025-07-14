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

        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _repo.GetAllSupervisors();
            var vms = _mapper.Map<List<SupervisorsViewModel>>(list);
            return View(vms);
        }

        
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new SupervisorsViewModel();
            await PopulateDepartments(vm);
            return View(vm);
        }

      
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupervisorsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDepartments(vm);
                return View(vm);
            }

            var ent = _mapper.Map<Supervisor>(vm);
            ent.Departments = vm.SelectedDepartmentId;
            await _repo.CreateAsync(ent);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ent = await _repo.GetSupervisor(id);
            if (ent == null) return NotFound();

            var vm = _mapper.Map<SupervisorsViewModel>(ent);
            vm.SelectedDepartmentId = ent.Departments;
            await PopulateDepartments(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupervisorsViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDepartments(vm);
                return View(vm);
            }

            var ent = _mapper.Map<Supervisor>(vm);
            ent.Departments = vm.SelectedDepartmentId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ent = await _repo.GetSupervisor(id);
            if (ent == null) return NotFound();

            var vm = _mapper.Map<SupervisorsViewModel>(ent);
            return View(vm);
        }

     
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        
        private async Task PopulateDepartments(SupervisorsViewModel vm)
        {
            var depts = await _deptRepo.GetAllAsync();

            var items = depts
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name,
                    Selected = (d.Id.ToString() == vm.SelectedDepartmentId)
                })
                .ToList();

            items.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "-- اختر إدارة --"
            });

            vm.Departments = items;
        }
    }
}

