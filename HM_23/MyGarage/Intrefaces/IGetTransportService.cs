using MyGarageMVC.Models;

namespace MyGarageMVC.Intrefaces
{
    public interface IGetTransportService
    {
        TransportModel GetTransport(int IdGarage, int IdTransport);
    }
}
