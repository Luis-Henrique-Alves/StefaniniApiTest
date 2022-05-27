using Example.Application.Common;
using Example.Application.PersonService.Models.Dtos;
using Example.Application.PersonService.Models.Request;
using Example.Application.PersonService.Models.Response;
using Example.Application.PersonService.Service;
using Example.Domain.PersonAggregate;
using Example.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Example.Application.ExampleService.Service
{
    public class PersonService : BaseService<PersonService>, IPersonService
    {
        private readonly ExampleContext _db;

        public PersonService(ILogger<PersonService> logger, ExampleContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPersonResponse> GetAllAsync()
        {
            var entity = await _db.Person.ToListAsync();
            return new GetAllPersonResponse()
            {
                People = entity != null ? entity.Select(a => (PersonDto)a).ToList() : new List<PersonDto>()
            };
        }

        public async Task<GetByIdPersonResponse> GetByIdAsync(int id)
        {

            var response = new GetByIdPersonResponse();

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Example = (PersonDto)entity;

            return response;
        }

        public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request)
        {
            
            var newPerson = Person.Create(request.Name, request.DocumentNumber, request.Age, request.IdCity);
            ValidateAlredyExists(request);

            _db.Person.Add(newPerson);

            await _db.SaveChangesAsync();

            return new CreatePersonResponse() { Id = newPerson.Id };
        }

        public async Task<UpdatePersonResponse> UpdateAsync(int id, UpdatePersonRequest request)
        {
   
            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Name, request.DocumentNumber, request.Age, request.IdCity);
                await _db.SaveChangesAsync();
            }

            return new UpdatePersonResponse();
        }

        public async Task<DeletePersonResponse> DeleteAsync(int id)
        {

            var entity = await _db.Person.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return new DeletePersonResponse();
        }

        private void ValidateAlredyExists(CreatePersonRequest request)
        {

            if (_db.Person.Any(x => x.DocumentNumber == request.DocumentNumber))
            {
                throw new ArgumentException("Request empty!");
            }
        }
    }
}
