using JobPortal.Models;

namespace JobPortal.Services
{
    public interface IJwtService
    {
        string GenerateToken(UserModel user);
    }
}
