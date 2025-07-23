using DevSpot.Models;
using JobPortal.Models;
using MediatR;

namespace JobPortal.Features.JobApplication.Commands.UpdateJobApplication
{
    public class UpdateJobApplicationCommand :IRequest<ApiResponseModel>
    {
        public JobApplicationModel JobApplicationModel { get; set; }
        public UpdateJobApplicationCommand(JobApplicationModel jobApplicationModel)
        {
            JobApplicationModel = jobApplicationModel;
        }
    }
}
