using DevSpot.Models;
using JobPortal.Models;
using MediatR;

namespace JobPortal.Features.JobApplication.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommand :IRequest<ApiResponseModel>
    {
        public JobApplicationModel JobApplicationModel { get; set; }
        public CreateJobApplicationCommand(JobApplicationModel jobApplicationModel)
        {
            JobApplicationModel = jobApplicationModel;
        }
    }
}
