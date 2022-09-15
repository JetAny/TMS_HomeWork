using System;
using System.Collections.Generic;

namespace DBmyGarage
{
    public partial class Type
    {
        public Type()
        {
            Transports = new HashSet<Transport>();
        }

        public int Id { get; set; }
        public string? TypeTrans { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
