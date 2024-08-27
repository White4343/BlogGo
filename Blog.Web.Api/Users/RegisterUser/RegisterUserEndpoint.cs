using User.Web.Api.Endpoints;

namespace User.Web.Api.Users.RegisterUser
{
    public sealed class RegisterUserEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async (RegisterUserCommand request, RegisterUserHandler useCase) =>
                await useCase.Handle(request, CancellationToken.None).ConfigureAwait(false)).WithTags("Users");
        }
    }
}