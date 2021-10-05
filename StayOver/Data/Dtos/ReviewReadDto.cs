using StayOver.Areas.Identity.Data;
using StayOver.Models;
using System;

namespace StayOver.Data.Dtos
{
    public class ReviewReadDto
    {
        public int ReservationId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime PublishedDate { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
