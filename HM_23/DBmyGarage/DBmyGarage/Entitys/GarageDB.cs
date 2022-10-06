


namespace MyGarageDB
{
    public partial class GarageDB
    {
        //public Garage()
        //{
        //    Transports = new HashSet<Transport>();
           
        //}
        

        public int Id { get; set; }
        public string Sity { get; set; }

        public virtual ICollection<TransportDB> Transports { get; set; }
        

    }
}
