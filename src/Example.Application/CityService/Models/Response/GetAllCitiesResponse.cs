using Example.Application.CityService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CityService.Models.Response
{
    public class GetAllCitiesResponse : BaseResponse
    {
        public List<CityDtos> Cities { get; set; }
    }
}
