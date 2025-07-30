using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Repositories
{

    public class TraineeRepo : ITraineeRepo
    {

        private readonly ApplicationDbContext _ctx;

        public TraineeRepo(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Trainee>> GetAllAsync() =>
            await _ctx.Trainees.ToListAsync();

        public async Task<Trainee> GetByIdAsync(int id) =>
            await _ctx.Trainees.FindAsync(id);
        public async Task<Trainee?> GetByEmailAsync(string email)
        => await _ctx.Trainees
                     .Include(t => t.Department)
                     .Include(t => t.Supervisor)
                     .FirstOrDefaultAsync(t => t.Email == email);

        public async Task CreateAsync(Trainee t)
        {
            _ctx.Trainees.Add(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trainee t)
        {
            _ctx.Trainees.Update(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var t = await _ctx.Trainees.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainees.Remove(t);
                await _ctx.SaveChangesAsync();
                Console.WriteLine("[DEBUG] SaveChangesAsync Executed");


            }
        }

        public Task<int> GetTotalTraineesAsync() =>
            _ctx.Trainees.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => !t.IsActive);

    }


}