using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Queries.SubClients;

public class GetSubClientById
{
    private readonly ISubClientsRepository _repository;
    private readonly IMapper _mapper;

    public GetSubClientById(ISubClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubClientDTO> ExecuteAsync(Guid id)
    {
        return _mapper.Map<SubClientDTO>(await _repository.GetSubClientByIdAsync(id));
    }

}
