using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using UserManagement02.Interfaces;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly ISupervisorRepo  _repo;
        private readonly IDepartmentRepo  _deptRepo;
        private readonly IMapper          _mapper;

        
        
        public SupervisorController(
            ISupervisorRepo repo,
            IDepartmentRepo deptRepo,
            IMapper mapper)
        {
            _repo     = repo;
            _deptRepo = deptRepo;
            _mapper   = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var allSupervisors = await _repo.GetAllSupervisor();     
            var vmList = _mapper.Map<IEnumerable<SupervisorViewModel>>(allSupervisors);
            return View(vmList);
        }
        public async Task<IActionResult> Create()
        {
            var vm = new SupervisorViewModel();
            await PopulateDepartments(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupervisorViewModel vm)
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

        public async Task<IActionResult> Edit(int id)
        {
            var ent = await _repo.GetSupervisor(id);
            if (ent == null) return NotFound();

            var vm = _mapper.Map<SupervisorViewModel>(ent);
            vm.SelectedDepartmentId = ent.DepartmentId;    
            await PopulateDepartments(vm);
            return View(vm);
        }

       
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupervisorViewModel vm)
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

       

        private async Task PopulateDepartments(SupervisorViewModel vm)
        {
            var depts = await _deptRepo.GetAllAsync();
            vm.Departments = depts
                .Select(d => new SelectListItem {
                    Value    = d.Id.ToString(),                      
                    Text     = d.Name,
                    Selected = d.Id == vm.SelectedDepartmentId       
                })
                .ToList();

            
            vm.Departments.Insert(0, new SelectListItem {
                Value = "",
                Text  = "-- اختر إدارة --"
            });
        }
    }
}
