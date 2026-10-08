using System.ComponentModel.DataAnnotations;

namespace AirlineBookingsProject.CustomValidations
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime Date = Convert.ToDateTime(value);

            if (Date >= DateTime.Today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
