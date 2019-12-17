using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureProvider.Model
{
    /// <summary>     
    /// Поставщик мебели   
    /// </summary> 
    class Provider
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FIOManager { get; set; }

        public string Number { get; set; }
    }
}
