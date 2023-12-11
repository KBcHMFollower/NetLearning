using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public enum Color
    {
        Black,
        White, 
        Green, 
        Blue,
        Yellow,
        Red,
        Grey
    }
    public class Auto
    {
        public string Mark { get; set; }
        public Color color;
        private int year;
        public int Year
        {
            get
            {
                if (year != default(int))
                {
                    return year;
                }
                else throw new InvalidOperationException();
            }
            set
            {
                if(value > 1900 && value < DateTime.Now.Year)
                {
                    year = value;
                }
                else throw new InvalidOperationException();
            } 
        }

    }
    class CarOwner
    {
        public int Id { get; set; }
        public Auto[] auto;
        public string Name { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
    class Nationality
    {
        public int Id { get; set; }
        public string Contry { get; set; }
    }
}
