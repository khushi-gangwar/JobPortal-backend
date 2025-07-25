using DevSpot.Models;

namespace JobPortal.Models
{
    public class JobApplicationModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? JobId { get; set; }
        public string? UserId { get; set; }
        public string? ResumeUrl { get; set; }
        public DateTime AppliedAt { get; set; } = DateTime.Now;
        public string? Status { get; set; } = "Pending"; // e.g., Pending, Accepted, Rejected
        public string? CoverLetter { get; set; }
        public DateTime? UpdatedAt { get; set; }
       

        // Navigation properties can be added if needed
        public virtual JobModel Job { get; set; }
         public virtual UserModel User { get; set; }
    }
}
