using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClientCreateDTO, Client>();
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientUpdateDTO, Client>();

        CreateMap<SubClientCreateDTO, SubClient>();
        CreateMap<SubClient, SubClientDTO>();
        CreateMap<SubClientUpdateDTO, SubClient>();
    }
}
