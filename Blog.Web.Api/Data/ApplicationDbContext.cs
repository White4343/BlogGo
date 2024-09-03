using Microsoft.EntityFrameworkCore;
using User.Web.Api.Data.EntityConfigurations;

namespace User.Web.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Users.UserModel>? Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ArgumentNullException.ThrowIfNull(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
