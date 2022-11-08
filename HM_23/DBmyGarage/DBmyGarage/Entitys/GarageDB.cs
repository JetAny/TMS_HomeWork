


using System.ComponentModel.DataAnnotations;

namespace MyGarageDB
{
    public partial class GarageDB
    {
        public GarageDB()
        {
            Transports = new HashSet<TransportDB>();

        }

        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано город")]
        public string Sity { get; set; }

        public virtual ICollection<TransportDB> Transports { get; set; }
        

    }
}
