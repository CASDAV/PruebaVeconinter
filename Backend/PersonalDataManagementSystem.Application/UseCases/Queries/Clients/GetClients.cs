using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Queries.Clients;

public class GetClients
{
    private readonly IClientsRepository _repository;
    private readonly IMapper _mapper;

    public GetClients(IClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> ExecuteAsync()
    {
        return _mapper.Map<List<ClientDTO>>(await _repository.GetClientsAsync());
    }
}
