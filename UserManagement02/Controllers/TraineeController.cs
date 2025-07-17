using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement02.Interfaces;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo    _repo;
        private readonly ISupervisorRepo _srepo;
        private readonly IDepartmentRepo _drepo;
        private readonly IMapper         _mapper;

        public TraineeController(
            ITraineeRepo      repo,
            ISupervisorRepo   srepo,
            IDepartmentRepo   drepo,
            IMapper           mapper)
        {
            _repo   = repo;
            _srepo  = srepo;
            _drepo  = drepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vm = new TraineeViewModel();
            await PopulateLists(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TraineeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateLists(vm);
                return View(vm);
            }

            var entity = _mapper.Map<Trainee>(vm);
            await _repo.CreateAsync(entity);
            return RedirectToAction("Dashboard", "HumanResources");
        }

        [HttpGet]
        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

            var vm = new TraineeAssignViewModel
            {
                TraineeId            = ent.TraineeId,
                FullName             = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId,
                SelectedSupervisorId = ent.SupervisorId
            };

            await PopulateLists(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(TraineeAssignViewModel vm)
        {
            if (!ModelState.IsValid)
                return await Assign(vm.TraineeId);

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }

        // ——— Populates dropdowns for Create/Edit ———
        private async Task PopulateLists(TraineeViewModel vm)
        {
            var depts = await _drepo.GetAllAsync();
            vm.Departments = new SelectList(
                depts,
                "DepartmentId",
                "DepartmentName",
                vm.SelectedDepartmentId);

            var sups = await _srepo.GetAllSupervisor();
            vm.Supervisor = new SelectList(
                sups,
                "SupervisorId",
                "FullName",
                vm.SelectedSupervisorId);
        }

        // ——— Populates dropdowns for Assign ———
        private async Task PopulateLists(TraineeAssignViewModel vm)
        {
            var depts = await _drepo.GetAllAsync();
            vm.Departments = new SelectList(
                depts,
                "DepartmentId",
                "DepartmentName",
                vm.SelectedDepartmentId);

            var sups = await _srepo.GetAllSupervisor();
            vm.Supervisor = new SelectList(
                sups,
                "SupervisorId",
                "FullName",
                vm.SelectedSupervisorId);
        }
    }
}
