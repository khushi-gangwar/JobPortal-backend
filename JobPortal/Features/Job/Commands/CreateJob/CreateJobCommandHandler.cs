using DevSpot.Models;
using JobPortal.Data;
using MediatR;
using NUlid;

namespace JobPortal.Features.Job.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public CreateJobCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.JobModel.Id = Ulid.NewUlid().ToString();
                var createdJob=_context.Jobs.Add(request.JobModel);

                await _context.SaveChangesAsync(cancellationToken);
                return new ApiResponseModel
                {
                    Data = createdJob.Entity,
                    Status = 201,
                    Message = "Job created successfully"
                };

            }
            catch (Exception ex)
            {
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
