using JobPortal.Features.Auth.Response;
using JobPortal.Models;
using JobPortal.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Features.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
    {
        private readonly UserManager<UserModel> _userManager;
        private readonly IJwtService _jwtService;
        public RegisterCommandHandler(IJwtService jwtService, UserManager<UserModel> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }
        public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
             
                var existinguser = await _userManager.FindByEmailAsync(request.RegisterDTO.Email);
                if (existinguser == null)
                {


                    var user = new UserModel
                    {
                        UserName = request.RegisterDTO.FullName,
                        Email = request.RegisterDTO.Email,


                    };
                    var result = await _userManager.CreateAsync(user, request.RegisterDTO.Password);
                    if (result.Succeeded)
                    {


                        var token = _jwtService.GenerateToken(user);
                        return new AuthResponse
                        {
                            Token = token,
                            Username = user.UserName,
                            Email = user.Email,
                            status = 200
                        };
                    }

                }
                return  new AuthResponse
                {
                    
                    status = 500
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while registering the user.", ex);
            }
        }
    }
}
