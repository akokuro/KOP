using System;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Konponens
{
    public partial class DateView : UserControl
    {
        /// <summary>
        /// Событие выбора элемента из списка
        /// </summary>
        public event EventHandler _listBoxElementChangeFIO;

        public DateTime? Date
        {
            get { return getValue(); }
            set { }
        }
        public DateView()
        {
            InitializeComponent();
            TextBoxWatermarkExtensionMethod.SetWatermark(textBox, "Напишите дату в формате dd-MM-yyyy");

        }
        /// <summary>
        /// Является ли строка, введенная пользователем, датой
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool TextIsDate(string text)
        {
            var dateFormat = "dd-MM-yyyy";
            DateTime scheduleDate;
            if (DateTime.TryParseExact(text, dateFormat, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out scheduleDate))
            {
                return true;
            }
            return false;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                textBox.Text = "";
                textBox.ReadOnly = true;
            }
            else
            {
                textBox.ReadOnly = false;
            }
        }
        /// <summary>
        /// Получение значения, введенного пользователем
        /// </summary>
        /// <returns></returns>
        public DateTime? getValue()
        {
            if (TextIsDate(textBox.Text))
            {
                return DateTime.Parse(textBox.Text);
            }
            else if (checkBox.Checked)
            {
                return null;
            }
            else
            {
                throw new Exception("Некорректный ввод данных");
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            if (textBox.TextLength >= 10 && !TextIsDate(textBox.Text))
            {
                toolTip.Show("Введена не дата или формат не соблюден. Формат даты: dd-MM-yyyy", textBox);
            }
        }
    }
    public static class TextBoxWatermarkExtensionMethod
    {
        private const uint ECM_FIRST = 0x1500;
        private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetWatermark(this TextBox textBox, string watermarkText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }

    }
}
