using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Komponents
{
    public partial class ListView : UserControl
    {
        /// <summary>
        /// Порядковый номер выбранного элемента
        /// </summary>
        private int _selectedIndexFIO;
        private List<String> displayData;

        /// <summary>
        /// Сохраняет поля сериализуемых объектов, которые нужно отобразить
        /// </summary>
        public void SetData(string[] fields, Object[] objects)
        {
            var res = new List<string>();
            res.Add(fields.Aggregate("", (acc, x) => acc + x + " "));
            foreach (var item in objects)
            {
                Type t = item.GetType();
                var currFields = new List<String>();
                foreach (var _field in t.GetFields())
                {
                    currFields.Add(_field.Name);
                }
                var _res = "";
                foreach (var field in fields)
                {
                    var fieldInfo = t.GetField(field);
                    if (fieldInfo != null)
                    {
                        _res += " " + fieldInfo.GetValue(item).ToString();
                    }
                    else
                    {
                        _res += " ошибка объекта";
                    }
                }
                res.Add(_res);
            }
            displayData = res;
            LoadEnumeration(displayData);
        }

        /// <summary>
        /// Порядковый номер выбранного элемента
        /// </summary>
        [Category("Спецификация"), Description("Порядковый номер выбранного элемента")]
        public int SelectedIndex
        {
            get { return _selectedIndexFIO; }
            set
            {
                if (value > -2 && value < listBox.Items.Count)
                {
                    _selectedIndexFIO = value;
                    listBox.SelectedIndex = _selectedIndexFIO;
                }
            }
        }

        /// <summary>
        /// Текст выбранной записи
        /// </summary>
        [Category("Спецификация"), Description("Текст выбранной записи")]
        public string SelectedText
        {
            get { return listBox.SelectedItem.ToString(); }
        }

        public ListView()
        {
            InitializeComponent();
            //     listBox.Items.Add(fields.ToString());
        }

        /// <summary>
        /// Добавление элемента в список
        /// </summary>
        /// <param name="type">тип-справочник</param>
        public void AddLine(String str)
        {
            listBox.Items.Insert(listBox.Items.Count - 1, str);
        }

        /// <summary>
        /// Заполнение списка ФИО менеджеров значениями из справочника
        /// </summary>
        /// <param name="type">тип-справочник</param>
        public void LoadEnumeration(List<string> list)
        {
            foreach (var elem in list)
            {
                listBox.Items.Add(elem.ToString());
            }
        }
    }
}
