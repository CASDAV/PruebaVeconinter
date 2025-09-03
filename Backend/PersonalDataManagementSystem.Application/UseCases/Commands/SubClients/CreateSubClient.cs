using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;

public class CreateSubClient
{
    private readonly ISubClientsRepository _repository;
    private readonly IMapper _mapper;

    public CreateSubClient(ISubClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubClientDTO> ExecuteAsync(SubClientCreateDTO createDTO)
    {
        SubClient createSubClient = _mapper.Map<SubClient>(createDTO);

        return _mapper.Map<SubClientDTO>(await _repository.CreateSubClientAsync(createSubClient));
    }
}
