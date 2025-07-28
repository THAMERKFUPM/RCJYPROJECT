using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Models;

namespace UserManagement02.Interfaces
{
    public interface IDepartmentRepo
    {
<<<<<<< HEAD
        Task<IEnumerable<Department>> GetAllAsync();
=======
     
        
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task UpdateAsync(Department department);

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
    }
}