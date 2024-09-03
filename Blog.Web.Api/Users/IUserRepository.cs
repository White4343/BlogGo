namespace User.Web.Api.Users
{
    public interface IUserRepository
    {
        Task<UserModel> AddAsync(UserModel userModel, CancellationToken cancellationToken);
        Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
        Task<UserModel> GetByNicknameAsync(string nickname, CancellationToken cancellationToken);
        Task<UserModel> UpdateAsync(UserModel userModel, CancellationToken cancellationToken);
        Task<UserModel> PatchAsync(UserModel userModel, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}