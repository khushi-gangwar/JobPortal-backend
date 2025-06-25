using JobPortal.Features.Auth.Response;
using JobPortal.Models;
using JobPortal.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Features.Auth.Commands
{
    public class LoginCommandHandler :  IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<UserModel> _userManager;
        public LoginCommandHandler(IJwtService jwtService,UserManager<UserModel> userManager)
        {
         _jwtService = jwtService;
            _userManager = userManager;
        }
        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
           
            var user= await _userManager.FindByEmailAsync(request.Email);
           if(user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthResponse
                {
                    Token = null,
                    Username = null,
                    Email = null,
                    status = 401 // Not Found
                };
            }
            var token = _jwtService.GenerateToken(user);
            return new AuthResponse
            {
                Token = token,
                Username = user.UserName,
                Email = user.Email,
                status = 200 // OK
            };
        }
    }
}
