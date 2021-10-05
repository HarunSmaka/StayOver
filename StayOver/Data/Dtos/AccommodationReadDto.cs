using StayOver.Areas.Identity.Data;
using StayOver.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace StayOver.Data.Dtos
{
    public class AccommodationReadDto
    {
        public int AccommodationId { get; set; }
        
        public string Title { get; set; }

        public float Price { get; set; }        
        
        public string Address { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        [DisplayName("Show phone number")]
        public bool ShowPhoneNumber { get; set; }

        public int GuestNumber { get; set; }

        public ICollection<GalleryModel> Gallery { get; set; }

        public ICollection<ReservationReadDto> Reservations { get; set; }

        public virtual City City { get; set; }

        public virtual ApplicationUser Owner { get; set; }
    }
}
