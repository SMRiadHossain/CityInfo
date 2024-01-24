using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public HomeController(ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{obj}")]
        public async Task<ActionResult<IEnumerable<SearchDto>>> SearchResult(string obj)
        {
            if(obj == null)
            {
                return BadRequest();
            }

            var cityEntities = await _cityInfoRepository.GetCitiesAsync(obj);

            var pointEntity = await _cityInfoRepository.GetPointsOfInterestAsync(obj);
            

            if (cityEntities?.Any() != true && pointEntity?.Any()!=true)
            {
                return NotFound();
            }

            if (!(pointEntity?.Any() != true))
            {
                return Ok(_mapper.Map<IEnumerable<SearchDto>>(pointEntity));
            }
            return Ok(_mapper.Map<IEnumerable<SearchDto>>(cityEntities));

        }
    }
}
