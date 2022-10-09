using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;

namespace MyGarageMVC.Models
{
    public class MovingTransportService : IMovingTransportService
    {
        private readonly IDbContext _dbContext;

        public MovingTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public static bool sendLog = true;

        public void Send(int idGarage, int idTransport)
        {
            var garage = _dbContext.Garages.Find(idGarage);
            var movingTransport = _dbContext.Transports.Find(idTransport);

            if (garage != null)
            {

                if (movingTransport != null)
                {
                    if (movingTransport.OnRoad == true)
                    {
                        movingTransport.Garage = garage;
                        movingTransport.OnRoad = false;
                        _dbContext.Transports.Update(movingTransport);
                    }
                    else
                    {
                        movingTransport.OnRoad = true;
                        _dbContext.Transports.Update(movingTransport);
                    }
                    
                    _dbContext.SaveChanges();
                }

            }
        }

    }
}
