using CityInfo.API.Entities;

namespace CityInfo.API.Models
{
    public class PointsOfInterestReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int cityId { get; set; }

    }
}
