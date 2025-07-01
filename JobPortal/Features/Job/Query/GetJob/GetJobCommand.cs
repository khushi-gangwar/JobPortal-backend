using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.Job.Query.GetJob
{
    public class GetJobCommand :IRequest<ApiResponseModel>
    {
    }
}
