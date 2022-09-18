
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;

namespace MyGarageMVC.Models
{
    public class GetTransportService : IGetTransportService
    {
        private readonly IDbContext _dbContext;
        public static List<TransportModel> allTrans = new List<TransportModel>();

        public GetTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TransportModel GetTransport(int IdGarage, int IdTransport)
        {
            var changeTransport = _dbContext.Transports.Find(IdTransport);
            var transport = new TransportModel
            {
                IdTr = changeTransport.IdTr,
                FuelType = changeTransport.FuelType,
                FuelQuntity = changeTransport.FuelQuntity,
                Brand = changeTransport.Brand,
                MaxSpeed = changeTransport.MaxSpeed,
                Namber = changeTransport.Namber,
                OnRoad = (bool)changeTransport.OnRoad,
                
            };
            return transport;
        }
    }
}
