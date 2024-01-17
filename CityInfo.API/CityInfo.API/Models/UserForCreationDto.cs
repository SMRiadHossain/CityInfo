using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class UserForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
