using AirlineBookingsProject.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingsProject.Models
{
    public class Booking
    {
        [Key]
        [Display(Name = "Booking ID")]
        [RegularExpression(@"^(B)[0-9]{3}$")]
        public string BookingId { get; set; }

        [Required]
        [Display(Name ="Booking Date")]
        [ValidDateResult(ErrorMessage = "The hiring date must be before today.")]
        public DateTime BookingDate { get; set; }

        [Required]
        [Display(Name = "Booking Status")]
        public string Status { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Flight")]
        public string FlightId { get; set; }
        public Flight Flight { get; set; }

        public List<Passenger> Passengers { get; set; }
        public Payment Payment { get; set; }

    }
}
