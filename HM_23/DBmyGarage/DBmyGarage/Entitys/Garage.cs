using System;
using System.Collections.Generic;

namespace DBmyGarage
{
    public partial class Garage
    {
        public Garage()
        {
            Transports = new HashSet<Transport>();
        }

        public int Id { get; set; }
        public string Sity { get; set; } = null!;

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
