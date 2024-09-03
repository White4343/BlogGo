using User.Web.Api.Data;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace User.Web.Api.Users
{
    public class UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : IUserRepository
    {
        private static readonly Action<ILogger, string, Exception> _userAddError = LoggerMessage.Define<string>(
            LogLevel.Error,
            new EventId(1, "UserAddError"),
            "An error occurred while adding a userModel: {ErrorMessage}"
        );

        public async Task<UserModel> AddAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(userModel);
                ArgumentNullException.ThrowIfNull(cancellationToken);
                ArgumentNullException.ThrowIfNull(context.Users);

                await context.Users.AddAsync(userModel, cancellationToken).ConfigureAwait(false);

                return userModel;
            }
            catch (Exception e)
            {
                _userAddError(logger, e.Message, e); // Use the LoggerMessage delegate
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetByNicknameAsync(string nickname, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> UpdateAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> PatchAsync(UserModel userModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
