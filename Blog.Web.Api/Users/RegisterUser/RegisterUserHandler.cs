using System.Globalization;
using Infrastructure.Interfaces;
using Infrastructure.PasswordHashing;
using Microsoft.AspNetCore.Mvc;

namespace User.Web.Api.Users.RegisterUser
{
    public class RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, 
        IUnitOfWork unitOfWork)
    {
        public async Task<IResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            // Validate request via FluentValidation

            var user = new User
            {
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpper(CultureInfo.InvariantCulture),
                Email = request.Email,
                Nickname = request.Nickname,
                NormalizedEmail = request.Email.ToUpper(CultureInfo.InvariantCulture),
                PasswordHash = passwordHasher.Hash(request.Password),
                Role = "User",
            };

            await userRepository.AddAsync(user, cancellationToken).ConfigureAwait(false);

            await unitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return Results.Ok();
        }
    }
}
