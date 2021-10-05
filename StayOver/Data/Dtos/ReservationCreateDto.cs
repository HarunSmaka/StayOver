using System;
using System.ComponentModel.DataAnnotations;

namespace StayOver.Data.Dtos
{
    public class ReservationCreateDto
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        [Required]
        public string VisiterId { get; set; }
        [Required]
        public int AccommodationId { get; set; }

        public ReservationCreateDto(DateTime checkedIn, DateTime checkedOut, int accommodationId, string visiterId)
        {
            CreatedAt = DateTime.Now;
            CheckIn = checkedIn;
            CheckOut = checkedOut;
            AccommodationId = accommodationId;
            VisiterId = visiterId;
        }
    }
}
