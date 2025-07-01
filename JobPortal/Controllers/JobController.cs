using JobPortal.Features.Job.Commands.CreateJob;
using JobPortal.Features.Job.Commands.DeleteJob;
using JobPortal.Features.Job.Query.GetJob;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] CreateJobCommand command)
        {
            if (command == null || command.JobModel == null)
            {
                return BadRequest("Invalid job data.");
            }
            var response = await _mediator.Send(command);
            if (response.Status == 201)
            {
                return CreatedAtAction(nameof(CreateJob), new { data = response.Data }, response.Data);
            }
            return StatusCode(response.Status, response.Message);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(string id)
        {
            var response = await _mediator.Send(new GetJobByIdCommand(id));
            if (response.Status == (int)HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(string id)
        {
            var response = await _mediator.Send(new DeleteJobCommand(id));
            if (response.Status == (int)HttpStatusCode.NotFound)
                return NotFound(response);
            return Ok(response);
        }
    }
}
