namespace LogicApp.Contravts.Users;

public record RegisertUserRequest(
    string UserName,
    string Password
    );