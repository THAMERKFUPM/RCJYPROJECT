using Microsoft.AspNetCore.Mvc;
using UserManagement02.Interfaces;
using UserManagement02.ViewModels;
using AutoMapper;

public class ServicesDashboardViewComponent : ViewComponent
{
    private readonly ITraineeRepo _traineeRepo;
    private readonly IMapper _mapper;

    public ServicesDashboardViewComponent(ITraineeRepo traineeRepo, IMapper mapper)
    {
        _traineeRepo = traineeRepo;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync(string role)
    {
        var trainees = (await _traineeRepo.GetAllAsync()).ToList();

        var vm = new HumanResourceIndexViewModel
        {
            TotalEmployees = trainees.Count,
            ActiveEmployees = trainees.Count(t => t.IsActive),
            InactiveEmployees = trainees.Count(t => !t.IsActive),
            Items = _mapper.Map<List<TraineeViewModel>>(trainees)
        };

        return View(vm); // Views/Shared/Components/ServicesDashboard/Default.cshtml
    }
}