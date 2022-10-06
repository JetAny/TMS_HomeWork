namespace MyGarageMVC.Models
{
    public class TransportModel
    {
       
        public int IdTr { get; set; }
        public string FuelType { get; set; }
        public int FuelQuntity { get; set; }
        public string Brand { get; set; }
        public int MaxSpeed { get; set; }
        public string Namber { get; set; }
        public bool OnRoad { get; set; }

        public virtual GarageModel Garage { get; set; }
        public virtual TypeModel Type { get; set; }
    }
}
