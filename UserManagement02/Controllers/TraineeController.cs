using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;



        public TraineeController(
            ITraineeRepo repo,
            ISupervisorRepo srepo,
            IDepartmentRepo drepo,
            IMapper mapper,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)


        {
            _repo = repo;
            _srepo = srepo;
            _drepo = drepo;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;


        }
        // GET: /Trainee/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new TraineeChangePasswordViewModel());
        }

        // POST: /Trainee/ChangePassword
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(TraineeChangePasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            // find the user by email
            var user = await _userManager.FindByEmailAsync(vm.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "«·»—Ìœ €Ì— „”Ã·.");
                return View(vm);
            }

            // generate a reset token and apply the new password
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, vm.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var e in result.Errors)
                    ModelState.AddModelError("", e.Description);
                return View(vm);
            }

            TempData["Success"] = " „  €ÌÌ— ﬂ·„… «·„—Ê— »‰Ã«Õ.";
            return RedirectToAction("Login", "Trainee");
        }


        // GET: /Trainee/ChangePasswordConfirmation
        [HttpGet]
        public IActionResult ChangePasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new TraineeLoginViewModel());
        }

        // POST: /Trainee/Login
        [HttpPost]
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

            ModelState.AddModelError(string.Empty, "»Ì«‰«  «·œŒÊ· €Ì— ’ÕÌÕ…");
            return View(vm);
        }

        // POST: /Trainee/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateTraineeViewModel());
        }

        [HttpPost]
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

            var vm = new TraineeAssignViewModel
            {
                TraineeId = ent.TraineeId,
                FullName = ent.FullName,
                SelectedDepartmentId = ent.DepartmentId.GetValueOrDefault(),
                SelectedSupervisorId = ent.SupervisorId.GetValueOrDefault()
            };

            await PopulateLists(vm);
            return View(vm);
        }

        [HttpPost,]
        public async Task<IActionResult> Assign(TraineeAssignViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                await PopulateLists(vm);
                return View(vm);
            }

            var ent = await _repo.GetByIdAsync(vm.TraineeId);
            ent.DepartmentId = vm.SelectedDepartmentId;
            ent.SupervisorId = vm.SelectedSupervisorId;
            await _repo.UpdateAsync(ent);

            return RedirectToAction("Dashboard", "HumanResources");
        }

        private async Task PopulateLists(TraineeAssignViewModel vm)
        {
            var depts = await _drepo.GetAllAsync();
            vm.Departments = new SelectList(depts, "Id", "DepartmentName", vm.SelectedDepartmentId);

            var sups = await _srepo.GetAllSupervisor();
            vm.Supervisor = new SelectList(sups, "SupervisorId", "SupervisorFullName", vm.SelectedSupervisorId);
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
    }
}
