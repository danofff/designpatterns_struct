using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        public interface Car
        {
            string Info();
        }

        public class Sedan : Car
        {
            public string Info()
            {
                return "Sedan";
            }
        }


        public class CarDecarator : Car
        {
            Car Car;
            public CarDecarator(Car car)
            {
                Car = car;
            }
            public virtual string Info()
            {
                return Car.Info();
            }
        }


        public class SportSedan : CarDecarator
        {
            public SportSedan(Car car) : base(car)
            {
            }
            private string showSpeed()
            {
                return ", his speed is  so high";
            }

            public override string Info()
            {
                return base.Info() + showSpeed();
            }
        }


        public class ArmoredSedan : CarDecarator
        {
            public ArmoredSedan (Car car) : base(car)
            {
            }
            private string showArmour()
            {
                return ", his armour is so fat";
            }

            public override string Info()
            {
                return base.Info()+showArmour();
            }
        }
        static void Main(string[] args)
        {

            Car car = new Sedan();
            Console.WriteLine(car.Info());

            Car sport = new SportSedan(new Sedan());
            Console.WriteLine(sport.Info());


            Car armoured = new ArmoredSedan(new SportSedan(new Sedan()));

            Console.WriteLine(armoured.Info());
            Console.ReadKey();
        }
    }
}
