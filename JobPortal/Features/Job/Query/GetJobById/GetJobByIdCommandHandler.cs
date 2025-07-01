using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.Job.Query.GetJob
{
    public class GetJobByIdCommandHandler : IRequestHandler<GetJobByIdCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public GetJobByIdCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(GetJobByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var job = _context.Jobs.Find(request.JobId);
                if (job == null)
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 404, 
                        Message = "Job not found"
                    };
                }
                else
                {
                   return new ApiResponseModel
                    {
                        Data = job,
                        Status = 200, 
                        Message = "Job retrieved successfully"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponseModel
                {
                    Data = null,
                    Status = 500, 
                    Message = ex.Message
                };
            }
        }
    }
}
