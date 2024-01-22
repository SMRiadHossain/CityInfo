using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        private ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        const int maxCitiesPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {
            
            var cityEntities = await _cityInfoRepository
                .GetCitiesAsync();

            

            if (cityEntities?.Any() != true)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));

        }

        [HttpGet("{id}", Name ="GetCity")]
        public async Task<IActionResult> GetCity(
            int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointOfInterestDto>(city));
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCity(
            CityForCreationDto request)
        {
            var user = await _cityInfoRepository.GetUserAsync(request.userName);
            if (user == null)
            {
                return BadRequest(new
                {
                    Message = "User Name not found"
                });
            }

            /*var city = await _cityInfoRepository.CityExistAsync(request.Name);
            if (city)
            {
                return BadRequest(new
                {
                    Message = "City Already Exist"
                });
            }*/

            CityForDatabaseDto cityRequest = new CityForDatabaseDto
            {
                userId = user.Id,
                Description = request.Description,
                Name = request.Name,


            };

            

            var finalCity = _mapper.Map<City>(cityRequest);

            await _cityInfoRepository.AddCityAsync(finalCity);

            await _cityInfoRepository.SaveChangesAsync();

            return Ok(new
            {
                Message = "City Added"
            });
        }

        [HttpPut("{cityId}")]
        public async Task<ActionResult> UpdateCity(
            int cityId, CityDto city)
        {
            if (!await _cityInfoRepository.CityExistAsync(cityId))
            {
                return NotFound();
            }


            // find city
            var CityEntity = await _cityInfoRepository
                .GetCityAsync(cityId, false);
            if (CityEntity == null)
            {
                return NotFound();
            }
            CityEntity.Name = city.Name;
            CityEntity.Description = city.Description;

            await _cityInfoRepository.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{cityId}")]
        public async Task<ActionResult> DeleteCity(
            int cityId)
        {
            if (!await _cityInfoRepository.CityExistAsync(cityId))
            {
                return NotFound();
            }


            // find city
            var CityEntity = await _cityInfoRepository
                .GetCityAsync(cityId, false);
            if (CityEntity == null)
            {
                return NotFound();
            }


            _cityInfoRepository.DeleteCity(CityEntity);

            await _cityInfoRepository.SaveChangesAsync();
            
            return Ok(new { Message = "City Deleted!" });
        }
        [HttpGet("pointsofinterest")]
        public async Task<ActionResult<IEnumerable<PointsOfInterestReturnDto>>> GetPointsOfInterest()
        {

            var pointEntities = await _cityInfoRepository
                .GetPointsOfInterestAsync();



            if (pointEntities?.Any() != true)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<PointsOfInterestReturnDto>>(pointEntities));

        }
    }
}
