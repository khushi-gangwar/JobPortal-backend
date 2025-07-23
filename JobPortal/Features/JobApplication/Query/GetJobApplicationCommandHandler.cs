using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.JobApplication.Query
{
    public class GetJobApplicationCommandHandler : IRequestHandler<GetJobApplicationCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public GetJobApplicationCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(GetJobApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jobApplications = _context.JobApplications.ToList();
                if (jobApplications == null || !jobApplications.Any())
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 404, // Not Found
                        Message = "No job applications found"
                    };
                }
                return new ApiResponseModel
                {
                    Data = jobApplications,
                    Status = 200, // OK
                    Message = "Job applications retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return new ApiResponseModel
                {
                    Data = null,
                    Status = 500, // Internal Server Error
                    Message = ex.Message
                };
            }
        }
    }
}
