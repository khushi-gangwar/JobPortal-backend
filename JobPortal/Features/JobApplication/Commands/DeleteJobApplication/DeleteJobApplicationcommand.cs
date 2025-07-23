using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.JobApplication.Commands.DeleteJobApplication
{
    public class DeleteJobApplicationcommand :IRequest<ApiResponseModel>
    {
        public string JobApplicationId { get; set; }
        public DeleteJobApplicationcommand(string jobApplicationId)
        {
            JobApplicationId = jobApplicationId;
        }
    }
}
