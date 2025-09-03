using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

public interface IClientsRepository
{
     public Task<Client?> GetClientByIdAsync(Guid id);

    public Task<IEnumerable<Client>> GetClientsAsync();

    public Task<Client> CreateClientAsync(Client client);

    public Task<Client> UpdateClientAsync(Client client);

    public Task DeleteClientAsync(Guid id);
}
