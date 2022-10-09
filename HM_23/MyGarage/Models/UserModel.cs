using System.ComponentModel.DataAnnotations;

namespace MyGarageMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан Password")]
        public string Password { get; set; }

    }
}
