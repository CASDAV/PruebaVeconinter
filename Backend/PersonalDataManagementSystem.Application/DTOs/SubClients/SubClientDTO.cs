namespace PersonalDataManagementSystem.Application.DTOs.SubClients;

public class SubClientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone = null!;
    public Guid ClientId { get; set; }
}
