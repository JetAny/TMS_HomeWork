using MyGarageDB.Interfaces;
using MyGarageMVC.Intrefaces;

namespace MyGarageMVC.Servises
{
    public class DeleteTransportService : IDeleteTransportService
    {
        private readonly IDbContext _dbContext;

        public DeleteTransportService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int TransportId)
        {
            var removeTransport = _dbContext.Transports.Find(TransportId);
            _dbContext.Transports.Remove(removeTransport);
            _dbContext.SaveChanges();
        }

    }
}
