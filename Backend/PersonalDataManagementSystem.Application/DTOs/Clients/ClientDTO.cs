using PersonalDataManagementSystem.Application.DTOs.SubClients;

namespace PersonalDataManagementSystem.Application.DTOs.Clients;

public class ClientDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public string? Company { get; set; }
    public virtual ICollection<SubClientDTO>? SubClients { get; } = new List<SubClientDTO>();
}
