
using NUlid;

namespace DevSpot.Models
{
    public class JobModel
    {
        public string Id { get; set; } = Ulid.NewUlid().ToString();
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? Company { get; set; }
        public string? CompanyLogo { get; set; }
        public string? Url { get; set; }
        public string? Salary { get; set; }
        public string? ExpeirencedRequired { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPublished { get; set; }
        public string? PostedBY { get; set; }
    }
}
