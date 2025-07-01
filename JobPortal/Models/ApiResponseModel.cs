namespace DevSpot.Models
{
    public class ApiResponseModel
    {
        public object? Data { get; set; }
        public int Status { get; set; } 
        public string? Message {  get; set; } = string.Empty;
    }
}
