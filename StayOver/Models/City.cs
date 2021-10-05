using System.Collections.Generic;

namespace StayOver.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public ICollection<Accommodation> Accommodation { get; set; }
    }

}
