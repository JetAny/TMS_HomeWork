using MyGarageMVC.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyGarageMVC.Models
{
    public class OvnerModel : IValidatableObject
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [NameValidationAtribute]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [NameValidationAtribute]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress]
        public string? email { get; set; }

        [RegularExpression(@"^+375-\\d{2}-\d{3}-\d{2}-\{2}$")]  //тел. в формате +375-xx-xxx-xx-xx

        public string? PhoneNamber { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.FirstName))
            {
                errors.Add(new ValidationResult("Введите имя!", new List<string>() { "FirstName" }));
            }
            if (this.LastName.Length > 5)
            {
                errors.Add(new ValidationResult("Фамилия должна содержать не более 5 символов", new List<string> { "LastName" }));
            }
            if (string.IsNullOrWhiteSpace(this.email))
            {
                errors.Add(new ValidationResult("Введите электронный адрес!"));
            }
            if (string.IsNullOrWhiteSpace(this.PhoneNamber))
            {
                errors.Add(new ValidationResult("Введите номер телефона +375-хх-ххх-хх-хх!"));
            }

            return errors;
        }
    }


}
