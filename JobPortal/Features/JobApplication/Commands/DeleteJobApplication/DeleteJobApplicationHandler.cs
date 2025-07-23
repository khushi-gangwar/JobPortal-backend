using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.JobApplication.Commands.DeleteJobApplication
{
    public class DeleteJobApplicationHandler : IRequestHandler<DeleteJobApplicationcommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public DeleteJobApplicationHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(DeleteJobApplicationcommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Assuming _context is your database context and is injected via constructor
                var jobApplication = await _context.JobApplications.FindAsync(request.JobApplicationId);
                if (jobApplication == null)
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 404, // Not Found
                        Message = "Job application not found"
                    };
                }
                _context.JobApplications.Remove(jobApplication);
                await _context.SaveChangesAsync(cancellationToken);
                return new ApiResponseModel
                {
                    Data = null,
                    Status = 200, // OK
                    Message = "Job application deleted successfully"
                };

            }
            catch(Exception ex)
            {
                // Log the exception (not implemented here)
                return new ApiResponseModel
                {
                    Data = null,
                    Status = 500, // Internal Server Error
                    Message = ex.Message
                };
            }
            {

            }
        }
    }
}
