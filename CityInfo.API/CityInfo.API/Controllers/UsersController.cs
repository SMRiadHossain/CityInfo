using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        public UsersController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserForLoginDto userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            var user = await _cityInfoRepository.UserExistAsync(userObj.userName);
            if(!user)
            {
                return NotFound(new {Message = "User Not Found"});
            }

            var pass = await _cityInfoRepository.PasswordValidAsync(userObj.password);
            if (!pass)
            {
                return NotFound(new { Message = "Wrong Password" });
            }

            return Ok(new {Message = "Login Success!"});



        }
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _cityInfoRepository.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserWithoutCityDto>(user));

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserForCreationDto userObj)
        {
            if(userObj == null)
            {
                return BadRequest();
            }

            var user = await _cityInfoRepository.UserExistAsync(userObj.userName);
            if (user)
            {
                return BadRequest(new { Message = "User Name Already Exist" });
            }

            var finalUSerDetails = _mapper.Map<User>(userObj);


            await _cityInfoRepository.AddNewUserAsync(finalUSerDetails);

            await _cityInfoRepository.SaveChangesAsync();

            return Ok(finalUSerDetails);




        }
    }
}
