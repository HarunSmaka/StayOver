using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayOver.Data.Dtos
{
    public class AccommodationCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Address { get; set; }
        
        public string Description { get; set; }

        public bool Active { get; set; } = true;

        [DisplayName("Show phone number")]
        public bool ShowPhoneNumber { get; set; }

        [Required]
        public int GuestNumber { get; set; }

        [Display(Name = "Choose the gallery images")]
        [NotMapped]
        public IFormFileCollection GalleryFiles { get; set; }

        [Required]
        [DisplayName("City")]
        public int CityId { get; set; }

        public string OwnerId { get; set; }
    }
}
