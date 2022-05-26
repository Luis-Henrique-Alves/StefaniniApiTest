using Example.Application.CityService.Models.Dtos;
using Example.Application.CityService.Models.Request;
using Example.Application.CityService.Models.Response;
using Example.Application.Common;
using Example.Domain.CityAggregate;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.CityService.Service
{
    public class CityService : BaseService<CityService>, ICityService
    {
        private readonly ExampleContext _db;

        public CityService(ILogger<CityService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCitiesResponse> GetAllAsync()
        {
            var entity = await _db.City.ToListAsync();
            return new GetAllCitiesResponse()
            {
                Cities = entity != null ? entity.Select(a => (CityDtos)a).ToList() : new List<CityDtos>()
            };
        }

        public async Task<GetByIdCityResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdCityResponse();

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.City = (CityDtos)entity;

            return response;
        }

        public async Task<CreateCityResponse> CreateAsync(CreateCityRequest request)
        {
            var newCity = City.Create(request.Name, request.State);

            ValidateAlredyExists(request);

            _db.City.Add(newCity);

            await _db.SaveChangesAsync();

            return new CreateCityResponse() { Id = newCity.Id };
        }

        public async Task<UpdateCityResponse> UpdateAsync(int id, UpdateCityRequest request)
        {
            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.State);
                await _db.SaveChangesAsync();
            }

            return new UpdateCityResponse();
        }

        public async Task<DeleteCityResponse> DeleteAsync(int id)
        {

            var entity = await _db.City.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeleteCityResponse();
        }

        private void ValidateAlredyExists(CreateCityRequest request)
        {
     
            if (_db.City.Any(x => x.State == request.State && request.Name == request.Name))
            {
                throw new ArgumentException("Request empty!");
            }
        }
    }
}
