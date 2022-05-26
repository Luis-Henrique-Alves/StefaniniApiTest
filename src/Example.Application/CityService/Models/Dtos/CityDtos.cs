using Example.Domain.CityAggregate;

namespace Example.Application.CityService.Models.Dtos
{
    public class CityDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public static explicit operator CityDtos(City city)
        {
            return new CityDtos()
            {
                Id = city.Id,
                Name = city.Name,
                State = city.State
            };
        }
    }
}
