using Microsoft.AspNetCore.Mvc;
using MyGarageDB;
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;
using MyGarageMVC.Models;
using System.Dynamic;

namespace MyGarageMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICreateTransportService _createTransportService;
        private readonly IGetAllGarageService _getAllGarageService;
        private readonly IGetTransportService _getTransportService;
        private readonly IUpdateTransportService _updateTransportService;

        private readonly IDbContext _dbContext;

        public HomeController(
            IDbContext dbContext,
            ILogger<HomeController> logger,
            ICreateTransportService createTransportService,
            IGetAllGarageService getAllGarageService,
            IGetTransportService getTransportService,
            IUpdateTransportService updateTransportService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _createTransportService = createTransportService;
            _getAllGarageService = getAllGarageService;
            _getTransportService = getTransportService;
            _updateTransportService = updateTransportService;
        }
       

        [HttpGet]
        public IActionResult Index()
        {
            _createTransportService.Create();
 
            return View();
        }


        [HttpGet]
        public IActionResult Input()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();
            return View("Input",mymodel);
        }
        [HttpGet]
        public IActionResult InputTrans(int IdGarage)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();
            mymodel.IdGarage = IdGarage;
            return View("InputTrans",mymodel);
        }
        [HttpPost]
        public IActionResult Сhange (int IdGarage, int IdTransport)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();
            mymodel.Transport= _getTransportService.GetTransport(IdGarage, IdTransport);
            mymodel.IdTransport=IdTransport;
            mymodel.IdGarage = IdGarage;
            return View("Change", mymodel);
        }

        [HttpPost]
        public RedirectToActionResult Update(int IdGarage, int IdTransport, string fuelType, int fuelQuantity, string brand, string namber)
        {
            _updateTransportService.Update(IdGarage,IdTransport, fuelType,  fuelQuantity,  brand,  namber);
            return RedirectToAction("InputTrans", "Home", new { Sity_garage = IdGarage });
        }

    }
}