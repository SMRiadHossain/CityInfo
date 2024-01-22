namespace CityInfo.API.Models
{
    public class SearchDto
    {
        public string Name { get; set; } = string.Empty;
        public int userId { get; set; }
        public string? Description { get; set; }
    }
}
