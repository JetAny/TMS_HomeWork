using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarage
{
    public interface ILoading
    {
       int _totalLoad { get; set; }
        void Load(int totalLoad);
    }
}
