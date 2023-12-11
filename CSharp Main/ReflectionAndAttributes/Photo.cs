using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReflectionAndAttributes
{
    [PhotoLifespan(LifeSpan = 20)]
    internal class Photo
    {
        public string Path { get; set; }

        [Geo(10, 20)]
        public string Title { get; set; }
        public string Name { get; set; }
        public int LifeSpan { get; set; }
        public void Print()
        {
            string somestring = "Test";
            Console.WriteLine($"{Name}, {Path}");
        }
        public void Print(string someString)
        {
            string somestring = someString;
            Console.WriteLine($"{Name}, {Path}");
        }
        public Photo(string Name)
        {
            this.Name = Name;
        }
    }
    public class PhotoLifespanAttribute : Attribute
    {
        public int LifeSpan { get; set; }
        public PhotoLifespanAttribute()
        {
            
        }
        public PhotoLifespanAttribute(int Lifespane)
        {
            this.LifeSpan = LifeSpan;
        }
    }
    public class GeoAttribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GeoAttribute() { }
        public GeoAttribute(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }
    }
}
