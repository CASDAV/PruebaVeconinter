using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;

public class DeleteSubClient
{
    private readonly ISubClientsRepository _repository;

    public DeleteSubClient(ISubClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteSubClientAsync(id);
    }
}
