using LogicApp.Models.Enum;

namespace LogicApp.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string password { get; set; }
    public UserRole Role { get; set; }

}