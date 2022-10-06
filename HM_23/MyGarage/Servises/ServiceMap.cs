using MyGarageDB;
using MyGarageMVC.Models;


namespace MyGarageMVC.Servises
{
    public class ServiceMap
    {
        public List<GarageModel> MapDbModel(List<GarageDB> garage)
        {
            List<GarageModel> allGarage = new List<GarageModel>();
            foreach (GarageDB model in garage)
            {
                var gm = new GarageModel();
                gm.Id = model.Id;
                gm.Sity = model.Sity;
                List<TransportModel> allTransports = new List<TransportModel>();
                foreach (TransportDB transport in model.Transports)
                {
                    var trm = new TransportModel();
                    trm.IdTr = transport.IdTr;
                    trm.FuelType = transport.FuelType;
                    trm.FuelQuntity = (int) transport.FuelQuntity;
                    trm.Brand = transport.Brand;
                    trm.MaxSpeed = transport.MaxSpeed;
                    trm.Namber = transport.Namber;
                    trm.OnRoad = (bool)transport.OnRoad;

                    if (transport.Type != null)
                    {
                        TypeModel typeModel = new TypeModel();
                        typeModel.TypeTrans = transport.Type.TypeTrans;
                        typeModel.Id = transport.Type.Id;
                        typeModel.Transports = allTransports;
                        trm.Type = typeModel;
                    }
                       
                    trm.Garage = gm;
                    
                    allTransports.Add(trm);
                }

                gm.transportModel = allTransports;
                allGarage.Add(gm);
            }
            return allGarage;

        }
    }
}

