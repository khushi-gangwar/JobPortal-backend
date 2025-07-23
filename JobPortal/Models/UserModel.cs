using Microsoft.AspNetCore.Identity;

namespace JobPortal.Models
{
    public class UserModel :IdentityUser
    {

        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<JobApplicationModel>? JobApplications { get; set; }
    }
}
    