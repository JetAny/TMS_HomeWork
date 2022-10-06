using MyGarageDB;
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;
using MyGarageMVC.Models;

namespace MyGarageMVC.Servises
{
    public class ReturnTransportService : IReturnTransportService
    {
        private readonly IDbContext _dbContext;

        public List<GarageModel> sendTransport = new List<GarageModel>();

        public ReturnTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Return(int idGarage, int transportReturn)
        {
            var returnTransport = _dbContext.Transports.Find(transportReturn);

            if (returnTransport != null)
            {
                _dbContext.Transports.Remove(returnTransport);
                _dbContext.SaveChanges();
                returnTransport.OnRoad = false;
                _dbContext.Transports.Add(returnTransport);
                _dbContext.SaveChanges();
            }
        }
    }
}
