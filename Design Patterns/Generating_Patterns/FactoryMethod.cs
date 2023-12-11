using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_Patterns
{
    abstract class ConstructionFirm
    {
        public string CompanyName { get; set; }

        public ConstructionFirm(string name)
        {
            CompanyName = name;
        }
        //Фабричный метод
        abstract public Building Construct();
    }

    class PanelConstructionFirm : ConstructionFirm
    {
        public PanelConstructionFirm(string name) : base(name)
        { }

        public override Building Construct()
        {
            return new PanelBuilding();
        }
    }

    class WoodConstructionFirm : ConstructionFirm
    {
        public WoodConstructionFirm(string name) : base(name)
        { }

        public override Building Construct()
        {
            return new WoodBuilding();
        }
    }

    abstract class Building
    { }

    class PanelBuilding : Building
    {
        public PanelBuilding()
        {
            Console.WriteLine("Panel building constructed");
        }
    }

    class WoodBuilding : Building
    {
        public WoodBuilding()
        {
            Console.WriteLine("Wooden building constructed");
        }
    }

}
