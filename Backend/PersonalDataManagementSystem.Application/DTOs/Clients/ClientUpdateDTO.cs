using System.ComponentModel.DataAnnotations;

namespace PersonalDataManagementSystem.Application.DTOs.Clients;

public class ClientUpdateDTO
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
    [MaxLength(100)]
    public string Telephone { get; set; } = null!;

    [MaxLength(100)]
    public string? Company { get; set; }
}
