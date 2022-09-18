

namespace MyGarageDB
{
    public partial class TypeDB
    {
        //public Type()
        //{
        //    Transports = new HashSet<Transport>();
        //}

        public int Id { get; set; }
        public string TypeTrans { get; set; }

        public virtual ICollection<TransportDB> Transports { get; set; }

    }
}
