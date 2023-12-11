using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generating_Patterns
{
    class Device
    {
        public Platform Platform { get; set; }

        public void Initialize(string platformName)
        {
            Platform = Platform.GetInstance(platformName);
        }
    }

    class Platform
    {
        private static Platform instance;

        public string Name { get; private set; }

        protected Platform(string name)
        {
            this.Name = name;
        }

        public static Platform GetInstance(string name)
        {
            if (instance == null)
                instance = new Platform(name);
            return instance;
        }
    }
}
