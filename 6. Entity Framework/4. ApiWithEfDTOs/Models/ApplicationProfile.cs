using ApiWithEfDTOs.Models.DTOs;
using AutoMapper;

namespace ApiWithEfDTOs.Models;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Person, PersonDTO>();
        CreateMap<Adress, AdressDTO>();
    }
}