using Microsoft.AspNetCore.Mvc;
using MyGarageMVC.Intrefaces;
using MyGarageMVC.Models;
using System.Dynamic;

namespace MyGarageMVC.Controllers
{
    public class TransportController : Controller
    {
        private readonly IGetTransportService _getAllTransportService;
        private readonly IGetAllGarageService _getAllGarageService;
        private readonly IMovingTransportService _movingTransportService;
        private readonly IReturnTransportService _returnTransportService;
        private readonly IDeleteTransportService _deleteTransportService;

        public TransportController(
            IGetTransportService getAllTransportService,
            IGetAllGarageService getAllGarageService,
            IMovingTransportService movingTransportService,
            IReturnTransportService returnTransportService,
            IDeleteTransportService deleteTransportService
            )
        {
            _getAllTransportService = getAllTransportService;
            _getAllGarageService = getAllGarageService;
            _movingTransportService = movingTransportService;
            _returnTransportService = returnTransportService;
            _deleteTransportService = deleteTransportService;

        }
       
        [HttpGet]
        public async Task <IActionResult> Input()
        {
            dynamic mymodel = new ExpandoObject();
            await Task.Delay(1000);
            List<GarageModel> allGarageTtansport = _getAllGarageService.GetAll();
           mymodel.Garage = allGarageTtansport;
            return View("Input", mymodel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Sort(string Sity_garage)
        {

            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();
            mymodel.GarageSity = Sity_garage;
            return View("Sort", mymodel);
        }

        [HttpGet]
        public async Task<IActionResult> Output(int idGarage, int idTransport, int loading)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();          
            mymodel.GarageId = idGarage;
            mymodel.Loading=loading;
           _movingTransportService.Send(idGarage, idTransport);
            mymodel.Garage = _getAllGarageService.GetAll();           
            return View("Output", mymodel);
        }
        [HttpGet]
        public async Task<IActionResult> Return(int idGarage, int idTransport)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Garage = _getAllGarageService.GetAll();
            mymodel.GarageId = idGarage;
            _movingTransportService.Send(idGarage, idTransport);
            mymodel.Garage = _getAllGarageService.GetAll();
            return View(mymodel);
        }

    }
}
