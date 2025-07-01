using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.Job.Query.GetJob
{
    public class GetJobByIdCommand : IRequest<ApiResponseModel>

    {
        public string JobId { get; set; }
        public GetJobByIdCommand(string jobId)
        {
            JobId = jobId;
        }
    }
}
