<<<<<<< HEAD
=======
using System;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
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
<<<<<<< HEAD
        private readonly ITraineeRepo     _repo;
        private readonly ISupervisorRepo  _srepo;
        private readonly IMapper          _mapper;
=======
        private readonly ITraineeRepo _repo;
        private readonly ISupervisorRepo _srepo;
        private readonly IDepartmentRepo _drepo;
        private readonly IMapper _mapper;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

        public TraineeController(
            ITraineeRepo repo,
            ISupervisorRepo srepo,
<<<<<<< HEAD
            IMapper mapper)
        {
            _repo   = repo;
            _srepo  = srepo;
            _mapper = mapper;
        }
        

=======
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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

<<<<<<< HEAD
            
            var departments = new[]
            {
                new { Id = 1, Name = "تقنية المعلومات" },
                new { Id = 2, Name = "العقود"       },
                new { Id = 3, Name = "الاستثمار"    }
            };

            
            var vm = new TraineeAssignViewModel
            {
                TraineeId             = ent.TraineeId,
                FullName              = ent.FullName,
                SelectedDepartmentId  = ent.DepartmentId,
                Departments           = new SelectList(departments, "Id", "Name", ent.DepartmentId),
                SelectedSupervisorId  = ent.SupervisorId,
                Supervisors           = new SelectList(
                                            await _srepo.GetAllSupervisors(),
                                            "SupervisorId",
                                            "FullName",
                                            ent.SupervisorId)
            };

=======
            var vm = new AssignSupervisorToDepartmentViewModel
            {
                TraineeId = ent.TraineeId,
                FullName = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId ?? 0,
                SelectedSupervisorId = ent.SupervisorId ?? 0
            };

            await PopulateLists(vm);
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Assign(TraineeAssignViewModel vm)
        {
            if (!ModelState.IsValid)
                return await Assign(vm.TraineeId);

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
=======
        public async Task<IActionResult> Assign(AssignSupervisorToDepartmentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateLists(vm);
                return View(vm);
            }

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
            if (ent == null) return NotFound();

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }
<<<<<<< HEAD
        [HttpGet]
        public IActionResult Create()
        {
            var vm = new TraineeViewModel();
            return View(vm); // this will return Views/Trainees/Create.cshtml
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TraineeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = _mapper.Map<Trainee>(vm);
            await _repo.CreateAsync(entity);

            return RedirectToAction("Dashboard", "HumanResources");
        }

=======

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
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
    }
}
