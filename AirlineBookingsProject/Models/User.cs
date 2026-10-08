using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingsProject.Models
{
    public class User: IdentityUser
    {
        [StringLength(100)]
        [Required]
        [Display(Name = "User Profile Picture")]
        public string UserPhoto { get; set; } = "noimage.jpg";

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, ErrorMessage = "Full Name must not exceed 50 characters")]
        public string FullName { get; set; }

        [ValidateNever]
        public string Role { get; set; } = "User";

        [ValidateNever]
        public List<Booking> Bookings { get; set; } = new();

    }
}
