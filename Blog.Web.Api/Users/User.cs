namespace User.Web.Api.Users
{
    public class User
    {
        public Guid Id { get; set; }
        
        public required string UserName { get; set; }
        public required string NormalizedUserName { get; set; }

        public required string Email { get; set; }
        public required string NormalizedEmail { get; set; }
        public bool? EmailConfirmed { get; set; }
        
        public string? PasswordHash { get; set; }

        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public string? PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }

        public bool? TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
        public bool? LockoutEnabled { get; set; }

        public int? AccessFailedCount { get; set; }

        public required string Nickname { get; set; }
        public required string Role { get; set; }
    }
}