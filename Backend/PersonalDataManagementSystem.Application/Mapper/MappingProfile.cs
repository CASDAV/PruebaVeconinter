using AutoMapper;
using PersonalDataManagementSystem.Application.DTOs.Clients;
using PersonalDataManagementSystem.Application.DTOs.SubClients;
using PersonalDataManagementSystem.Application.UseCases.Commands.Clients;
using PersonalDataManagementSystem.Application.UseCases.Commands.SubClients;
using PersonalDataManagementSystem.Domain.Entities.BusinessObjects;

namespace PersonalDataManagementSystem.Application.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateClient, Client>();
        CreateMap<Client, ClientDTO>();
        CreateMap<UpdateClient, Client>();

        CreateMap<CreateSubClient, SubClient>();
        CreateMap<SubClient, SubClientDTO>();
        CreateMap<UpdateSubClient, SubClient>();
    }
}
