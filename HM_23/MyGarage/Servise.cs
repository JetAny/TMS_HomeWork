using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarageMVC
{
    internal class Servise
    {
        
        public static void Display(string massage)
        {
            Console.WriteLine(massage);
        }
        public static int namberRandom()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }
    }

}
