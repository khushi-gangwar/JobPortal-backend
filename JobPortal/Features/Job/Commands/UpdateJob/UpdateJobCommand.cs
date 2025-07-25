using DevSpot.Models;
using JobPortal.DTO;
using MediatR;

namespace JobPortal.Features.Job.Commands.UpdateJob
{
    public class UpdateJobCommand:IRequest<ApiResponseModel>
    {
        public string JobID { get; set; }
        public UpdateJobDto JobModel { get; set; }
        public UpdateJobCommand(UpdateJobDto jobModel, string jobID)
        {
            JobModel = jobModel;
            JobID = jobID;
        }
    }
}
