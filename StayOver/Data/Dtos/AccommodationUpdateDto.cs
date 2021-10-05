using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayOver.Data.Dtos
{
    public class AccommodationUpdateDto
    {
        [Required]
        public int AccommodationId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Address { get; set; }

        public bool ShowPhoneNumber { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        [Required]
        public int GuestNumber { get; set; }

        [Display(Name = "Choose the gallery images")]
        [NotMapped]
        public IFormFileCollection GalleryFiles { get; set; }

        [Required]  
        public int CityId { get; set; }

        public string OwnerId { get; set; }
    }
}
