using JobPortal.Features.Auth.Response;
using MediatR;

namespace JobPortal.Features.Auth.Commands
{
    public class LoginCommand :IRequest<AuthResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
