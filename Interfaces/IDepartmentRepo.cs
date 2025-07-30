using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Models;

namespace UserManagement02.Interfaces
{
    public interface IDepartmentRepo
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
        Task<IEnumerable<Department>> GetAllAsync();
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
     
        
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task UpdateAsync(Department department);

<<<<<<< HEAD
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
    }
}