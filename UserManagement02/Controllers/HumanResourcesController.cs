using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement02.Interfaces;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers;

public class HumanResourcesController : Controller
{
    private readonly ITraineeRepo _trepo;
    private readonly IDepartmentRepo _departmentRepo;
    private readonly ISupervisorRepo _supervisorRepo;
    private readonly IMapper _mapper;

    public HumanResourcesController(
        ITraineeRepo trepo,
        IDepartmentRepo departmentRepo,
        ISupervisorRepo supervisorRepo,
        IMapper mapper)
    {
        _trepo = trepo;
        _departmentRepo = departmentRepo;
        _supervisorRepo = supervisorRepo;
        _mapper = mapper;
    }

    public async Task<IActionResult> Dashboard(string searchTerm = "")
    {
        var list = (await _trepo.GetAllAsync()).ToList();
        if (!string.IsNullOrWhiteSpace(searchTerm))
            list = list.Where(t =>
                t.FullName.Contains(searchTerm) ||
                t.Email.Contains(searchTerm)).ToList();

        var vm = new HumanResourceIndexViewModel
        {
            TotalEmployees = await _trepo.GetTotalTraineesAsync(),
            ActiveEmployees = await _trepo.GetActiveTraineesAsync(),
            InactiveEmployees = await _trepo.GetInactiveTraineesAsync(),
            SearchTerm = searchTerm,
            Items = _mapper.Map<List<TraineeViewModel>>(list)
        };
        return View(vm);
    }
   
    [HttpGet]
    public async Task<IActionResult> Transfer()
    {
        var trainees = await _trepo.GetAllAsync();
        var departments = await _departmentRepo.GetAllAsync();

        var vm = new TransferTraineeViewModel
        {
            Trainee = trainees
                .Select(t => new SelectListItem(
                    text: t.FullName,
                    value: t.TraineeId.ToString())),
            Departments = departments
                .Select(d => new SelectListItem(
                    text: d.DepartmentName,
                    value: d.Id.ToString()))
        };
        return View(vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Transfer(TransferTraineeViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var trainee = await _trepo.GetByIdAsync(vm.TraineeId!.Value);
        trainee.DepartmentId = vm.DepartmentId!.Value;
        await _trepo.UpdateAsync(trainee);

        TempData["Success"] = "تم تحويل الطالب بنجاح";
        return RedirectToAction(nameof(Dashboard));
    }



    [HttpGet]

    public async Task<IActionResult> AssignSupervisorToDepartment()
    {
        var departments = await _departmentRepo.GetAllAsync();
        var supervisors = await _supervisorRepo.GetAllSupervisor();

        var vm = new AssignSupervisorToDepartmentViewModel
        {
            Departments = new SelectList(departments, "Id", "DepartmentName"),
            Supervisors = new SelectList(supervisors, "SupervisorId", "FullName")
        };

        return View(vm);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignSupervisorToDepartment(AssignSupervisorToDepartmentViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            var departments = await _departmentRepo.GetAllAsync();
            var supervisors = await _supervisorRepo.GetAllSupervisor();
            vm.Departments = new SelectList(departments, "Id", "DepartmentName");
            vm.Supervisors = new SelectList(supervisors, "SupervisorId", "FullName");
            return View(vm);
        }

        var dept = await _departmentRepo.GetByIdAsync(vm.SelectedDepartmentId);
        if (dept == null) return NotFound();

        dept.SupervisorId = vm.SelectedSupervisorId;
        await _departmentRepo.UpdateAsync(dept);

        return RedirectToAction("Dashboard");
    }
}
