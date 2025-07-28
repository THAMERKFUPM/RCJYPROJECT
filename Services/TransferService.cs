using UserManagement02.Interfaces;
using UserManagement02.Models;

namespace UserManagement02.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITraineeRepo _traineeRepo;
        private readonly IDepartmentRepo _deptRepo;

        public TransferService(ITraineeRepo traineeRepo, IDepartmentRepo deptRepo)
        {
            _traineeRepo = traineeRepo;
            _deptRepo = deptRepo;
        }

        public Task<IEnumerable<Trainee>> GetAllTraineesAsync() =>
            _traineeRepo.GetAllAsync();

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync() =>
            _deptRepo.GetAllAsync();

        public async Task AssignTraineeToDepartmentAsync(int traineeId, int departmentId)
        {
            var trainee = await _traineeRepo.GetByIdAsync(traineeId);
            trainee.DepartmentId = departmentId;
            await _traineeRepo.UpdateAsync(trainee);
        }
    }
}
