using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papich4
{
    public class TS
    {
        public static Random rnd = new Random();
        public int Wheels = 0;
        public virtual String GetInfo()
        {
            var str = String.Format("\nКоличество колёс: {0}", this.Wheels);
            return str;
        }
    }

    public enum BikeType { Горный, Городской, Детский };
    public class Bike : TS
    {
        public BikeType type = BikeType.Горный; 
        public int Rad = 0;
        public override String GetInfo()
        {
            var str = "Велосипед";
            str += base.GetInfo();
            str += String.Format("\nТип: {0}", this.type); 
            str += String.Format("\nРадиус колёс: {0}", this.Rad);
            return str;
        }
        public static Bike Generate()
        {
            return new Bike
            {
                Wheels = 2 + rnd.Next() % 2,
                type = (BikeType)rnd.Next(3),
                Rad = rnd.Next() % 100
            };
        }
    }

    public enum CarType { Автобус, Грузовик, Внедорожник, Легковая };
    public class Car : TS
    {

        public int Doors = 0;
        public int Engine = 0;
        public CarType type = CarType.Легковая;
        public override String GetInfo()
        {
            var str = "Автомобиль";
            str += base.GetInfo();
            str += String.Format("\nТип: {0}", this.type);
            str += String.Format("\nОбъем двигателя: {0}", this.Engine);
            str += String.Format("\nКоличество дверей: {0}", this.Doors);
            return str;
        }
        public static Car Generate()
        {
            return new Car
            {
                Wheels = 4,
                type = (CarType)rnd.Next(4),
                Engine = 100 + rnd.Next() % 100,
                Doors = 1 + rnd.Next() % 5
            };
        }
    }


    public enum AirType { ПАД, ААД, РАД, ГАД, ТАД, ПВД };
    public class Air : TS
    {
        public AirType Engine = AirType.ПАД; 
        public int Max = 0;
        public override String GetInfo()
        {
            var str = "Самолет ";

            str += base.GetInfo();
            str += String.Format("\nТип двигателя: {0}", this.Engine);
            str += String.Format("\nМаксмальная высота: {0}", this.Max);
            return str;
        }
        public static Air Generate()
        {
            return new Air
            {
                Wheels = 3 + rnd.Next() % 4,
                Engine = (AirType)rnd.Next(6),
                Max = rnd.Next() % 100 * 1000
            };
        }
    }
}
