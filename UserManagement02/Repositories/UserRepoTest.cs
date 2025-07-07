using UserManagement02.Models;

namespace UserManagement02.Repositories;

public class UserRepoTest :  IUserRepo
{
    public async Task<List<AppUser>> GetAllUsers()
    {
        return  new List<AppUser>();
    }
}