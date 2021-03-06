﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace MainProject
{
    public partial class Form1 : Form
    {
        public string ProviderPhone { get { return this.ProviderPhoneField.Text; } }
        public Provider selectedProvider = new Provider { id = -1 };
        public Komponents.FIOManager FIOManager { get { return this.ProviderfioManager; } }

        public List<Provider> providers;
        public List<Manager> managers;
        PluginLoader Plugins = new PluginLoader();
        DbConnection db = new DbConnection();

        public Form1()
        {
            Plugins.LoadPlugins("plugins", db, this);
            InitializeComponent();
            Plugins.Plugins.ForEach((x) => PluginListViev.Items.Add(x.Operation, x.Operation, x.Operation));
            managers = db.getManagerList();
            ProviderfioManager.LoadListFIO(managers.ToList<object>());
            
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });

            vivodTableComponent1.CellClick += (a, b) =>
            {
                int id = int.Parse((string)vivodTableComponent1.Selected[0].Value);
                selectedProvider = providers.Find((x) => x.id == id);
                updateProviderInfo();
            };
        }

        void updateProviderInfo()
        {
            ProviderNameField.Text = selectedProvider.name;
            ProviderPhoneField.Text = selectedProvider.phoneNumber;
            ProviderfioManager.SelectedIndexFIO = managers.FindIndex((x) => x.id == selectedProvider.managerId);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            selectedProvider.name = ProviderNameField.Text;
            selectedProvider.phoneNumber = ProviderPhoneField.Text;
            selectedProvider.managerId = managers[ProviderfioManager.SelectedIndexFIO].id;
            db.AddProvider(selectedProvider);
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            selectedProvider.name = ProviderNameField.Text;
            selectedProvider.phoneNumber = ProviderPhoneField.Text;
            selectedProvider.managerId = managers[ProviderfioManager.SelectedIndexFIO].id;
            db.UpdProvider(selectedProvider);
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            db.DelProvider(selectedProvider);
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });
        }

        private void LoadBackupButton_Click(object sender, EventArgs e)
        {
            var back = storeData1.Unzip<Provider>("temp", "temp/backup.json");
            foreach (var item in back)
            {
                if (providers.Find((x) => x.id == item.id) != null)
                {
                    db.UpdProvider(item);
                }
                else
                {
                    db.AddProvider(item);
                }
            }
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });
        }

        private void ReportManagerButton_Click(object sender, EventArgs e)
        {
            diagrammaExcelComponent1.CreateDiagram(
                "temp", 
                managers.Select(
                    (x) => new {
                        Name = x.name,
                        Count = providers.Aggregate(0, 
                            (a, b) => a + (b.managerId == x.id ? 1 : 0))
                    }).ToList<object>(), 
                new List<string> { "Name", "Count" }, 
                new List<string> {"Отчет", "Имя", "Количество поставщиков" });
        }

        private void ReportProviderButton_Click(object sender, EventArgs e)
        {
            MyExcelReport1.CreateExcelReport("temp", providers, new List<string> { "name", "phoneNumber" }, new List<string> { "Имя", "Номер телефона" });
        }

        private void PluginStartButton_Click(object sender, EventArgs e)
        {
            foreach (IPlugin p in Plugins.Plugins)
            {
                if (PluginListViev.SelectedItems.ContainsKey(p.Operation))
                {
                    p.RunPlugin();
                }
            }
            providers = db.getProviderList();
            vivodTableComponent1.LoadEnumerationName(providers.ToList<object>(), new List<string> { "Номер", "Имя", "Телефон" }, new List<string> { "id", "name", "phoneNumber" });
        }
    }
}
