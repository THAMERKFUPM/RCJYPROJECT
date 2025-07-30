using UserManagement02.Models;

namespace UserManagement02;

public interface ISupervisorRepo
{
    Task<IEnumerable<Supervisor>> GetAllSupervisor();
    Task<Supervisor?> GetSupervisor(int id);
    Task CreateAsync(Supervisor supervisor);
    Task UpdateAsync(Supervisor supervisor);
    Task DeleteAsync(int id);

}