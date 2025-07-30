using Microsoft.EntityFrameworkCore;
using UserManagement02.Data;
using UserManagement02.Models;

namespace UserManagement02.Repositories;

public class UserRepo : IUserRepo
{
    private readonly ApplicationDbContext _context;
    public UserRepo(ApplicationDbContext context)
    {
        _context = context;
    }


<<<<<<< HEAD

    public async Task<List<AppUser>> GetAllUsers()
    {
        var list = await _context.AppUsers.ToListAsync();

=======
    public async Task<List<AppUser>> GetAllUsers()
    {
        var list = await _context.AppUsers.ToListAsync();
>>>>>>> f925949ee1841caeac344a502fd49c7aec11fbc8
        return list;
    }
}