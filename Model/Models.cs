using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Provider
    {
        public int id;
        public string name;
        public string phoneNumber;
        public int managerId;
        public override string ToString()
        {
            return "" + id + " " + name + " " + phoneNumber;
        }
    }
    public class Manager
    {
        public int id;
        public string name;
        public override string ToString()
        {
            return "" + id + " " + name;
        }
    }
}
