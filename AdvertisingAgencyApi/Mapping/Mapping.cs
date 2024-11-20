using AutoMapper;
using AdvertisingAgencyApi.Models;
using AdvertisingAgencyApi.DTOs;

namespace AdvertisingAgencyApi.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.Person.FirstName + " " + src.Manager.Person.LastName))
                .ForMember(dest => dest.ClientCompanyName, opt => opt.MapFrom(src => src.Client.CompanyName));
                
            CreateMap<CreateClientDto, Client>().ReverseMap();
            CreateMap<CreateManagerDto, Manager>().ReverseMap();
            CreateMap<CreatePersonDto, Person>().ReverseMap();
            CreateMap<CreateContractDto, Contract>().ReverseMap();

            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ReverseMap();

            CreateMap<Manager, ManagerDto>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }
}
