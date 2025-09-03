using System.ComponentModel.DataAnnotations;

namespace PersonalDataManagementSystem.Application.DTOs.SubClients;

public class SubClientUpdateDTO
{
    [Required]
    public Guid Id { get; set; }

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
