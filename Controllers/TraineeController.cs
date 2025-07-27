using System;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ITraineeRepo _repo;
        private readonly ISupervisorRepo _srepo;
        private readonly IDepartmentRepo _drepo;
        private readonly IMapper _mapper;

        public TraineeController(
            ITraineeRepo repo,
            ISupervisorRepo srepo,
            IDepartmentRepo drepo,
            IMapper mapper)
        {
            _repo = repo;
            _srepo = srepo;
            _drepo = drepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTraineeViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTraineeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var trainee = new Trainee
            {
                FullName = vm.FullName,
                Email = vm.Email,
                UniversityName = vm.UniversityName,
                Major = vm.Major,
                PhoneNumber = vm.PhoneNumber,
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.CreateAsync(trainee);
            return RedirectToAction("Dashboard", "HumanResources");
        }

        [HttpGet]
        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

            var vm = new AssignSupervisorToDepartmentViewModel
            {
                TraineeId = ent.TraineeId,
                FullName = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId ?? 0,
                SelectedSupervisorId = ent.SupervisorId ?? 0
            };

            await PopulateLists(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(AssignSupervisorToDepartmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateLists(vm);
                return View(vm);
            }

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
            if (ent == null) return NotFound();

            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }

        private async Task PopulateLists(AssignSupervisorToDepartmentViewModel vm)
        {
            var depts = await _drepo.GetAllAsync();
            vm.Departments = depts.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.DepartmentName
            });

            var sups = await _srepo.GetAllSupervisor();
            vm.Supervisors = sups.Select(s => new SelectListItem
            {
                Value = s.SupervisorId.ToString(),
                Text = s.SupervisorFullName
            });
        }

        public async Task<IActionResult> Index()
        {
            var trainees = await _repo.GetAllAsync();
            var vmList = trainees.Select(t => new TraineeViewModel
            {
                TraineeId = t.TraineeId,
                FullName = t.FullName,
                Email = t.Email,
                UniversityName = t.UniversityName,
                Major = t.Major,
                PhoneNumber = t.PhoneNumber,
                IsActive = t.IsActive,
                CreatedAt = t.CreatedAt
            }).ToList();

            return View(vmList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var trainee = await _repo.GetByIdAsync(id);
            if (trainee == null)
                return NotFound();

            var viewModel = _mapper.Map<TraineeViewModel>(trainee);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TraineeViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var trainee = new Trainee
            {
                TraineeId = viewModel.TraineeId,
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                UniversityName = viewModel.UniversityName,
                Major = viewModel.Major,
                PhoneNumber = viewModel.PhoneNumber,
            };

            await _repo.UpdateAsync(trainee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var trainee = await _repo.GetByIdAsync(id);
            if (trainee == null)
                return NotFound();

            var viewModel = _mapper.Map<TraineeViewModel>(trainee);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
