using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarage
{
    internal class Tractor : MechanicalMeans
    {
        public Tractor(string fuelType, double fuelQuantity, string brand, int maxSpeed) :
            base(fuelType, fuelQuantity, brand, maxSpeed)
        {
        }
        public override void DoJob()
        {
            Console.WriteLine($"Трактор пашет поле");
        }
        public override void Move()
        {
            Console.WriteLine($"Трактор едет по проселочной  дороге");
        }
        public override void HelpHeadlights()
        {
            Console.WriteLine($"Поморгал фарами\n");
        }
    }
}
