using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using TSD.Linq.Cars;
using System.Xml.Linq;

namespace TSD.Linq.Cars
{
    public class CarSalesBook
    {
        private IList<Car> _cars;

        public CarSalesBook()
        {
            _cars = ReadCarsFromFile();

            IEnumerable<String> Top3Brands = (from car in _cars 
            orderby car.Sales2014 descending
            select car.Make).Take(3);
            Console.WriteLine("Top 3 brands of 2014:");
            foreach (String brand in Top3Brands) {
                Console.WriteLine(brand);
            }

            IEnumerable<String> ImprovedBrands = (from car in _cars 
            where car.Sales2014 * 1.5 <= car.Sales2015
            select car.Make);
            Console.WriteLine("Brands that improved their y/y results by at least 50%:");
            foreach (String brand in ImprovedBrands) {
                Console.WriteLine(brand);
            }

            IEnumerable<String> SecondTen = (from car in _cars 
            orderby car.Sales2015 descending
            select car.Make).Skip(10).Take(3);
            Console.WriteLine("Top 3 in second ten of 2015:");
            foreach (String brand in SecondTen) {
                Console.WriteLine(brand);
            }

            int sum2014 = (from car in _cars select car.Sales2014).Sum();
            int sum2015 = (from car in _cars select car.Sales2015).Sum();

            Console.WriteLine("Sum 2014: {0:D}, Sum 2015: {1:D}", sum2014, sum2015);

            IEnumerable<String> Top10 = (from car in _cars 
            orderby car.Sales2015 descending
            select car.Make).Take(10);
            Console.WriteLine("Top 10 brands of 2015:");
            foreach (String brand in Top10) {
                Console.WriteLine(brand);
            }

            IEnumerable<String> Last10 = (from car in _cars 
            orderby car.Sales2015 ascending
            select car.Make).Take(10);
            Console.WriteLine("Last 10 brands of 2015:");
            foreach (String brand in Last10) {
                Console.WriteLine(brand);
            }

            SaveCarsToXML();

            _cars.Clear();

            ReadCarsFromXML();

            SaveCarsToXML();

        }

        private void SaveCarsToXML() {
            XDocument carsDocument = new XDocument(
                new XElement("Cars", 
                    _cars.Select(car => new XElement("Car", new XAttribute("Make", car.Make), new XAttribute("Sales2014", car.Sales2014), new XAttribute("Sales2015", car.Sales2015)))
                )
            );
            carsDocument.Declaration = new XDeclaration("1.0", "utf-8", "true");
            carsDocument.Save("./Cars.xml");
        }
        
        private void ReadCarsFromXML() {
            _cars = XDocument.Load(@"./Cars.xml").Descendants("Car").Select(e => new Car(e.Attribute("Make").Value) {Sales2014 = Int32.Parse(e.Attribute("Sales2014").Value), Sales2015 = Int32.Parse(e.Attribute("Sales2015").Value)}).ToList();
        }

        private IList<Car> GenerateCars()
        {
            List<Car> cars = new List<Car>();
            Car car1 = new Car("Skoda");
            car1.Sales2015 = 45529;
            car1.Sales2014 = 44243;

            cars.Add(car1);

            Car car2 = new Car("Toyota");
            car2.Sales2015 = 36465;
            car2.Sales2014 = 31484;

            cars.Add(car2);

            Car car3 = new Car("BMW");
            car3.Sales2015 = 9549;
            car3.Sales2014 = 7714;

            cars.Add(car3);


            var sortedCars = cars.OrderBy(c => c.Sales2015).ToList();

            return cars;
        }

        private IList<Car> ReadCarsFromFile()
        {
            return CarDataFileReader.ReadCarsFromCSVFile();
        }
    }
}
