namespace MyGarageMVC.Models
{
    public class GarageModel
    {
        public int Id { get; set; }
        public string Sity { get; set; }
        public ICollection<TransportModel> transportModel { get; set; }
    }
}
