using System;
using System.Collections.Generic;

namespace DBmyGarage
{
    public partial class Transport
    {
        public int IdTr { get; set; }
        public string? FuelType { get; set; }
        public int? FuelQuntity { get; set; }
        public string? Brand { get; set; }
        public int? MaxSpeed { get; set; }
        public string? Namber { get; set; }
        public int? TypeId { get; set; }
        public int? GarageId { get; set; }

        public virtual Garage? Garage { get; set; }
        public virtual Type? Type { get; set; }
    }
}
