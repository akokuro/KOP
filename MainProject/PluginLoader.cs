using Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    class PluginLoader
    {
        public List<IPlugin> Plugins = new List<IPlugin>();

        public void LoadPlugins(string dir, DbConnection db, Form1 form)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files)
            {
                IsPlugin(file, db, form);
            }
        }

        private IPlugin IsPlugin(string file_url, DbConnection db, Form1 form)
        {

            byte[] b = System.IO.File.ReadAllBytes(file_url);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(b);
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterface("IPlugin") != null)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type, db, form);
                    if (plugin != null)
                        Plugins.Add(plugin);
                }
            }
            return null;
        }
    }
}
