// Repositories/EvaluationRepo.cs
using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Repositories
{
    public class EvaluationRepo : IEvaluationRepo
    {
        private readonly ApplicationDbContext _ctx;
        public EvaluationRepo(ApplicationDbContext ctx) => _ctx = ctx;

        public async Task<IEnumerable<Evaluation>> GetByTraineeAsync(int traineeId)
            => await _ctx.Evaluations
                         .Include(e => e.Trainee)
                         .Where(e => e.TraineeId == traineeId)
                         .ToListAsync();

        public async Task CreateAsync(Evaluation e)
        {
            _ctx.Evaluations.Add(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
