using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.Interfaces.Infrastructure.BusinessObjects;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;

public class UpdateSubClient
{
    private readonly ISubClientsRepository _repository;
    private readonly IMapper _mapper;

    public UpdateSubClient(ISubClientsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SubClientDTO> ExecuteAsync(SubClientUpdateDTO updateDTO)
    {
        SubClient subClientUpdate = _mapper.Map<SubClient>(updateDTO);

        return _mapper.Map<SubClientDTO>(await _repository.UpdateSubClientAsync(subClientUpdate));
    }
}
