using DevSpot.Models;
using JobPortal.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Features.Job.Query.GetJob
{
    public class GetJobCommandHandler : IRequestHandler<GetJobCommand,ApiResponseModel>
    {
        private readonly AppDbContext _context;
        public GetJobCommandHandler(AppDbContext context)
        {
         _context = context;   
        }

        public async Task<ApiResponseModel> Handle(GetJobCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jobs=await _context.Jobs.ToListAsync();
                return new ApiResponseModel
                {
                    Data = jobs,
                    Status = 200
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
