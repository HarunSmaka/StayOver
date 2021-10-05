using StayOver.Areas.Identity.Data;
using StayOver.Models;
using System;

namespace StayOver.Data.Dtos
{
    public class ReservationReadDto
    {
        public int ReservationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public Review Review { get; set; }

        public virtual ApplicationUser Visiter { get; set; }
        public virtual Accommodation Accommodation { get; set; }
    }
}
