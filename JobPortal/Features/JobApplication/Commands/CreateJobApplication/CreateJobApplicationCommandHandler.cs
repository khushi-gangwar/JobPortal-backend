using DevSpot.Models;
using JobPortal.Data;
using MediatR;
using NUlid;

namespace JobPortal.Features.JobApplication.Commands.CreateJobApplication
{
    public class CreateJobApplicationCommandHandler : IRequestHandler<CreateJobApplicationCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public CreateJobApplicationCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.JobApplicationModel.Id=Ulid.NewUlid().ToString();
                var jobapplication=_context.JobApplications.Add(request.JobApplicationModel);
                await _context.SaveChangesAsync();
                return new ApiResponseModel
                {
                    Data = jobapplication.Entity,
                    Status = 201, // Created
                    Message = "Job application created successfully"
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
