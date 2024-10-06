using System.Security;
using LogicApp.DbAccess.Repositoryes;
using LogicApp.Infrastructure;
using LogicApp.Models;

namespace LogicApp.Services;

public class UserService
{
    private readonly PasswordHasher _passwordHasher = new();
    private readonly UserRepository _userRepository;

    public UserService(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Register(string userName, string password)
    {
        if (! await _userRepository.IsUserNameUnique(userName))
        {
            return false;
        }
        
        var hashedPassword = _passwordHasher.Generate(password);
        var user = new User()
        {
            Name = userName,
            PasswordHash = hashedPassword
        };

        await _userRepository.Add(user);
        return true;
    }

    public async Task<User> Login(string userName, string password)
    {
        var user = await _userRepository.GetByUserName(userName);

        if (!_passwordHasher.Verify(password, user.PasswordHash))
        {
            throw new Exception("Failed to login!");
        }

        return user;
    }
    
    
}