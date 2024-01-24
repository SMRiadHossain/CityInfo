using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityName}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController>logger,
            IMailService mailService,
            ICityInfoRepository cityInfoRepository,
            IMapper mapper)
        {
            _logger = logger ?? 
                throw new ArgumentException(nameof(logger));
            _mailService = mailService ?? 
                throw new ArgumentException(nameof(_mailService));
            _cityInfoRepository = cityInfoRepository ?? 
                throw new ArgumentException(nameof(cityInfoRepository));
            _mapper = mapper ?? 
                throw new ArgumentException(nameof(mapper));

        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(string cityName)
        {
            if (!await _cityInfoRepository.CityExistAsync(cityName))
            {
                _logger.LogInformation(
                    $"City with id {cityName} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var city = await _cityInfoRepository.GetCityAsync(cityName);

            var pointsOfInterestForCity = await _cityInfoRepository.GetPointOfInterestForCityAsync(city.Id);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));

        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(string cityName, int pointofinterestid)
        {
            if(!await _cityInfoRepository.CityExistAsync(cityName))
            {
                return NotFound();
            }
            var city = await _cityInfoRepository.GetCityAsync(cityName);
            var pointOfInterest = await _cityInfoRepository
                .GetPointOfInterestForCityAsync (city.Id, pointofinterestid);
            if(pointOfInterest == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost("{userName}")]

        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(
            string cityName,string userName,
            PointOfInterestForCreationDto pointOfInterest)
        {
            var city = await _cityInfoRepository.GetCityAsync(cityName);
            if (city == null)
            {
                return NotFound();
            }
            if (!await _cityInfoRepository.UserExistAsync(userName))
            {
                return NotFound();
            }

            
            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);
            await _cityInfoRepository.AddPointOfInterestForCityAsync(
                city.Id, userName, finalPointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();
            return Created();

            /*var createdPointOfInterestToReturn =
                _mapper.Map<Models.PointOfInterestDto>(finalPointOfInterest);
            
            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = createdPointOfInterestToReturn.Id
                },
                createdPointOfInterestToReturn);*/
        }

        [HttpPut("{pointofinterestid}")]
        public async Task<ActionResult> UpdatePointOfInterest(string cityName, int pointOfInterestId,
            PointOfInterestForUpdateDto pointOfInterest)
        {
            if(!await _cityInfoRepository.CityExistAsync(cityName))
            {
                return NotFound();
            }


            // find point of interest
            var city = await _cityInfoRepository.GetCityAsync(cityName);
            var pointOfInterestEntity = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(city.Id, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterest, pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();


            return Ok(new
            {
                Message = "Place Updated"

            });
        }


        //partially update

        [HttpPatch("{pointofinterestid}")]
        public async Task<ActionResult> PartiallyUpdatePointOfInterest(
            int cityId, int pointOfInterestId,
            JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            if (!await _cityInfoRepository.CityExistAsync(cityId))
            {
                return NotFound();
            }


            // find point of interest
            var pointOfInterestEntity = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(
                pointOfInterestEntity);

            


            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(
            string cityName, int pointOfInterestId)
        {

            var city = await _cityInfoRepository.GetCityAsync(cityName);
            if (city == null)
            {
                return NotFound();
            }


            // find point of interest
            var pointOfInterestEntity = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(city.Id, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }


            _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();




            _mailService.Send(
                "Point of interest deleted.",
                $"Point of interest {pointOfInterestEntity.Name} with id {pointOfInterestEntity.Id} was deleted.");
            
            
            
            return Ok(new { Message = "Place Deleted!" });
        }

    }
}
