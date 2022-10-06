namespace MyGarageMVC.Models
{
    public class TypeModel
    {
        public int Id { get; set; }
        public string TypeTrans { get; set; }

        public virtual ICollection<TransportModel> Transports { get; set; }
    }
}
