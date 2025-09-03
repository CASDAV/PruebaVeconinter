using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Queries.SubClients;

public class GetSubClients
{
    private readonly ISubClientsRepository _repository;
    private readonly IMapper _mapper;

    public GetSubClients(ISubClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SubClientDTO>> ExecuteAsync()
    {
        return _mapper.Map<List<SubClientDTO>>(await _repository.GetSubClientsAsync());
    }
}
