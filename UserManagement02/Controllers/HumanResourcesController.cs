using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement02.Interfaces;
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    public class HumanResourcesController : Controller
    {
        private readonly ITraineeRepo _trepo;
        private readonly IMapper      _mapper;

        public HumanResourcesController(ITraineeRepo trepo, IMapper mapper)
        {
            _trepo  = trepo;
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
                TotalEmployees    = await _trepo.GetTotalTraineesAsync(),
                ActiveEmployees   = await _trepo.GetActiveTraineesAsync(),
                InactiveEmployees = await _trepo.GetInactiveTraineesAsync(),
                SearchTerm        = searchTerm,
                Items             = _mapper.Map<List<TraineeViewModel>>(list)
            };
            return View(vm);
        }
    }
}