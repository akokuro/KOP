﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject;
using Model;
using Plugin;

namespace AddManagerPlugin
{
    public class AddManager : IPlugin
    {
        Form1 Form;
        private DbConnection db;
        private List<Provider> providers;
        private List<Manager> managers;
        public AddManager(DbConnection db, Form1 Form)
        {
            this.Form = Form;
            this.db = db;
            managers = db.getManagerList();
            providers = db.getProviderList();
        }
        public string Operation => "Назначение нового менеджера поставщику";

        public void RunPlugin()
        {
            int id = Form.selectedProvider.id;
            int idManager = Form.managers[Form.FIOManager.SelectedIndexFIO].id;
            Provider temp = db.getProviderList().FirstOrDefault(rec => rec.id == id);
            if (temp == null)
            {
                throw new Exception("Провайдер не найден");
            }
            temp.managerId = idManager;
            db.UpdProvider(temp);
        }
    }
}
