using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Plugin;

namespace AddManagerPlugin
{
    public class AddManager : IPlugin
    {
        public string Name { get; } = "AddManagerPlugin";

        public string Version { get; } = "0.0.0.1";

        public void Apply(Provider provider)
        {
            Console.WriteLine("I am ALIVE");
        }
    }
}
