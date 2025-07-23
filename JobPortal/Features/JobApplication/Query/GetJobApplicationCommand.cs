using DevSpot.Models;
using MediatR;

namespace JobPortal.Features.JobApplication.Query
{
    public class GetJobApplicationCommand:IRequest<ApiResponseModel>
    {
    }
}
