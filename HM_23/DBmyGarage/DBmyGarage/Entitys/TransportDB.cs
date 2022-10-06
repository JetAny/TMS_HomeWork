

namespace MyGarageDB
{
    public partial class TransportDB
    {
        public int IdTr { get; set; }
        public string? FuelType { get; set; }
        public int FuelQuntity { get; set; }
        public string? Brand { get; set; }
        public int MaxSpeed { get; set; }
        public string? Namber { get; set; }
        //public int? TypeId { get; set; }
        //public int? GarageId { get; set; }
        public bool? OnRoad { get; set; }

        public virtual GarageDB? Garage { get; set; }
        public virtual TypeDB? Type { get; set; }
        
    }
}
