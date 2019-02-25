using System;
using System.Collections.Generic;
using System.Reflection;

namespace InternshipAssignment
{
    public class Vessel
    {
        private string name;
        private string yearBuilt;
        public Speed Speed { get; protected set; }
        
        public Vessel(string Name, string Year, double Speed)
        {
            this.Name = Name;
            this.YearBuilt = Year;
            this.Speed = new Speed(Speed);

            // DateTime.Now.Year;
            if (Convert.ToInt32(Year) < DateTime.Now.Year - 20)
            {
                throw new OldShipException();
            }
        }

        //separates vessel types using their various properties
        public string GetVesselInfo()
        {
            Type myType = this.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(this, null);
                if (prop.Name == "passengers")
                {
                    return "Ferry" + " " + this.Name + " " + this.YearBuilt + " " + propValue;
                }
                else if (prop.Name == "max_force")
                {
                    return "Tugboat" + " " + this.Name + " " + this.YearBuilt + " " + propValue;
                }
                else if (prop.Name == "max_depth")
                {
                    return "Submarine" + " " + this.Name + " " + this.YearBuilt + " " + propValue;
                }
            }
            return "";
        }
        public string Name { get; }
        public string YearBuilt { get; }

        public override string ToString()
        {
            return $"Vessel: {name}";
        }

    }

    //gets the speed of each vessel type in knots
    public class Speed : IFormattable
    {
        public double max_speed { get; }

        public Speed(double knots) { this.max_speed = knots; }

        public Speed()
        {
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format.ToLower()== "ms")
            {

                //takes the max_speed, divides it by 1.944 which converts it to the max speed in ms and then saves it in the variable max_speed_ms
                var max_speed_ms = max_speed / 1.944;
                return max_speed_ms.ToString();
            }
            return max_speed.ToString();

        }
    }

    //ferry class inheriting from the parent vessel class with its own property of "passengers"
    public class Ferry : Vessel
    {
        public string passengers { get; }
        public Ferry(string Name, string Year, double Speed, string passengers) : base(Name, Year, Speed)  //constructor
        {
            this.passengers = passengers;
        }
    }

    //tugboat class inheriting from the parent vessel class with its own property of "max_force"
    public class Tugboat : Vessel
    {
        public string max_force { get; }
        public Tugboat(string Name, string Year, double Speed, string max_force) : base(Name, Year, Speed)
        {
            this.max_force = max_force;
        }

    }

    //submarine class inheriting from the parent vessel class with its own property of "max_depth"
    public class Submarine : Vessel
    {
        public string max_depth { get; }
        public Submarine(string Name, string Year, double Speed, string max_depth) : base(Name, Year, Speed)
        {
            this.max_depth = max_depth;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //prints a few vessels, their types, names and properties
            var ship = new Vessel("The mermaid", "2005", 50);
            Vessel f = new Ferry("Fer", "2001", 25.5, "4"); 
            Vessel t = new Tugboat("Tug", "2013", 65.0, "20");
            Vessel s = new Submarine("Sub", "1999", 100.2, "50");

            Console.WriteLine(f.GetVesselInfo());
            Console.WriteLine(t.GetVesselInfo());
            Console.WriteLine(s.GetVesselInfo());

            //prints out the speeds of some vessels in kn and ms
            Console.WriteLine(f.Speed.ToString("KN", null));
            Console.WriteLine(f.Speed.ToString("ms", null));
            Console.WriteLine(t.Speed.ToString("KN", null));
            Console.WriteLine(t.Speed.ToString("ms", null));
            Console.WriteLine(s.Speed.ToString("KN", null));
            Console.WriteLine(s.Speed.ToString("ms", null));

            Console.ReadLine();
        }
    }

}
