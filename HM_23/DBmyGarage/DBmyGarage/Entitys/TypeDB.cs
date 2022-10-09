

using System.ComponentModel.DataAnnotations;

namespace MyGarageDB
{
    public partial class TypeDB
    {
        public TypeDB()
        {
            Transports = new HashSet<TransportDB>();
        }

        public int Id { get; set; }
        [Required]
        public string TypeTrans { get; set; }

        public virtual ICollection<TransportDB> Transports { get; set; }

    }
}
