using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Interfaces
{
    public interface ITransferService
    {
        Task<IEnumerable<Trainee>> GetAllTraineesAsync();
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task AssignTraineeToDepartmentAsync(int traineeId, int departmentId);
    }
}

