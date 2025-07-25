using DevSpot.Models;
using JobPortal.DTO;
using MediatR;

namespace JobPortal.Features.Job.Commands.CreateJob
{
    public class CreateJobCommand:IRequest<ApiResponseModel>
    {
        public CreateJobDto JobModel { get; set; }
        public CreateJobCommand(CreateJobDto jobModel)
        {
            JobModel = jobModel;
        }
    }
}
