namespace User.Web.Api.Users
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
        Task<User> GetByNicknameAsync(string nickname, CancellationToken cancellationToken);
        Task<User> UpdateAsync(User user, CancellationToken cancellationToken);
        Task<User> PatchAsync(User user, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}