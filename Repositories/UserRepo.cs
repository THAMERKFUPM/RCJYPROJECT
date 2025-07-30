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



    public async Task<List<AppUser>> GetAllUsers()
    {
        var list = await _context.AppUsers.ToListAsync();

        return list;
    }
}