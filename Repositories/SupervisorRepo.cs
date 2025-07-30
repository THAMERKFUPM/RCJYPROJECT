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

        public async Task<IEnumerable<Supervisor>> GetAllSupervisor() =>
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
            var supervisor = await _context.Supervisors.FindAsync(id);
            if (supervisor != null)
            {
                _context.Supervisors.Remove(supervisor);
                await _context.SaveChangesAsync();
            }
        }
    }
}