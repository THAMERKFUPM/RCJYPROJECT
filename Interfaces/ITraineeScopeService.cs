using System.Security.Claims;
using UserManagement02.Models;

namespace UserManagement02.Interfaces;

public class UserScopeMeta //MOVE IT TO ANOTHER INTERFASE
{
    public bool IsHR { get; set; }
    public bool IsSupervisor { get; set; }
    public bool IsSectionManager { get; set; }
    public int? SupervisorDepartmentId { get; set; }
    public int? SectionManagerDepartmentId { get; set; }
}

public interface ITraineeScopeService
{
    Task<UserScopeMeta> GetMetaAsync(ClaimsPrincipal user);
    Task<IQueryable<Trainee>> GetBaseQueryAsync(ClaimsPrincipal user);
    Task<string> GetScopeTitleAsync(ClaimsPrincipal user);
}

