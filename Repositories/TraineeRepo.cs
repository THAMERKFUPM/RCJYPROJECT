using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Repositories
{
<<<<<<< HEAD
=======
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
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

    public class TraineeRepo : ITraineeRepo
    {

        private readonly ApplicationDbContext _ctx;

        public TraineeRepo(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Trainee>> GetAllAsync() =>
            await _ctx.Trainees.ToListAsync();

        public async Task<Trainee> GetByIdAsync(int id) =>
            await _ctx.Trainees.FindAsync(id);
<<<<<<< HEAD
        public async Task<Trainee?> GetByEmailAsync(string email)
        => await _ctx.Trainees
                     .Include(t => t.Department)
                     .Include(t => t.Supervisor)
                     .FirstOrDefaultAsync(t => t.Email == email);
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8

        public async Task CreateAsync(Trainee t)
        {
            _ctx.Trainees.Add(t);
<<<<<<< HEAD
=======
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trainee t)
        {
<<<<<<< HEAD
            _ctx.Trainees.Update(t);
=======
<<<<<<< HEAD
            _ctx.Trainee.Update(t);
=======
            _ctx.Trainees.Update(t);
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
            var t = await _ctx.Trainee.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainee.Remove(t);
                await _ctx.SaveChangesAsync();
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            var t = await _ctx.Trainees.FindAsync(id);
            if (t != null)
            {
                _ctx.Trainees.Remove(t);
                await _ctx.SaveChangesAsync();
                Console.WriteLine("[DEBUG] SaveChangesAsync Executed");
<<<<<<< HEAD


=======
                

>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            }
        }

        public Task<int> GetTotalTraineesAsync() =>
<<<<<<< HEAD
=======
<<<<<<< HEAD
            _ctx.Trainee.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainee.CountAsync(t => !t.IsActive);
       
    }
    
}
=======
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
            _ctx.Trainees.CountAsync();

        public Task<int> GetActiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => t.IsActive);

        public Task<int> GetInactiveTraineesAsync() =>
            _ctx.Trainees.CountAsync(t => !t.IsActive);
<<<<<<< HEAD

    }


}
=======
       
    }
    
    
}
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
