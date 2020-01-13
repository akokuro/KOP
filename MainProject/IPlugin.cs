using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public interface IPlugin
    {
        String Operation { get; }
        void RunPlugin();
    }
}
