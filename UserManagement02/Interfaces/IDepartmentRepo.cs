using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Models;

namespace UserManagement02.Interfaces
{
    public interface IDepartmentRepo
    {
     
        
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task UpdateAsync(Department department);

    }
}