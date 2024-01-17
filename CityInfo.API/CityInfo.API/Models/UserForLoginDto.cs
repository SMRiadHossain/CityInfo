using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class UserForLoginDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
