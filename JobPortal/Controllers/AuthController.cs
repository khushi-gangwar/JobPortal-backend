using JobPortal.DTO;
using JobPortal.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegiterDTO command)
        {
            
            var response = await _mediator.Send(new RegisterCommand(command));
            if (response.status == 200)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid login data.");
            }

           
            var response = await _mediator.Send(command);
            if (response is { status: 200 })
            {
                return Ok(response);
            }
            return Unauthorized(response);
        }
    }
}
