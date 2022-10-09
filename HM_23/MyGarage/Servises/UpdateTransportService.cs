using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;

namespace MyGarageMVC.Servises
{
    public class UpdateTransportService: IUpdateTransportService
    {
        private readonly IDbContext _dbContext;

        public UpdateTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(int IdGarage, int IdTransport, string fuelType, int fuelQuantity, string brand, string namber)
        {
            var updateTransport = _dbContext.Transports.Find(IdTransport);

            if (updateTransport != null)
            {
                updateTransport.FuelType = fuelType;
                updateTransport.FuelQuntity = fuelQuantity;
                updateTransport.Brand = brand;
                updateTransport.Namber = namber;
              

                //updateTransport.Garage = IdGarage;
                _dbContext.Transports.Update(updateTransport);
                _dbContext.SaveChanges();
            }
        }
    }
}
