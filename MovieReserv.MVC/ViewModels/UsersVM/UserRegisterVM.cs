namespace MovieReserv.MVC.ViewModels.UsersVM;

public record UserRegisterVM(string Fullname, string Username, string Email, string Password, string ConfirmPassword, string? PhoneNumber);

