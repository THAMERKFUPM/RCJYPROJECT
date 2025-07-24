using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Services
{
    public class TraineeScopeService : ITraineeScopeService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<AppUser> _userManager;

        public TraineeScopeService(ApplicationDbContext ctx, UserManager<AppUser> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<UserScopeMeta> GetMetaAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            var roles = await _userManager.GetRolesAsync(user);

            var meta = new UserScopeMeta
            {
                IsHR = roles.Contains("HR"),
                IsSupervisor = roles.Contains("Supervisor"),
                IsSectionManager = roles.Contains("SectionManager")
            };

            if (meta.IsSupervisor)
            {
                meta.SupervisorDepartmentId = await _ctx.Supervisors
                    .Where(s => s.AppUserId == user.Id)
                    .Select(s => (int?)s.DepartmentId)
                    .FirstOrDefaultAsync();
            }

            if (meta.IsSectionManager)
            {
                meta.SectionManagerDepartmentId = await _ctx.SectionManager
                    .Where(sm => sm.AppUserId == user.Id)
                    .Select(sm => (int?)sm.DepartmentId)
                    .FirstOrDefaultAsync();
            }

            return meta;
        }

        public async Task<IQueryable<Trainee>> GetBaseQueryAsync(ClaimsPrincipal principal)
        {
            var meta = await GetMetaAsync(principal);

            var q = _ctx.Trainees
                .Include(t => t.Department)
                .Include(t => t.Supervisor)
                .AsQueryable();

            if (meta.IsHR)
                return q;

            if (meta.IsSupervisor)
            {
                if (meta.SupervisorDepartmentId.HasValue)
                    return q.Where(t => t.DepartmentId == meta.SupervisorDepartmentId.Value);
                return q.Where(t => false);
            }

            if (meta.IsSectionManager)
            {
                if (meta.SectionManagerDepartmentId.HasValue)
                    return q.Where(t => t.DepartmentId == meta.SectionManagerDepartmentId.Value);
                return q.Where(t => false);
            }

            return q.Where(t => false);
        }

        public async Task<string> GetScopeTitleAsync(ClaimsPrincipal principal)
        {
            var meta = await GetMetaAsync(principal);
            if (meta.IsHR) return "جميع المتدربين";
            if (meta.IsSupervisor) return "متدربو إدارتي";
            if (meta.IsSectionManager) return "متدربو القسم";
            return "غير مصرح";
        }
    }
}
