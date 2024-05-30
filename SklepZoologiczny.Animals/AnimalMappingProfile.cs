using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SklepZoologiczny.Animals.CrossCutting.Dtos;
using SklepZoologiczny.Animals.Storage.Entity;

namespace SklepZoologiczny.Animals;

public class AnimalMappingProfile: Profile
{
    public AnimalMappingProfile()
    {
        CreateMap<Animal,AnimalDto>();
        CreateMap<AnimalDto, Animal>();
        CreateMap<UpdateAnimalDto, Animal>();
        CreateMap<CreateAnimalDto, Animal>().ForMember(dest => dest.SpecieId, opt => opt.Ignore()) 
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));;
        
        
        CreateMap<Specie,SpecieDto>();
        CreateMap<SpecieDto, Specie>();
        CreateMap<UpdateSpecieDto, Specie>();
    }
}
