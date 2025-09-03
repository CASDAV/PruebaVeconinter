using System.ComponentModel.DataAnnotations;

namespace PersonalDataManagementSystem.API.Entities;

public class LoginRequest
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}
