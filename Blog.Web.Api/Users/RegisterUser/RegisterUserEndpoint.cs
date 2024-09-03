using User.Web.Api.Endpoints;

namespace User.Web.Api.Users.RegisterUser
{
    public sealed class RegisterUserEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("users", async (HttpContext httpContext, RegisterUserCommand request, RegisterUserHandler useCase) =>
                await useCase.Handle(request, httpContext.RequestAborted).ConfigureAwait(false)).WithTags("Users");
        }
    } 
}