using MyGarage.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace MyGarage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        Garage garage1 = new Garage();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Input()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garages = DB.garages;
            return View(mymodel);
        }
        [HttpGet]
        public IActionResult InputTrans(int IdGarage)
        {
            dynamic mymodel = new ExpandoObject();
            foreach (var item in DB.garages)
            {
                if (item.Id == IdGarage)
                {
                    mymodel.Transport = item.transportOnGarage;
                    break;
                }
            }
            mymodel.IdGarage = IdGarage;

            return View(mymodel);
        }
        [HttpPost]
        public IActionResult Сhange
            (int IdGarage, int IdTransport)
        {
            dynamic mymodel = new ExpandoObject();

            foreach (Garage garage in DB.garages)
            {
                if (garage.Id == IdGarage)
                {
                    foreach (ITransport transport in garage.transportOnGarage)
                    {
                        if (transport.IdTr == IdTransport)
                        {
                            mymodel.Transport = transport;
                            break;
                        }
                    }
                    break;
                }
            }
            mymodel.IdGarage = IdGarage;
            return View("Change", mymodel);
        }

        [HttpPost]
        public RedirectToActionResult editTransport(int IdGarage, int IdTransport, string fuelType, double fuelQuantity, string brand, int namber)
        {
            dynamic mymodel = new ExpandoObject();
            foreach (Garage garage in DB.garages)
            {
                if (garage.Id == IdGarage)
                {
                    foreach (ITransport transport in garage.transportOnGarage)
                    {
                        if (transport.IdTr == IdTransport)
                        {
                            transport.brand = brand;
                            transport.namber = namber;
                            transport.fuelType = fuelType;
                            transport.fuelQuantity = fuelQuantity;
                            break;
                        }
                    }
                    break;
                }
            }
            mymodel.Garages = DB.garages;
            return RedirectToAction("Index", "Transport", new { Idt = IdGarage });
        }

    }
}