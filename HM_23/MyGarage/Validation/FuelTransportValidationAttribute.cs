using System.ComponentModel.DataAnnotations;

namespace MyGarageDB.Validation
{
    public class FuelTransportValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value.ToString().Equals("disel");

        }
    }
}
