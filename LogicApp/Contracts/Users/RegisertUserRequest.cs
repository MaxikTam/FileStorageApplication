using System.ComponentModel.DataAnnotations;
namespace LogicApp.Contravts.Users;
public class RegisertUserRequest
{
    [Required(ErrorMessage = "Строка не может быть пустрой")]
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 50 символов")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Строка не может быть пустрой")]
    [StringLength(50, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 50 символов")]
    public string Password { get; set; }
}