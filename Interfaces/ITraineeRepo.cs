using UserManagement02.Models;

namespace UserManagement02.Interfaces;


    public interface ITraineeRepo
    {
        Task<IEnumerable<Trainee>> GetAllAsync();
        Task<Trainee> GetByIdAsync(int id);
        Task CreateAsync(Trainee t);
        Task UpdateAsync(Trainee t);
        Task DeleteAsync(int id);

        Task<int> GetTotalTraineesAsync();
        Task<int> GetActiveTraineesAsync();
        Task<int> GetInactiveTraineesAsync();
<<<<<<< HEAD
=======
       
       
>>>>>>> 1bfd4158136d1dfb77522d47ab4e5fe1576ea587
    }

