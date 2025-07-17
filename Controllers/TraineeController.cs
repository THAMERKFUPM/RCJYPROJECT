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
        private readonly ITraineeRepo     _repo;
        private readonly ISupervisorRepo  _srepo;
        private readonly IMapper          _mapper;

        public TraineeController(
            ITraineeRepo repo,
            ISupervisorRepo srepo,
            IMapper mapper)
        {
            _repo   = repo;
            _srepo  = srepo;
            _mapper = mapper;
        }
        

        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

            
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

    }
}
