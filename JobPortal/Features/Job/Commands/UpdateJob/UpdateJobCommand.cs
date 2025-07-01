using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.Job.Commands.UpdateJob
{
    public class UpdateJobCommand:IRequest<ApiResponseModel>
    {
        public JobModel JobModel { get; set; }
        public UpdateJobCommand(JobModel jobModel)
        {
           JobModel = jobModel;
        }
    }
}
