using UserManagement02.Models;

namespace UserManagement02;

public interface IUserRepo
{
     Task<List<AppUser>> GetAllUsers();
}