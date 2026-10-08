using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingsProject.Models
{
    public class Passenger
    {
        [Key]
        public string PassengerId { get; set; }

        [Required]
        [Display(Name = "Passenger Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Passenger Passport")]
        public string PassportNo { get; set; }

        [Required]
        [Display(Name = "Passenger Nationality")]
        public string Nationality { get; set; }


        [ForeignKey("Booking")]
        public string BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
