namespace MyGarageMVC.Intrefaces
{
    public interface IUpdateTransportService
    {
        public void Update(int IdGarage, int IdTransport, string fuelType, int fuelQuantity, string brand, string namber);

    }
}
