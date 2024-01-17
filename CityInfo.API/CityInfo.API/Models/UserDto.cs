using CityInfo.API.Entities;

namespace CityInfo.API.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public ICollection<City> cities { get; set; }
            = new List<City>();

        public ICollection<PointOfInterest> PointsOfInterest { get; set; }
            = new List<PointOfInterest>();

    }
}
