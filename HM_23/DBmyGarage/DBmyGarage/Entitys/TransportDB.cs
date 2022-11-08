


using MyGarageDB.Entitys;
using MyGarageDB.Validation;
using System.ComponentModel.DataAnnotations;

namespace MyGarageDB
{
    public partial class TransportDB
    {

        public int IdTr { get; set; }

        [Required]
        [FuelValidation(new string[] { "Дизель", "Бензин", "Электричество" }, ErrorMessage = "Недопустимый тип топлива")]
        public string? FuelType { get; set; }

        [Range(100, 250, ErrorMessage = "Мало топлива")]
        public int FuelQuntity { get; set; }

        [Required(ErrorMessage = "Не указан Brand автомобиля")]
        public string? Brand { get; set; }

        [Range(100, 250, ErrorMessage = "Неверно указана максимальная скорость")]
        public int MaxSpeed { get; set; }

        [StringLength(7, MinimumLength = 7, ErrorMessage = "Неверно указан номер автомобиля")]
        public string? Namber { get; set; }

        public int? TypeId { get; set; }
        public int? GarageId { get; set; }
        public bool? OnRoad { get; set; }

        public virtual GarageDB? Garage { get; set; }
        public virtual TypeDB? Type { get; set; }
        public virtual OvnerDB Ovner { get; set; }

    }
}
