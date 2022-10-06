using MyGarageDB;
using MyGarageMVC.Models;

namespace MyGarageMVC.Intrefaces
{
    public interface IGetAllGarageService
    {
        List<GarageModel> GetAll();
    }
}
