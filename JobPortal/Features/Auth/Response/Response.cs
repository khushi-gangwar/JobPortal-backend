namespace JobPortal.Features.Auth.Response
{
    public class AuthResponse
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int status { get; set; }
    }

}
