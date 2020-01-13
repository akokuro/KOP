using MainProject;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddManagerPlugin
{
    public class List : IPlugin
    {
        Form1 Form;
        private DbConnection db;
        public string Operation => "Смена с тел\nефон\nом";

        public List(DbConnection db, Form1 Form)
        {
            this.Form = Form;
            this.db = db;
        }

        public void RunPlugin()
        {
            int id = Form.selectedProvider.id;
            Provider temp = db.getProviderList().FirstOrDefault(rec => rec.id == id);
            if (temp == null)
            {
                throw new Exception("Провайдер не найден");
            }
            temp.phoneNumber = Form.ProviderPhone;
            db.UpdProvider(temp);
        }
    }
}
