using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.JobApplication.Commands.UpdateJobApplication
{
    public class UpdateJobApplicationCommandHandler : IRequestHandler<UpdateJobApplicationCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public UpdateJobApplicationCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(UpdateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jobapplicationExists = await _context.JobApplications.FindAsync(request.JobApplicationModel.Id);
                if (jobapplicationExists != null)
                {
                    jobapplicationExists.JobId = request.JobApplicationModel.JobId;
                    jobapplicationExists.UserId = request.JobApplicationModel.UserId;
                    jobapplicationExists.CoverLetter = request.JobApplicationModel.CoverLetter;
                    jobapplicationExists.ResumeUrl = request.JobApplicationModel.ResumeUrl;
                    jobapplicationExists.Status = request.JobApplicationModel.Status;
                    jobapplicationExists.UpdatedAt = DateTime.Now;
                    _context.JobApplications.Update(jobapplicationExists);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new ApiResponseModel
                    {
                        Data = jobapplicationExists,
                        Status = 200, // OK
                        Message = "Job application updated successfully"
                    };
                }
                else
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 404, // Not Found
                        Message = "Job application does not exist"
                    };
                }   
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
