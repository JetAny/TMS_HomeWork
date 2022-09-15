using MyGarage.Models;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace MyGarage
{
    delegate void AddPartDelegate(int tape, int index);
    delegate void SendTransOnFlight(int load);
    delegate void RemovePartDelegate();

    [Serializable]
    public class Garage
    {
        public int Id { get; set; }
        public string? Sity { get; set; }

        public  List<ITransport> transportOnGarage = new List<ITransport>();
        public static List<ITransport> transOnFlight = new List<ITransport>();
        public static List<IAddParts> _parts = new List<IAddParts>();
        public static List<string> garagesLog = new List<string>();
        public static List<ITransport> transportsGar = new List<ITransport>();


        public Garage()
        {
            this.Id = Id;
            this.Sity = Sity;
        }

        public void AddMechanicalMeans(ITransport mechanicalMeans)
        {
            Populator.counter += 1;
            mechanicalMeans.IdTr = Populator.counter;
            //mechanicalMeans.namber =Servise.namberRandom();
            transportOnGarage.Add(mechanicalMeans);
            transportOnGarage.Sort();
            transportsGar.Add(mechanicalMeans);
        }
        public void TransportSerializBin()
        {
            int i = 0;
            ITransport[] garagesTransport = new ITransport[transportOnGarage.Count];
            foreach (ITransport transport in transportOnGarage)
            {
                if (transport != null)
                {
                    garagesTransport[i] = transport;
                    i++;
                }
            }

            BinaryFormatter formBin = new BinaryFormatter();

            using (FileStream fs = new FileStream("transportOnGarage.dat", FileMode.OpenOrCreate))
            {
                formBin.Serialize(fs, garagesTransport);
            }
        }
        public async Task TransportSerializJSON()
        {

            using (FileStream fs = new FileStream("garagesTransport.json", FileMode.OpenOrCreate))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                int i = 0;
                ITransport[] garagesTransport = new ITransport[transportOnGarage.Count];
                foreach (ITransport transport in transportOnGarage)
                {
                    if (transport != null)
                    {
                        garagesTransport[i] = transport;

                        i++;
                    }
                }

                await JsonSerializer.SerializeAsync<ITransport[]>(fs, garagesTransport, options);
            }
        }
        public void TransportSerializXML()
        {
            // объект для сериализации
            int i = 0;
            ITransport[] garagesTransport = new ITransport[transportOnGarage.Count];
            foreach (ITransport transport in transportOnGarage)
            {
                if (transport != null)
                {
                    garagesTransport[i] = transport;
                    i++;
                }
            }
            // передаем в конструктор тип класса MechanicalMeans[]
            //XmlSerializer formatter = new XmlSerializer(typeof(ITransport[]));
            // получаем поток, куда будем записывать сериализованный объект
            //using (FileStream fs = new FileStream("garagesTransportXML.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, garagesTransport);

            //}

        }
        public int GetIndex<T>(T myTransport)
        {
            if (myTransport == null)
            {
                return 0;
            }
            ITransport _myTransport = (ITransport)myTransport;

            return transportOnGarage.BinarySearch(_myTransport);
        }
        public void PrintGarage()
        {
            Console.WriteLine(new string('=', 140));
            foreach (var trans in transportOnGarage)
            {
                Console.WriteLine(trans);
            }
            Console.WriteLine(new string('=', 140));
        }
        public void PrintGarageParts()
        {
            Console.WriteLine(new string('=', 140));

            foreach (var part in _parts)
            {
                Console.WriteLine(part);
            }
            Console.WriteLine(new string('=', 140));
        }
        public void SendTransOnFlight(int load, ITransport transport)
        {
            string log = $"\nВ рейс отправился: {transport}\n";
            Console.WriteLine(log);
            garagesLog.Add(log);
            transportOnGarage.Remove(transport);
            transportsGar.Remove(transport);
            transOnFlight.Add(transport);
            ILoading loadTrans = (ILoading)transport;
            loadTrans.Load(load);
            transport.Move();
        }
        public void ReturnFromFlight(ITransport returnTrans)
        {
            if (transOnFlight.Count == 0)
            {
                Console.WriteLine($"\nВесь транспорт находится в гараже \n");
            }
            else
            {
                transportOnGarage.Add(returnTrans);
                transOnFlight.Remove(returnTrans);
                string log = $"\nИз рейса вернулся: {returnTrans}\n";
                garagesLog.Add(log);
                Console.WriteLine(log);
                returnTrans.HelpHeadlights();
                PrintGarage();
            }
        }
        public void AddPart(int tape, int index)
        {
            IAddParts part = new Parts();

            if (tape > 1)
            {
                Console.WriteLine("Неверно введен тип запчасти, надо ввести 0 или 1");
            }
            if (tape == 0)
            {
                part.AddParts(new ElectricParts(), index);
                _parts.Add(part);
                garagesLog.Add($"На склад добавленна {part}");
            }
            if (tape == 1)
            {
                part.AddParts(new MechanicalParts(), index);
                _parts.Add(part);
                garagesLog.Add($"На склад добавленна {part}");
            }
        }
        public void RemovePart(int tape, int index)
        {
            IAddParts part = new Parts();

            if (tape > 1)
            {
                Console.WriteLine("Неверно введен тип запчасти, надо ввести 0 или 1");
            }
            if (tape == 0)
            {
                part.RemoveParts(new ElectricParts(), index);
                _parts.Remove(part);
                garagesLog.Add($"Со склада выдана {part}");
            }
            if (tape == 1)
            {
                part.RemoveParts(new MechanicalParts(), index);
                _parts.Remove(part);
                garagesLog.Add($"Со склада выдана {part}");
            }
        }
        public void PrintGarageLog()
        {
            Console.WriteLine(new string('=', 140));
            Console.WriteLine($"{new string('=', 50)}Вывод LOG в гараже{new string('=', 50)}\n");
            foreach (var log in garagesLog)
            {
                Console.WriteLine(log);
            }
            Console.WriteLine(new string('=', 140));
        }


        public override string ToString()
        {
            return $"В гараже числится{transportOnGarage.Count} автомобилей";
        }



    }


}
