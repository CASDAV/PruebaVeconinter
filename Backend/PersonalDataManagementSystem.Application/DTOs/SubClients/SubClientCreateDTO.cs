using System.ComponentModel.DataAnnotations;

namespace PersonalDataManagementSystem.Application.DTOs.SubClients;

public class SubClientCreateDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Telephone = null!;

    [Required]
    public Guid ClientId { get; set; }
}
