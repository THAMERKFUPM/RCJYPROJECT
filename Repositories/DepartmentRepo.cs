using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement02.Models;
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587

namespace UserManagement02.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationDbContext _ctx;
        public DepartmentRepo(ApplicationDbContext ctx) => _ctx = ctx;

<<<<<<< HEAD
        public async Task<IEnumerable<Department>> GetAllAsync() =>
            await _ctx.Departments.ToListAsync();
    }
}
=======

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            
            return await _ctx.Departments.ToListAsync();
        }
        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _ctx.Departments.FindAsync(id);
        }
        public async Task UpdateAsync(Department department)
        {
            _ctx.Departments.Update(department);
            await _ctx.SaveChangesAsync();
        }

    }
}



>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
