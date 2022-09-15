using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarage
{
    [Serializable]
    public class Parts : IAddParts
    {
        public IParts? namePart;
        public event LogEvents? AddedLog;
        public void AddParts(IParts namePart,int index)
        {
            this.namePart = namePart;            
            namePart.GetParts( index);
            if (AddedLog != null)
                AddedLog($"На склад гаража добавленна запчасть: {namePart}");
        }
        public void RemoveParts(IParts namePart, int index)
        {
            this.namePart = namePart;
            namePart.GetParts(index);
            if (AddedLog != null)
                AddedLog($"Со склада гаража выдана запчасть: {namePart}");
        }

        public override string ToString()
        {
            return $"В гараже есть запчасть: {namePart}\n";
        }
    }
}
