namespace User.Web.Api.Users.RegisterUser
{
    public record RegisterUserCommand(string UserName, string Email, string Nickname, string Password, 
        string? FirstName, string? LastName, DateOnly BirthDate, string? PhotoLink);
}