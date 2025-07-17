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
            await _context.Supervisor.ToListAsync();

        public async Task<Supervisor?> GetSupervisor(int id) =>
            await _context.Supervisor.FindAsync(id);

        public async Task CreateAsync(Supervisor supervisor)
        {
            _context.Supervisor.Add(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supervisor supervisor)
        {
            _context.Supervisor.Update(supervisor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sup = await _context.Supervisor.FindAsync(id);
            if (sup != null)
            {
                _context.Supervisor.Remove(sup);
                await _context.SaveChangesAsync();
            }
        }
    }
}