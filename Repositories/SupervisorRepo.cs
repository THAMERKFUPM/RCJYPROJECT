using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Models;

namespace UserManagement02.Repositories
{
    public class SupervisorRepo : ISupervisorRepo
    {
        private readonly ApplicationDbContext _context;
        public SupervisorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public async Task<IEnumerable<Supervisor>> GetAllSupervisor() =>
=======
<<<<<<< HEAD
        public async Task<IEnumerable<Supervisor>> GetAllSupervisors() =>
=======
        public async Task<IEnumerable<Supervisor>> GetAllSupervisor() =>
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            await _context.Supervisors.ToListAsync();

        public async Task<Supervisor?> GetSupervisor(int id) =>
            await _context.Supervisors.FindAsync(id);

        public async Task CreateAsync(Supervisor supervisor)
        {
            _context.Supervisors.Add(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supervisor supervisor)
        {
            _context.Supervisors.Update(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
            var sup = await _context.Supervisors.FindAsync(id);
            if (sup != null)
            {
                _context.Supervisors.Remove(sup);
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            var supervisor = await _context.Supervisors.FindAsync(id);
            if (supervisor != null)
            {
                _context.Supervisors.Remove(supervisor);
<<<<<<< HEAD
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
                await _context.SaveChangesAsync();
            }
        }
    }
}