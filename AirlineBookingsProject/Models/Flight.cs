using AirlineBookingsProject.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingsProject.Models
{
    public class Flight
    {
        [Key]
        [RegularExpression(@"^(F)[0-9]{3}$")]
        public string FlightId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}[0-9]{3}$", ErrorMessage = "FlightNo must be like EK202")]
        public string FlightNo { get; set; }

        [Required]
        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Required]
        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Required]
        [Display(Name = "Flight Date")]
        [ValidDateAttribute(ErrorMessage = "The flight date must be today or later (no past dates).")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Flight Time")]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name = "Flight Price")]
        [Range(0, 99999, ErrorMessage = "The price must be between 0 and 99999")]
        public double Price { get; set; }

        public List<Booking> Bookings { get; set; } = new();
    }
}
