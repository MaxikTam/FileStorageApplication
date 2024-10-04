namespace LogicApp.Contravts.Users;

public record LoginUserRequest(
    string Name,
    string Password
    );