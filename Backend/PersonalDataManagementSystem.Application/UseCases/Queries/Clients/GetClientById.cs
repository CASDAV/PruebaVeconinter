using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Queries.Clients;

public class GetClientById
{
    private readonly IClientsRepository _repository;
    private readonly IMapper _mapper;

    public GetClientById(IClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ClientDTO> ExecuteAsync(Guid id)
    {
        return _mapper.Map<ClientDTO>(await _repository.GetClientByIdAsync(id));
    }
}
