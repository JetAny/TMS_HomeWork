using MyGarageDB;
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;

namespace MyGarageMVC.Servises
{
    public class CreateTransportService : ICreateTransportService
    {
        private readonly IDbContext _dbContext;

        public CreateTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create()
        {
           for (int i = 0; i < 10; i++)
            {
                TypeDB type;
                if (i > 1)
                {
                    List<TypeDB> types = _dbContext.Types.ToList();
                    type = i % 2 == 0 ? types[0] : types[1];
                }
                else
                {
                    type = new TypeDB
                    {
                        TypeTrans = i % 2 == 0 ? "Car" : "Bus"
                    };
                }
                GarageDB Garage = new GarageDB
                { 

                    Sity = i % 2 == 0 ? "minsk" : "berlin",
                    Transports = new List<TransportDB>()
                        {
                            new TransportDB
                            {
                                FuelType = i % 2 == 0 ? "disel" : "gasoline",
                                FuelQuntity = 20 + i,
                                Brand = i % 2 == 0 ? "gazel" : "scania",
                                Namber = "number" + i,
                                OnRoad = i % 2 == 0? true:false,
                                Type = type
                            }
                        }
                };
                try
                {
                    _dbContext.Garages.Add(Garage);
                    _dbContext.SaveChanges();
                }
                catch
                {
                    _dbContext.Garages.Remove(Garage);
                    throw;
                }
            }
        }
    }
}
