using StayOver.Areas.Identity.Data;
using System;

namespace StayOver.Models
{
    public class Review
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime PublishedDate { get; set; }

        public string ApplicationUserId { get; set; }
        public int AccommodationId { get; set; }


        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
