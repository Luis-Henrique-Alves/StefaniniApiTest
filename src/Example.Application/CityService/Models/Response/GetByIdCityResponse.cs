using Example.Application.CityService.Models.Dtos;
using Example.Application.Common;

namespace Example.Application.CityService.Models.Response
{
    public class GetByIdCityResponse : BaseResponse
    {
        public CityDtos City { get; set; }
    }
}
