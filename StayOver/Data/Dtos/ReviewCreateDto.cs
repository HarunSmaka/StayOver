using System;
using System.ComponentModel.DataAnnotations;

namespace StayOver.Data.Dtos
{
    public class ReviewCreateDto
    {
        public string Comment { get; set; }
        [Required]
        public int Rating { get; set; }

        public DateTime PublishedDate { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        [Required]
        public int ReservationId { get; set; }
    }
}
