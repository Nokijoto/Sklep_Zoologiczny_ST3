﻿using SklepZoologiczny.Animals.CrossCutting.Dtos;

namespace PetStore.Interfaces
{
    public interface IAnimalsService
    {
        Task<AnimalDto> GetAnimalsAsync();
        Task<AnimalDto> GetAnimalByIdAsync(Guid id);
        Task<AnimalDto> GetAnimalBySpecieIdAsync(Guid id);
        Task<AnimalDto> GetAnimalsByName(string name);
        Task<AnimalDto> GetAnimalsBySpecieName(string name);


        Task<SpecieDto> GetSpeciesAsync();
        Task<SpecieDto> GetSpecieByIdAsync(Guid id);
        Task<SpecieDto> GetSpecieByName(string name);
    }
}