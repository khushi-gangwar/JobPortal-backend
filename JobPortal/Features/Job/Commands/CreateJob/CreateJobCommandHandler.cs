using DevSpot.Models;
using JobPortal.Data;
using MediatR;
using NUlid;
using System.Security.Claims;

namespace JobPortal.Features.Job.Commands.CreateJob
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateJobCommandHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResponseModel> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return new ApiResponseModel
                    {
                        Data = null,
                        Status = 401,
                        Message = "Unauthorized - User ID not found"
                    };
                }
                var job=new JobModel
                {
                    Id = Ulid.NewUlid().ToString(),
                    Title = request.JobModel.Title,
                    Description = request.JobModel.Description,
                    Company = request.JobModel.Company,
                    Location = request.JobModel.Location,
                    Salary = request.JobModel.Salary,
                    CompanyLogo = request.JobModel.CompanyLogo,
                    Url = request.JobModel.Url,
                    ExpeirencedRequired = request.JobModel.ExpeirencedRequired,
                    CreatedAt = DateTime.Now,
                    PostedBY = userId,

                    
                };
             
                var createdJob=_context.Jobs.Add(job);

                await _context.SaveChangesAsync();
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
