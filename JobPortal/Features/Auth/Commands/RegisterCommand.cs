using JobPortal.DTO;
using JobPortal.Features.Auth.Response;
using MediatR;
namespace JobPortal.Features.Auth.Commands
{
    public class RegisterCommand :IRequest<AuthResponse>
    {
        public RegiterDTO RegisterDTO { get; set; }
        public  RegisterCommand(RegiterDTO registerDTO)
        {
         RegisterDTO=registerDTO; 
        }
    }
}
