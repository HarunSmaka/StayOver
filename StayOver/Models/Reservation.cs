using StayOver.Areas.Identity.Data;
using System;

namespace StayOver.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string VisiterId { get; set; }
        public int AccommodationId { get; set; }

        public Review Review { get; set; }
        public virtual ApplicationUser Visiter { get; set; }
        public virtual Accommodation Accommodation { get; set; }

        public Reservation(){}

        public Reservation(DateTime checkedIn, DateTime checkedOut, int accommodationId, string visiterId)
        {
            CreatedAt = DateTime.Now;
            CheckIn = checkedIn;
            CheckOut = checkedOut;
            AccommodationId = accommodationId;
            VisiterId = visiterId;
        }
    }
}
