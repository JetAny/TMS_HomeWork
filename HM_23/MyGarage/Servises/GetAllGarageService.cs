using Microsoft.EntityFrameworkCore;
using MyGarageDB;
using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;
using MyGarageMVC.Models;

namespace MyGarageMVC.Servises
{
    public class GetAllGarageService: IGetAllGarageService
    {
        private readonly IDbContext _dbContext;


        public GetAllGarageService(IDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public List<GarageModel> GetAll()
        {

            var allGarageDB = _dbContext.Garages
                .Include(u => u.Transports)
                .ThenInclude(c => c.Type).ToList();
            ServiceMap _serviceMap = new ServiceMap();

            var getAllGarage = _serviceMap.MapDbModel(allGarageDB);

            return getAllGarage;
        }

        
    }
}
