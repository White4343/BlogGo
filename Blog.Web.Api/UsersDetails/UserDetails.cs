namespace User.Web.Api.UsersDetails
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public required string MessagingAccess { get; set; }
        public DateOnly RegisterDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string? PhotoLink { get; set; }
        public required string UserId { get; set; }
    }
}
