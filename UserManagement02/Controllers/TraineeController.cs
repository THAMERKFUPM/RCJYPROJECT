using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement02.Interfaces;
using UserManagement02.Models;
using UserManagement02.ViewModels;
//TEST

namespace UserManagement02.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepo _repo;
        private readonly ISupervisorRepo _srepo;
        private readonly IDepartmentRepo _drepo;
        private readonly IMapper _mapper;
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

            // 1) dropdown
            var all = await _repo.GetAllAsync();
            vm.Trainees = all
              .Select(t => new SelectListItem(t.FullName, t.TraineeId.ToString(),
                                              t.TraineeId == SelectedTraineeId))
              .ToList();

            if (SelectedTraineeId.HasValue)
            {
                // 2) load trainee info
                var t = await _repo.GetByIdAsync(SelectedTraineeId.Value);
                vm.SelectedTraineeId = t.TraineeId;
                vm.FullName = t.FullName;
                vm.Major = t.Major;
                vm.UniversityName = t.UniversityName;
                vm.StartDate = t.StartDate;
                vm.EndDate = t.EndDate;

                // 3) load history
                vm.History = (await _eRepo.GetByTraineeAsync(t.TraineeId))
                                .ToList();
            }

            return View(vm);
        }

        // POST: /Trainee/Evaluate
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
            {
                // reload history so table stays visible even on error
                vm.History = (await _eRepo.GetByTraineeAsync(vm.SelectedTraineeId))
                                .ToList();
                return View(vm);
            }

            // 1) persist new evaluation
            var eval = new Evaluation
            {
                TraineeId = vm.SelectedTraineeId,
                Enthusiasm = vm.Enthusiasm,
                Accuracy = vm.Accuracy,
                Quality = vm.Quality,
                Initiative = vm.Initiative,
                Teamwork = vm.Teamwork,
                Dependability = vm.Dependability,
                DecisionPower = vm.DecisionPower,
                LearningAbility = vm.LearningAbility,
                Score = vm.OverallScore
            };
            await _eRepo.CreateAsync(eval);

            // 2) re‐load trainee info & history
            var t = await _repo.GetByIdAsync(vm.SelectedTraineeId);
            vm.FullName = t.FullName;
            vm.Major = t.Major;
            vm.UniversityName = t.UniversityName;
            vm.StartDate = t.StartDate;
            vm.EndDate = t.EndDate;

            vm.History = (await _eRepo.GetByTraineeAsync(vm.SelectedTraineeId))
                            .ToList();

            // 3) render the same view with the updated table
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

            ModelState.AddModelError("", "بيانات الدخول غير صحيحة");
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTraineeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            // 1) Save trainee record to your own table
            var trainee = new Trainee
            {
                FullName = vm.FullName,
                Email = vm.Email,
                UniversityName = vm.UniversityName,
                Major = vm.Major,
                PhoneNumber = vm.PhoneNumber,
                IsActive = vm.IsActive,
                CreatedAt = DateTime.UtcNow,
                StartDate = vm.StartDate,
                EndDate = vm.EndDate
            };
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

            // 3) Give them the “Intern” role
            await _userManager.AddToRoleAsync(user, "Intern");

            return RedirectToAction("Dashboard", "HumanResources");
        }


        //
        // ASSIGN (Supervisor + Dept)
        //
        [HttpGet]
        public async Task<IActionResult> Assign(int id)
        {
            var ent = await _repo.GetByIdAsync(id);
            if (ent == null) return NotFound();

            var vm = new TraineeAssignViewModel
            {
                TraineeId = ent.TraineeId,
                FullName = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId.GetValueOrDefault(),
                SelectedSupervisorId = ent.SupervisorId.GetValueOrDefault(),
                StartDate = ent.StartDate,
                EndDate = ent.EndDate
            };
            await PopulateLists(vm);
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(TraineeAssignViewModel vm)
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
            ent.StartDate = vm.StartDate;
            ent.EndDate = vm.EndDate;
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }

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
            return View(vmList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
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
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
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
                ModelState.AddModelError("", "البريد غير مسجل.");
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

            TempData["Success"] = "تم تغيير كلمة المرور بنجاح.";
            return RedirectToAction(nameof(ChangePasswordConfirmation));
        }


        [HttpGet]
        public IActionResult ChangePasswordConfirmation()
            => View();
    }
}
