using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Komponents
{
    public partial class StoreData : Component
    {

        public StoreData()
        {
            InitializeComponent();
        }

        public StoreData(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// Разархивирует zip-архив и сохраняет его в заданный файл
        /// </summary>
        /// <param name="pathFile"> путь к файлу, куда извлекать из архива данные</param>
        ///  <param name="pathFold"> путь к папке, куда извлекать из архива данные</param>
        public List<T> Unzip<T>(string pathFold, string pathFile)
        {
            
            if (!typeof(T).IsSerializable)
            {
                MessageBox.Show("Класс не сериализуем");
                return null;
            }
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Zip files (*.zip)|*.zip";
            //fd.ShowDialog();
            string path = "";
            if (fd.ShowDialog() == DialogResult.OK && fd.FileName != "")
            {
                path = fd.InitialDirectory + fd.FileName;
                if (Directory.Exists(pathFold))
                {
                    Directory.Delete(pathFold, true);
                }
                ZipFile.ExtractToDirectory(path, pathFold);
                MessageBox.Show("Данные восстановлены.", "Выполнено");
            }
            return Load<T>(pathFile);
        }
        public List<T> Load<T>(String pathFile)
        {
            string json = "";
            Thread.Sleep(3000);
            using (StreamReader sr = new StreamReader(pathFile))
            {
                json = sr.ReadToEnd();
            }
            var tmp = JsonConvert.DeserializeObject<List<T>>(json);
            var rez = new List<T>();
            foreach (var item in tmp)
            {
                rez.Add(item);
            }
            return rez;
        }
    }
}
