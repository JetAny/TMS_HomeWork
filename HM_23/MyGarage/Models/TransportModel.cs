using MyGarageDB.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyGarageMVC.Models
{
    public class TransportModel : IValidatableObject
    {
       
        public int IdTr { get; set; }
        [Required(ErrorMessage = "Не указан вид топлива")]
        [FuelTransportValidation]
        public string FuelType { get; set; }
        [Required]
        public int FuelQuntity { get; set; }

        public string Brand { get; set; }
        [Range(100, 250, ErrorMessage = "Превышена максимальная скорость")]
        public int MaxSpeed { get; set; }
        [Required]
        [StringLength(7)]
        public string Namber { get; set; }
        public bool OnRoad { get; set; }

        public virtual GarageModel Garage { get; set; }
        public virtual TypeModel Type { get; set; }
        public virtual OvnerModel Ovner { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.FuelType))
            {
                errors.Add(new ValidationResult("Введите тип топлива", new List<string>() { "FuelType" }));
            }
            if (string.IsNullOrWhiteSpace(this.Namber))
            {
                errors.Add(new ValidationResult("Введите номер автомобиля", new List<string> { "Namber" }));
            }
            if (this.Namber.Length < 7 || this.Namber.Length>7)
            {
                errors.Add(new ValidationResult("Неверно введен номер автомобиля", new List<string> { "Namber" }));
            }
            return errors;
        }
    }
}
