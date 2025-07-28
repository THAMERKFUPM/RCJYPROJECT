using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Repositories
{
<<<<<<< HEAD
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
=======

    public class TraineeRepo : ITraineeRepo
    {

        private readonly ApplicationDbContext _ctx;

        public TraineeRepo(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Trainee>> GetAllAsync() =>
            await _ctx.Trainees.ToListAsync();

        public async Task<Trainee> GetByIdAsync(int id) =>
            await _ctx.Trainees.FindAsync(id);

        public async Task CreateAsync(Trainee t)
        {
            _ctx.Trainees.Add(t);
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trainee t)
        {
<<<<<<< HEAD
            _ctx.Trainee.Update(t);
=======
            _ctx.Trainees.Update(t);
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
<<<<<<< HEAD
            var t = await _ctx.Trainee.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainee.Remove(t);
                await _ctx.SaveChangesAsync();
=======
            var t = await _ctx.Trainees.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainees.Remove(t);
                await _ctx.SaveChangesAsync();
                Console.WriteLine("[DEBUG] SaveChangesAsync Executed");
                

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
            }
        }

        public Task<int> GetTotalTraineesAsync() =>
<<<<<<< HEAD
            _ctx.Trainee.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => !t.IsActive);
       
    }
    
}
=======
            _ctx.Trainees.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => !t.IsActive);
       
    }
    
    
}
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
