using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineBookingsProject.Models
{
    public class Payment
    {
        [Key]
        public string PaymentId { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [Display(Name = "Payment Amount")]
        public double Amount { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public string Method { get; set; }


        [ForeignKey("Booking")]
        public string BookingId { get; set; }
        public Booking Booking { get; set; }
    }
}
