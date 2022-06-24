using CFL.WebApi.Model;

namespace CFL.WebApi.Helpers;

public interface IUserService
{
    AuthResponse Authenticate(AuthRequest model);
    User GetUser(int id);
}