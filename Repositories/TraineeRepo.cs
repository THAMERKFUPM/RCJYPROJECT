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
            await _ctx.Trainee.ToListAsync();

        public async Task<Trainee> GetByIdAsync(int id) =>
            await _ctx.Trainee.FindAsync(id);

        public async Task CreateAsync(Trainee t)
        {
            _ctx.Trainee.Add(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trainee t)
        {
            _ctx.Trainee.Update(t);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var t = await _ctx.Trainee.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainee.Remove(t);
                await _ctx.SaveChangesAsync();
            }
        }

        public Task<int> GetTotalTraineesAsync() =>
            _ctx.Trainee.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => !t.IsActive);
       
    }
    
}