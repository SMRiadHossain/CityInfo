using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.API.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("userId")]

        public User User { get; set; }
        public int userId { get; set; }
        public ICollection<PointOfInterest> PointsOfInterest { get; set; } 
            = new List<PointOfInterest>();
        
        public City(string name)
        {
            Name = name;
        }
    }
}
