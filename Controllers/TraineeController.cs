<<<<<<< HEAD
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
=======
<<<<<<< HEAD
=======
using System;
using System.Linq;
using System.Threading.Tasks;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
using AutoMapper;
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
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
=======
<<<<<<< HEAD
        private readonly ITraineeRepo     _repo;
        private readonly ISupervisorRepo  _srepo;
        private readonly IMapper          _mapper;
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        private readonly ITraineeRepo _repo;
        private readonly ISupervisorRepo _srepo;
        private readonly IDepartmentRepo _drepo;
        private readonly IMapper _mapper;
<<<<<<< HEAD
        private readonly IEvaluationRepo _eRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public TraineeController(
            ITraineeRepo repo,
            IEvaluationRepo eRepo,
            ISupervisorRepo srepo,
            IDepartmentRepo drepo,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _repo = repo;
            _eRepo = eRepo;
            _srepo = srepo;
            _drepo = drepo;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //
        // LOGIN / LOGOUT
        //
        // Controllers/TraineeController.cs
        [HttpGet]
        public async Task<IActionResult> Evaluate(int? SelectedTraineeId)
        {
            var vm = new TraineeEvaluationViewModel();

            var all = await _repo.GetAllAsync();
            vm.Trainees = all
              .Select(t => new SelectListItem(t.FullName, t.TraineeId.ToString(),
                                              t.TraineeId == SelectedTraineeId))
              .ToList();

            if (SelectedTraineeId.HasValue)
            {
                var t = await _repo.GetByIdAsync(SelectedTraineeId.Value);
                vm.SelectedTraineeId = t.TraineeId;
                vm.FullName = t.FullName;
                vm.Major = t.Major;
                vm.UniversityName = t.UniversityName;
                vm.TrainingEnd = t.CreatedAt; // or your actual start/end date

                // Optionally pre-select defaults (or load saved eval)
                //vm.Enthusiasm = EvaluationLevel.�����;
                //vm.Accuracy = EvaluationLevel.�����;
                //vm.Quality = EvaluationLevel.�����;
                //vm.Initiative = EvaluationLevel.�����;
                //vm.Teamwork = EvaluationLevel.�����;
                //vm.Dependability = EvaluationLevel.�����;
                //vm.DecisionPower = EvaluationLevel.�����;
                //vm.LearningAbility = EvaluationLevel.�����;
            }

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Evaluate(TraineeEvaluationViewModel vm)
        {
            // repopulate dropdown
            var all = await _repo.GetAllAsync();
            vm.Trainees = all
              .Select(t => new SelectListItem(t.FullName, t.TraineeId.ToString(),
                                              t.TraineeId == vm.SelectedTraineeId))
              .ToList();

            if (!ModelState.IsValid)
                return View(vm);

            // at this point vm.OverallScore is already calculated
            // you could save it if you have an evaluation table

            return View(vm);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new TraineeLoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TraineeLoginViewModel vm, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid)
                return View(vm);

            var result = await _signInManager.PasswordSignInAsync(
                vm.Email, vm.Password, vm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Dashboard", "HumanResources");
            }

            ModelState.AddModelError("", "������ ������ ��� �����");
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


        //
        // CHANGE PASSWORD
        //
        


        //
        // CREATE (HR only)
        //
        [HttpGet]
        public IActionResult Create()
            => View(new CreateTraineeViewModel());
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTraineeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

<<<<<<< HEAD
            // 1) Save trainee record to your own table
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
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
<<<<<<< HEAD
            await _repo.CreateAsync(trainee);

            // 2) Provision AspNet Identity user with same email & password
            var user = new AppUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                FullName = vm.FullName,
                UniversityName = vm.UniversityName,
                PhoneNumber = vm.PhoneNumber,
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow
            };
            var createResult = await _userManager.CreateAsync(user, vm.Password);
            if (!createResult.Succeeded)
            {
                // roll back your trainee if you want, or just show errors
                foreach (var err in createResult.Errors)
                    ModelState.AddModelError("", err.Description);
                return View(vm);
            }

            // 3) Give them the �Intern� role
            await _userManager.AddToRoleAsync(user, "Intern");

            return RedirectToAction("Dashboard", "HumanResources");
        }


        //
        // ASSIGN (Supervisor + Dept)
        //
        [HttpGet]
=======

            await _repo.CreateAsync(trainee);
            return RedirectToAction("Dashboard", "HumanResources");
        }

        [HttpGet]
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

<<<<<<< HEAD
            var vm = new TraineeAssignViewModel
            {
                TraineeId = ent.TraineeId,
                FullName = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId.GetValueOrDefault(),
                SelectedSupervisorId = ent.SupervisorId.GetValueOrDefault(),
                StartDate = ent.StartDate
            };
            await PopulateLists(vm);
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Assign(TraineeAssignViewModel vm)
        {
            if (!ModelState.IsValid)
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            {
                await PopulateLists(vm);
                return View(vm);
            }

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
            if (ent == null) return NotFound();

<<<<<<< HEAD
            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
            ent.StartDate = vm.StartDate;
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }
<<<<<<< HEAD

        private async Task PopulateLists(TraineeAssignViewModel vm)
        {
            var depts = await _drepo.GetAllAsync();
            vm.Departments = new SelectList(depts, "Id", "DepartmentName", vm.SelectedDepartmentId);

            var sups = await _srepo.GetAllSupervisor();
            vm.Supervisors = new SelectList(sups, "SupervisorId", "SupervisorFullName", vm.SelectedSupervisorId);
        }


        //
        // INDEX / EDIT / DELETE
        //
        public async Task<IActionResult> Index()
        {
            var trainees = await _repo.GetAllAsync();
            var vmList = trainees.Select(t => _mapper.Map<TraineeViewModel>(t))
                                 .ToList();
=======
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

>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            return View(vmList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
<<<<<<< HEAD
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return NotFound();
            return View(_mapper.Map<TraineeViewModel>(t));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TraineeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var ent = _mapper.Map<Trainee>(vm);
            await _repo.UpdateAsync(ent);
            return RedirectToAction(nameof(Index));
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
<<<<<<< HEAD
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return NotFound();
            return View(_mapper.Map<TraineeViewModel>(t));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangePassword()
            => View(new TraineeChangePasswordViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(TraineeChangePasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "������ ��� ����.");
                return View(vm);
            }

            // Verify old password & change:
            var result = await _userManager.ChangePasswordAsync(
                              user,
                              vm.Password,
                              vm.NewPassword
                          );
            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                    ModelState.AddModelError("", e.Description);
                return View(vm);
            }

            TempData["Success"] = "�� ����� ���� ������ �����.";
            return RedirectToAction(nameof(ChangePasswordConfirmation));
        }


        [HttpGet]
        public IActionResult ChangePasswordConfirmation()
            => View();
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
    }
}
