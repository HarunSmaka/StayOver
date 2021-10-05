using Microsoft.AspNetCore.Http;
using StayOver.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StayOver.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        [NotMapped]
        public string StartDate { get; set; }
        [NotMapped]
        public string EndDate { get; set; }
        [NotMapped]


        public string Address { get; set; }
        public string Description { get; set; }

        public bool Active { get; set; } = true;
        [DisplayName("Show owners phone number")]
        public bool ShowPhoneNumber { get; set; }
        public int GuestNumber { get; set; }

        [Display(Name = "Choose the gallery images")]
        [NotMapped]
        public IFormFileCollection GalleryFiles { get; set; }

        public ICollection<GalleryModel> Gallery { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
 
        public int CityId { get; set; }
        public string OwnerId { get; set; }

        public virtual City City { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
