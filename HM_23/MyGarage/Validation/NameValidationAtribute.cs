using System.ComponentModel.DataAnnotations;


namespace MyGarageMVC.Validation
{

    public class NameValidationAtribute : ValidationAttribute
    {
        public NameValidationAtribute()
        {
            ErrorMessage = " Здесь должно быть не менее 3 символов";
        }
        public override bool IsValid(object? value)
        {
            
            var ovnerName = value.ToString();
            return ovnerName.Length >= 3;

        }
    }
}
