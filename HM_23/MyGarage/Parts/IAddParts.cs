
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarage
{
    public delegate void LogEvents(string log);
    public interface IAddParts
    {
        public event LogEvents? AddedLog;
        public void AddParts(IParts namePart, int index);
        public void RemoveParts(IParts namePart, int index);
    }
}
