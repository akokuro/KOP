using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komponents
{
    public partial class FIOManager : UserControl
    {

        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        private event EventHandler _listBoxSelectedElementChangeFIO;

        /// <summary>
        /// Порядковый номер выбранного Менеджера
        /// </summary>
        [Category("Спецификация"), Description("Порядковый номер выбранного элемента ФИО Менеджера")]
        public int SelectedIndexFIO
        {
            get { return listBoxFIO.SelectedIndex; }
            set { listBoxFIO.SelectedIndex = value; }
        }

        /// <summary>
        /// Текст выбранной записи
        /// </summary>
        [Category("Спецификация"), Description("Текст выбранной записи ФИО менеджера")]
        public string SelectedTextFIO
        {
            get { return listBoxFIO.SelectedItem.ToString(); }
        }
        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        [Category("Спецификация"), Description("Событие выбора элемента из списка ФИО менеджера")]
        public event EventHandler ComboBoxSelectedElementChangeFIO
        {
            add { _listBoxSelectedElementChangeFIO += value; }
            remove { _listBoxSelectedElementChangeFIO -= value; }
        }
        public FIOManager()
        {
            InitializeComponent();
            listBoxFIO.SelectedIndexChanged += (send, ev) => { _listBoxSelectedElementChangeFIO?.Invoke(send, ev); };
        }
        /// <summary>
        /// Заполнение списка ФИО менеджеров значениями из справочника
        /// </summary>
        /// <param name="type">тип-справочник</param>
        public void LoadEnumerationFIO(Type type)
        {
            foreach (var elem in Enum.GetValues(type))
            {
                listBoxFIO.Items.Add(elem.ToString());
            }
            listBoxFIO.SelectedIndex = 0;
        }

        /// <summary>
        /// Заполнение списка ФИО менеджеров значениями из списка
        /// </summary>
        public void LoadListFIO(List<object> list)
        {
            foreach (var elem in list)
            {
                listBoxFIO.Items.Add(elem.ToString());
            }
        }
    }
}
