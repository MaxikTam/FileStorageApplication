using LogicApp.DbAccess.Repositoryes;
using LogicApp.Infrastructure;
using LogicApp.Models;

namespace LogicApp.Services;

public class UserService
{
    private readonly PasswordHasher _passwordHasher = new();
    private readonly UserRepository _userRepository;
    private readonly JwtProvider _jwtProvider;

    public UserService(JwtProvider jwtProvider, UserRepository userRepository)
    {
        _jwtProvider = jwtProvider;
        _userRepository = userRepository;
    }
    public async Task Register(string userName, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);
        var user = new User()
        {
            Name = userName,
            PasswordHash = hashedPassword
        };

        await _userRepository.Add(user);
    }

    public async Task<string> Login(string userName, string password)
    {
        var user = await _userRepository.GetByUserName(userName);

        if (!_passwordHasher.Verify(password, user.PasswordHash))
        {
            throw new Exception("Failed to login!");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
    
    
}