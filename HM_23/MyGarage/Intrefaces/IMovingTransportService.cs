using MyGarageDB.Interfaces;
using MyGarageMVC.Models;

namespace MyGarageMVC.Intrefaces
{
    public interface IMovingTransportService
    {
        public void Send(int idGarage, int iDTransport);
    }
}
