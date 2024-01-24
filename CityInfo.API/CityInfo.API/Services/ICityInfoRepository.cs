using CityInfo.API.Entities;
using CityInfo.API.Models;
namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<IEnumerable<City>> GetCitiesAsync(string obj);

        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync();
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestAsync(string obj);

        Task<City?> GetCityAsync(int cityId, bool includePointOfInterest);
        Task<City?> GetCityAsync(string cityName);
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserAsync(string userName);
        Task<bool> CityExistAsync(int cityId);

        Task<bool> CityExistAsync(string Name);
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId,
            int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId,string userName, PointOfInterest pointOfInterest);

        Task<City> AddCityAsync(City city);

        Task<User> AddNewUserAsync(User user);

        

        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        void DeleteCity(City city);

        Task<bool> SaveChangesAsync();



        Task<bool> UserExistAsync(string userName);
        Task<bool> UserExistAsync(int userId);
        Task<bool> EmailExistAsync(string email);
        Task AddNewUserAsync(UserDto finalUSerDetails);

        string CheckPasswordStrength(string password);



    }
}
