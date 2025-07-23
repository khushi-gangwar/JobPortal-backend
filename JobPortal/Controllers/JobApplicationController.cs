using DevSpot.Models;
using JobPortal.Features.JobApplication.Commands.CreateJobApplication;
using JobPortal.Features.JobApplication.Commands.DeleteJobApplication;
using JobPortal.Features.JobApplication.Commands.UpdateJobApplication;
using JobPortal.Features.JobApplication.Query;
using JobPortal.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateJobApplication([FromBody] JobApplicationModel jobapplication)
        {
            try
            {
                var response = await _mediator.Send(new CreateJobApplicationCommand(jobapplication));

                if (response.Status == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch
            {
                return null;

            }
        }
        [HttpGet]
        public async Task<IActionResult> GetJobApplication()
        {
            try
            {
                var response = await _mediator.Send(new GetJobApplicationCommand());

                if (response.Status == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch
            {
                return null;

            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteJobApplication([FromBody] string id)
        {
            try
            {
                var response = await _mediator.Send(new DeleteJobApplicationcommand(id));

                if (response.Status == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch
            {
                return null;

            }
        }
        [HttpPut]

        public async Task<IActionResult> UpdateJobApplication([FromBody] JobApplicationModel jobapplication)
        {
            try
            {
                var response = await _mediator.Send(new UpdateJobApplicationCommand(jobapplication));

                if (response.Status == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch
            {
                return null;

            }
        }
    }
}
