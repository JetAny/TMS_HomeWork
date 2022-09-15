using MyGarage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace MyGarage.Controllers
{
    public class TransportController : Controller
    {
        [HttpGet]
        public IActionResult Input()
        {
            dynamic mymodel = new ExpandoObject();
            Populator.Populate();
            mymodel.Garages = DB.garages;
            return View("Input", mymodel);
        }

        //[Route("Index")]
        [HttpGet]
        public IActionResult Index(int Idt)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garages = DB.garages;
            List<ITransport>? g = new List<ITransport> { };

            foreach (Garage item in DB.garages)
            {
                if (item.Id == Idt)
                {
                    if (Idt == 0)
                    {
                        g = Garage.transportsGar;
                    }
                    else
                    {
                        g = item.transportOnGarage;
                    }
                }
            }
            mymodel.Transport = g;
            return View("Index", mymodel);
        }

        //[Route("output")]
        [HttpGet]
        public IActionResult Output(int IdGarage, int IdTransport, int load)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garages = DB.garages;
            List<ITransport>? g = new List<ITransport> { };
            List<ITransport>? t = new List<ITransport> { };
            g = Garage.transportsGar;
            bool sendLog = true;
            foreach (Garage item in DB.garages)
            {
                if (item.Id == IdGarage)
                {
                    for (int i = 0; i < item.transportOnGarage.Count; i++)
                    {
                        int z = i + 2;
                        if (item.transportOnGarage[i].IdTr == IdTransport)
                        {
                            item.SendTransOnFlight(load, item.transportOnGarage[i]);
                            t = Garage.transOnFlight;
                            g = Garage.transportsGar;
                            break;
                        }
                        if (z > item.transportOnGarage.Count) { sendLog = false; }
                    }
                    break;
                }
            }
            mymodel.Exept = sendLog;
            mymodel.SendTransport = t;
            mymodel.Transport = g;

            return View("Output", mymodel);
        }
        public IActionResult Return(int IdGarage, int IdTransport)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garages = DB.garages;          
            foreach (Garage item in DB.garages)
            {
                if (item.Id == IdGarage)
                    foreach (ITransport transport in Garage.transOnFlight)
                    {
                        if (transport.IdTr == IdTransport)
                        {
                            item.ReturnFromFlight(transport);                           
                        }break;
                    }               
            }
            mymodel.Transport = Garage.transOnFlight;
            return View(mymodel);
        }
    }
}
