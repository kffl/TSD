using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSD.Linq.Cars;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        
        public class MyCollection<T>
        {
            private List<T> list;
            private Random randObj = new Random( 125 );

            public MyCollection() {
                list = new List<T>();
            }

            public void Add(T element) {
                if (randObj.Next(2) == 0) {
                    list.Add(element);
                } else {
                    list.Insert(0, element);
                }
            }

            public T Get(int index) {
                return list[randObj.Next(list.Count)];
            }

            public Boolean isEmpty() {
                return list.Count == 0;
            }

        }
        
        static void Main(string[] args)
        {
            CarSalesBook carSalesBook = new CarSalesBook();
            
            Func<int, Boolean> isLeapYear = year => (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));

            Console.WriteLine("2014 is a leap year: {0:B}", isLeapYear(2014));
            Console.WriteLine("2016 is a leap year: {0:B}", isLeapYear(2016));

            var testCollection = new MyCollection<String>();

            Console.WriteLine("Collection is empty: {0:B}", testCollection.isEmpty());
            testCollection.Add("test");
            testCollection.Add("test2");
            testCollection.Add("test3");
            Console.WriteLine("Get 3rd element: {0:S}", testCollection.Get(2));
            Console.WriteLine("Get 3rd element: {0:S}", testCollection.Get(2));
            Console.WriteLine("Collection is empty: {0:B}", testCollection.isEmpty());

            Console.ReadLine();

        }
    }
}
