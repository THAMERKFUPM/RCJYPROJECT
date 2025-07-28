using UserManagement02.Models;

namespace UserManagement02;

public interface ISupervisorRepo
{
<<<<<<< HEAD
    Task<IEnumerable<Supervisor>> GetAllSupervisors();
=======
    Task<IEnumerable<Supervisor>> GetAllSupervisor();
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
    Task<Supervisor?> GetSupervisor(int id);
    Task CreateAsync(Supervisor supervisor);
    Task UpdateAsync(Supervisor supervisor);
    Task DeleteAsync(int id);

}