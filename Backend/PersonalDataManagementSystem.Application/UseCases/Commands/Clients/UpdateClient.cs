using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.Clients;

public class UpdateClient
{
    private readonly IClientsRepository _repository;
    private readonly IMapper _mapper;

    public UpdateClient(IClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClientDTO> ExecuteAsync(ClientUpdateDTO updateDTO)
    {
        Client clientUpdate = _mapper.Map<Client>(updateDTO);

        return _mapper.Map<ClientDTO>(await _repository.UpdateClientAsync(clientUpdate));
    }
}
