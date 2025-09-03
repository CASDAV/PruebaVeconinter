using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.Clients;

public class CreateClient
{
    private readonly IClientsRepository _repository;
    private readonly IMapper _mapper;

    public CreateClient(IClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClientDTO> ExecuteAsync(ClientCreateDTO createDTO)
    {
        Client newClient = _mapper.Map<Client>(createDTO);

        return _mapper.Map<ClientDTO>(await _repository.CreateClientAsync(newClient));
    }
}
