using AutoMapper;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.Clients;

public class DeleteClient
{
    private readonly IClientsRepository _repository;
    public DeleteClient(IClientsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteClientAsync(id);
    }
}
