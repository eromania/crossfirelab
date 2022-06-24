using System.ComponentModel.DataAnnotations;

namespace CFL.WebApi.Model;

public class AuthRequest
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}