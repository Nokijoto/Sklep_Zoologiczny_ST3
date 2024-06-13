using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetStore.CrossCutting.Dtos.Warehouse;
using PetStore.Storage;
using PetStore.Storage.Entities.Warehouse;

namespace PetStore.Resolver
{
    public class GenericDataResolver<TDto, TEntity>
    where TEntity : class, new()
    {
        private readonly DbContext _dbContext;
        private readonly HttpClient _httpClient;
        private readonly string _externalApiBaseUrl;

        public GenericDataResolver(DbContext dbContext, HttpClient httpClient, string externalApiBaseUrl)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
            _externalApiBaseUrl = externalApiBaseUrl;
        }

        public async Task<TDto> ResolveDataAsync(Guid id)
        {
            var externalApiUrl = $"{_externalApiBaseUrl}/{id}";
            var response = await _httpClient.GetAsync(externalApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var dto = JsonConvert.DeserializeObject<TDto>(await response.Content.ReadAsStringAsync());
                await CreateOrUpdateEntityAsync(dto);
                return dto;
            }
            return default(TDto);
        }

        private async Task<TEntity> CreateOrUpdateEntityAsync(TDto dto)
        {
            var entity = new TEntity();
            // Map properties from dto to entity
            // Assuming you have a mapping function like MapDtoToEntity
            MapDtoToEntity(dto, entity);

            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        private void MapDtoToEntity(TDto dto, TEntity entity)
        {

            //dto.ToEntity();
            // Implement mapping logic here
            // For example, using reflection or a mapping library like AutoMapper
        }
    }

}
