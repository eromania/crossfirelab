using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CFL.WebApi.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CFL.WebApi.Helpers;

public class UserService : IUserService
{
    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public AuthResponse Authenticate(AuthRequest model)
    {
        if(!(model.Username == "cfl" && model.Password == "123"))
            return null!;

        var user = new User()
        {
            Id = 1,
            FirstName = "cfl",
            LastName = "surname",
            Password = "123",
            Username = "cfl"
        };
        var token = generateJwtToken(user);

        return new AuthResponse(user, token);
    }

    public User GetUser(int id)
    {
        return new User()
        {
            Id = 1,
            FirstName = "cfl",
            LastName = "surname",
            Password = "123",
            Username = "cfl"
        };
    }
    
    private string generateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}