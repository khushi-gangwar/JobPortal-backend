using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.Job.Commands.DeleteJob
{
    public class DeleteJobCommand :IRequest<ApiResponseModel>
    {
        public readonly string _jobId;
        public DeleteJobCommand(string jobId)
        {
            _jobId = jobId;
        }
    }
}
