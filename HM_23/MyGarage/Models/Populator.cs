namespace MyGarage.Models
{
    public class Populator
    {
        public static int counter;

        public static void Populate()
        {

            if (DB.garages.Count == 0)
            {


                var garage = new Garage { Id = 0, Sity = "Всего машин" };
                var garage1 = new Garage { Id = 1, Sity = "Минск" };
                var garage2 = new Garage { Id = 2, Sity = "Варшава" };
                var garage3 = new Garage { Id = 3, Sity = "Берлин" };

                ITransport car1 = new Car("Бензин", 55, "Шкода", 180, 4);
                ITransport car2 = new Car("Дизель", 65, "БМВ", 230, 6);
                ITransport bus1 = new Bus("Дизель", 450, "Neoplan", 120, 56);
                ITransport bus2 = new Bus("Дизель", 450, "Neoplan", 120, 56);
                ITransport truck1 = new Truck("Дизель", 450, "Mersedes", 100, 25);
                ITransport truck2 = new Truck("Дизель", 450, "Man", 100, 25);
                
            
                ITransport bus3 = new Bus("Дизель", 220, "Scania", 120, 41);
                ITransport bus4 = new Bus("Дизель", 450, "Scania", 120, 56);
                garage1.AddMechanicalMeans(car1);
                garage1.AddMechanicalMeans(car2);
                garage1.AddMechanicalMeans(bus1);
                garage1.AddMechanicalMeans(bus2);

                garage2.AddMechanicalMeans(bus3);
                garage2.AddMechanicalMeans(bus4);

                garage3.AddMechanicalMeans(truck1);
                garage3.AddMechanicalMeans(truck2);

                //garage1.AddMechanicalMeans(bus3);
                //garage3.AddMechanicalMeans(bus4);
                DB.garages.Add(garage);
                DB.garages.Add(garage1);
                DB.garages.Add(garage2);
                DB.garages.Add(garage3);
            }
        }
    }
}
