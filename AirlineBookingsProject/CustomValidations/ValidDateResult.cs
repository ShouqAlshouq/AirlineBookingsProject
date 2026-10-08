using AirlineBookingsProject.Data;
using System.ComponentModel.DataAnnotations;

namespace AirlineBookingsProject.CustomValidations
{
    public class ValidDateResult : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var booking = (Models.Booking)validationContext.ObjectInstance;

            var _dbContext = validationContext.GetService(typeof(AppDbContext)) as AppDbContext;

            var flight = _dbContext.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);

            DateTime bookingDate = Convert.ToDateTime(value);

            if (bookingDate > flight.Date)
            {
                return new ValidationResult("Booking date must be before flight date.");
            }

            return ValidationResult.Success;
        }
    }
}
