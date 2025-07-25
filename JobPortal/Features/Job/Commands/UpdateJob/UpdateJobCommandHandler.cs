using DevSpot.Models;
using JobPortal.Data;
using MediatR;
using System.Security.Claims;

namespace JobPortal.Features.Job.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UpdateJobCommandHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ApiResponseModel> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return new ApiResponseModel
                    {
                        Status = 401,
                        Message = "Unauthorized - User ID not found",
                        Data = null
                    };
                }            
                var jobexists = await _context.Jobs.FindAsync(request.JobID);

                if (jobexists.PostedBY != userId)
                {
                    return new ApiResponseModel
                    {
                        Status = 403,
                        Message = "Forbidden - You can't update this job",
                        Data = null
                    };
                }
                if (jobexists!=null)
                {
                    jobexists.Title = request.JobModel.Title;
                    jobexists.Description = request.JobModel.Description;
                    jobexists.Location= request.JobModel.Location;
                    jobexists.Company = request.JobModel.Company;
                    jobexists.CompanyLogo = request.JobModel.CompanyLogo;
                    jobexists.Salary = request.JobModel.Salary;
                    jobexists.ExpeirencedRequired = request.JobModel.ExpeirencedRequired;
                    jobexists.UpdatedAt = DateTime.Now;
                    jobexists.IsActive = request.JobModel.IsActive;
                     _context.Jobs.Update(jobexists);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new ApiResponseModel
                    {
                        Data = jobexists,
                        Status = 200, 
                        Message = "Job updated successfully"
                    };
                }
                else
                {
                    return new ApiResponseModel
                    {
                       
                        Status = 401,
                        Message = "Job doesnot exists"
                    };
                }

            }
            catch(Exception ex)
            {
                return new ApiResponseModel
                {

                    Status = 401,
                    Message = "Job doesnot exists"
                };
            }
        }
    }
}
