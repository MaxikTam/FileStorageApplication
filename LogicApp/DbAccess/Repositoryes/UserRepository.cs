using LogicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogicApp.DbAccess.Repositoryes;

public class UserRepository(FileStorageDbContext context)
{
    public async Task Add(User user)
    {
        var userEntity = new User()
        {
            Id = user.Id,
            Name = user.Name,
            PasswordHash = user.PasswordHash,
            Role = user.Role
        };

        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
    }

    public async Task<User> GetByUserName(string name)
    {
        var userEntity = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Name == name) ?? throw new Exception();
        
        return userEntity;
    }
}