#pragma warning disable CA1031

namespace User.Web.Api.Data
{
    public class DatabaseInitialization()
    {
        private readonly ApplicationDbContext? _context;
        private readonly ILogger<DatabaseInitialization>? _logger;

        private static readonly Action<ILogger, Exception?> _databaseCreationError =
            LoggerMessage.Define(LogLevel.Error, new EventId(1, "DatabaseCreationError"),
                $"An error occurred creating/initializing the DB");

        public DatabaseInitialization(ApplicationDbContext? context, ILogger<DatabaseInitialization>? logger) : this()
        {
            _context = context;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            try
            {
                ArgumentNullException.ThrowIfNull(_context);

                await _context.Database.EnsureCreatedAsync().ConfigureAwait(false);

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ArgumentNullException.ThrowIfNull(_logger);

                _databaseCreationError(_logger, ex);
            }
        }
    }
}