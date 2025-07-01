using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.Job.Commands.DeleteJob
{
    public class DeleteJobCommandHandler :IRequestHandler<DeleteJobCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public DeleteJobCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(request._jobId);
                if (job != null)
                {
                    _context.Jobs.Remove(job);
                    await _context.SaveChangesAsync();
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 200,
                        Message = "Job deleted successfully"
                    };
                }
                else
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 404,
                        Message = "Job not found"
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
