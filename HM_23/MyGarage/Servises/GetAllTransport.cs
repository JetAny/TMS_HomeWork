using DBmyGarage;
using DBmyGarage.Interfaces;
using MyGarage.Intrefaces;

namespace MyGarage.Models
{
    public class GetAllTransport:IGetAllTransport
    {
        private readonly IDbContext _dbContext;

        public GetAllTransport(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TransportModel> GetAll()
        {
            var allTransport = _dbContext.Transport.Select(c => new TransportModel
            {
                IdTr = c.IdTr,
                fuelQuantity = (int)c.FuelQuntity,
                brand=c.Brand,
                maxSpeed= (int)c.MaxSpeed,
                fuelType=c.FuelType,
                namber=c.Namber,
                sityGarage=c.Garage.Sity,
                typeTransport=c.Type.TypeTrans
            }).ToList();
            return allTransport;
        }
    }
}
