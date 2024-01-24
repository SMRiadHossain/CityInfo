using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<IEnumerable<City>> GetCitiesAsync(string obj)
        {
            return await _context.Cities.Where(c => c.Name == obj).ToListAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync()
        {
            return await _context.PointsOfInterest.OrderBy(c => c.Name).ToListAsync();
        }
        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync(string obj)
        {
            return await _context.PointsOfInterest.Where(c => c.Name == obj).ToListAsync();
        }



        public async Task<City?>GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if(includePointsOfInterest)
            {
                return await _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }
            return await _context.Cities
                .Where(c => c.Id == cityId) .FirstOrDefaultAsync();
        }

        public async Task<City?> GetCityAsync(string cityName)
        {
            
            return await _context.Cities
                .Where(c => c.Name == cityName).FirstOrDefaultAsync();
        }

        public async Task<User>GetUserAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
        public async Task<User> GetUserAsync(string userName)
        {
            return await _context.Users.Where(c => c.userName == userName).FirstOrDefaultAsync();
        }


        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task<bool> CityExistAsync(string Name)
        {
            return await _context.Cities.AnyAsync(c => c.Name == Name);
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId).ToListAsync();
        }

        public async Task<PointOfInterest?>GetPointOfInterestForCityAsync(int cityId, 
            int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityId && p.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }
        public async Task AddPointOfInterestForCityAsync(int cityId, string userName,
            PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if(city != null) 
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }
            var user = await GetUserAsync(userName);
            if(user != null)
            {
                user.PointsOfInterest.Add(pointOfInterest);
            }
        }

        public async Task<City> AddCityAsync(City city)
        {
            await _context.Cities.AddAsync(city);
            

            return city;

        }

        public async Task<User> AddNewUserAsync(User user)
        {
            await _context.Users.AddAsync(user);


            return user;

        }


        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);

        }

        public void DeleteCity(City city)
        {
            _context.Cities.Remove(city);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()>=0);
        }


        public async Task<bool> UserExistAsync(string userName)
        {
            return await _context.Users.AnyAsync(c => c.userName == userName);
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await _context.Users.AnyAsync(c => c.email == email);
        }
        public async Task<bool> UserExistAsync(int userId)
        {
            return await _context.Users.AnyAsync(c => c.Id == userId);
        }

        public Task AddNewUserAsync(UserDto finalUSerDetails)
        {
            throw new NotImplementedException();
        }

        public string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
          
            if (password.Length<8)
                sb.Append("Minimum password length should be 8"+Environment.NewLine);
            if(!(Regex.IsMatch(password,"[a-z]") && Regex.IsMatch(password, "[A-Z]") && Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password Should be alphanumeric"+  Environment.NewLine);
            if(!(Regex.IsMatch(password, "[ <,>,~,`,!,@,#,$,%,^,&,*,( ,),\\-,,+,=,{,},[,\\],|,\\,;,:,\",<,>,.,/,?]")))
                    sb.Append("Password Must have a special character" + Environment.NewLine);

            return sb.ToString();


        }
    }
}
