using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace KOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fioManager.LoadEnumerationFIO(typeof(TestEnum));
            TestManager t = new TestManager();
            t.FIO = "Иван Иванович Иванов";
            t.Predpriyatie = "Уаз";
            t.Bithday = "11.09.1999";
            TestManager te = new TestManager();
            te.FIO = "Акакий Акакьевич Акакиев";
            te.Predpriyatie = "Контактор";
            te.Bithday = "30.01.98";
            String[] fields = new String[2];
            fields[0] = "FIO";
            fields[1] = "Predpriyatie";
            TestManager[] test = new TestManager[2];
            test[0] = t;
            test[1] = te;
            listView.SetData(fields, test);
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            storeData1.Unzip<Test>("C://test", "C://test//test.json");
        }

        private void buttonDate_Click(object sender, EventArgs e)
        {
            Console.WriteLine(dateView1.getValue());
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            List<List<String>> contents = new List<List<String>>();
            contents.Add(new List<String>());
            contents[0].Add("Январь");
            contents[0].Add("Февраль");
            contents.Add(new List<String>());
            contents[1].Add("31");
            contents[1].Add("28");
            wordReport.SetData(contents);
            int rowCount = 0;
            for (int i = 0; i < contents.Count; i++)
            {
                if (contents[i].Count > rowCount)
                {
                    rowCount = contents[i].Count;
                }
            }
            wordReport.columnCount = contents.Count;
            wordReport.rowCount = rowCount;
            string[] rowName = { "Месяц", "Количество дней" };
            wordReport.CreateTable(rowName, null, "test");
        }

        private void buttonHist_Click(object sender, EventArgs e)
        {
            Dictionary<String, int> data = new Dictionary<string, int>();
            data.Add("УАЗ", 55);
            data.Add("Контактор", 110);
            data.Add("Авиастар", 75);
            histogram.createPDF("testPDF.pdf", "Попытка 1", data);
        }
    }

    [Serializable]
    internal class Test
    {
        public enum TypeOrg
        {
            ООО,
            ОАО,
            ИП,
            АО,
            НПО
        }

        public enum NameOrg
        {
            УАЗ,
            МАРС,
            Авиастар
        }

        public string _nameOrg { get; set; }

        public string _typeOrg { get; set; }

        public Test(string nameOrg, string typeOrg)
        {
            _nameOrg = nameOrg;
            _typeOrg = typeOrg;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this._nameOrg.ToString() + " " + this._typeOrg.ToString();
        }
    }
}
