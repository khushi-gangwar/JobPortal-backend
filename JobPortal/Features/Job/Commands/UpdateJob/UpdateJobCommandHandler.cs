using DevSpot.Models;
using JobPortal.Data;
using MediatR;

namespace JobPortal.Features.Job.Commands.UpdateJob
{
    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public UpdateJobCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jobexists = await _context.Jobs.FindAsync(request.JobModel.Id);
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
                     _context.Jobs.Update(jobexists);
                    _context.SaveChanges();
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
