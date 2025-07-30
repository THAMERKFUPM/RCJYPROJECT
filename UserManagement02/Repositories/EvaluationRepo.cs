using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task CreateAsync(Evaluation e)
        {
            _ctx.Evaluations.Add(e);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetByTraineeAsync(int traineeId)
            => await _ctx.Evaluations
                         .Include(x => x.Trainee)
                         .Where(x => x.TraineeId == traineeId)
                         .OrderByDescending(x => x.EvaluatedOn)
                         .ToListAsync();
    }
}
