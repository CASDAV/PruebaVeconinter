using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

public interface ISubClientsRepository
{
    public Task<SubClient?> GetSubClientByIdAsync(Guid id);

    public Task<IEnumerable<SubClient>> GetSubClientsAsync();

    public Task<SubClient> CreateSubClientAsync(SubClient subClient);

    public Task<SubClient> UpdateSubClientAsync(SubClient subClient);

    public Task DeleteSubClientAsync(Guid id);
}
