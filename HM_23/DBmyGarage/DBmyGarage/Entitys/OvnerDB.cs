using System.ComponentModel.DataAnnotations;


namespace MyGarageDB.Entitys
{
    public class OvnerDB
    {
        public OvnerDB()
        {
            Transports = new HashSet<TransportDB>();

        }
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 10 символов")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Фамилия должно содержать от 2 до 15 символов")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Не указана электронная почта")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string email { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        public string PhoneNamber { get; set; }
        public virtual ICollection<TransportDB> Transports { get; set; }

    }
}
