using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.Job.Commands.CreateJob
{
    public class CreateJobCommand:IRequest<ApiResponseModel>
    {
        public JobModel JobModel { get; set; }
        public CreateJobCommand(JobModel jobModel)
        {
            JobModel = jobModel;
        }
    }
}
