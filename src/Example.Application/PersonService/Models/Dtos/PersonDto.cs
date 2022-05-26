using Example.Domain.PersonAggregate;

namespace Example.Application.PersonService.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int Age { get; set; }
        public int IdCity { get; set; }

        public static explicit operator PersonDto(Person person)
        {
            return new PersonDto()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                DocumentNumber = person.DocumentNumber,
                IdCity = person.IdCity
            };
        }
    }
}
