// Interfaces/IEvaluationRepo.cs
using UserManagement02.Models;
namespace UserManagement02.Interfaces
{
    public interface IEvaluationRepo
    {
        Task<IEnumerable<Evaluation>> GetByTraineeAsync(int traineeId);
        Task CreateAsync(Evaluation e);
    }
}
