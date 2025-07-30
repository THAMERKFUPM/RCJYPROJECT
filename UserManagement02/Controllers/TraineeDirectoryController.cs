using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;         
using UserManagement02.ViewModels;

namespace UserManagement02.Controllers
{
    [Authorize(Roles = "HR,Supervisor,SectionManager")]
    public class TraineeDirectoryController : Controller
    {
        private readonly ITraineeScopeService _scope;
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public TraineeDirectoryController(
            ITraineeScopeService scope,
            ApplicationDbContext ctx,
            IMapper mapper)
        {
            _scope = scope;
            _ctx = ctx;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index(string? search, string? sort, string? dir)
        {
            var baseQuery = await _scope.GetBaseQueryAsync(User);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                baseQuery = baseQuery.Where(t =>
                    t.FullName.Contains(term) ||
                    t.Major.Contains(term) ||
                    t.UniversityName.Contains(term));
            }

            bool desc = (dir?.ToLower() == "desc");
            baseQuery = sort?.ToLower() switch
            {
                "major" => (desc ? baseQuery.OrderByDescending(t => t.Major)
                                 : baseQuery.OrderBy(t => t.Major)),
                "uni" or "university" => (desc ? baseQuery.OrderByDescending(t => t.UniversityName)
                                               : baseQuery.OrderBy(t => t.UniversityName)),
                "dept" or "department" => (desc ? baseQuery.OrderByDescending(t => t.Department.DepartmentName)
                                                : baseQuery.OrderBy(t => t.Department.DepartmentName)),
                _ => (desc ? baseQuery.OrderByDescending(t => t.FullName)
                           : baseQuery.OrderBy(t => t.FullName))
            };

            var rows = await baseQuery
                .ProjectTo<TraineeRowVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

         
            var vm = new TraineeDirectoryVM
            {
                ScopeTitle     = await _scope.GetScopeTitleAsync(User),
                ShowDepartment = true,
                ShowSupervisor = User.IsInRole("HR") || User.IsInRole("SectionManager"),
                ShowEvaluation = false, 
                ShowAttendance = false, 
                Rows           = rows
            };

            ViewBag.Search = search;
            ViewBag.Sort   = sort;
            ViewBag.Dir    = desc ? "desc" : "asc";

            return View(vm);
        }
    }
}
