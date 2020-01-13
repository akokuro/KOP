using MainProject;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Threading.Tasks;

using XL = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace GetProviderCardPlugin
{
    public class ProviderCard : IPlugin
    {
        Form1 Form;
        private DbConnection db;
        public string Operation => "Карточка поставщика";

        public ProviderCard(DbConnection db, Form1 form)
        {
            this.Form = form;
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
            CreateTable(new String[] {"N", "Название", "Телефон", "ID-менеджера"}, new String[] {temp.id.ToString(), temp.name, temp.phoneNumber, temp.managerId.ToString()}, "C://Users//Kurai//source//repos//KOP//MainProject//bin//Debug//temp//testPlugin.doc");
        }
        public void CreateTable(String[] columnNames, String[] rowNames, String fileName)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
                range.Text = "Карточка поставщика " + rowNames[1];
                var paragraph1 = document.Paragraphs.Add(missing);
                var range1 = paragraph1.Range;
                //задаем настройки шрифта
                var font1 = range1.Font;
                font1.Size = 16;
                font1.Name = "Times New Roman";
                font1.Bold = 1;
                //задаем настройки абзаца
                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;
                //добавляем абзац в документ
                range.InsertParagraphAfter();
                //создаем таблицу
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, 2, columnNames.Length, ref missing, ref missing);
                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";
                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                if (columnNames != null)
                {
                    for (int i = 0; i < columnNames.Length; i++)
                    {
                        table.Cell(1, i + (rowNames != null ? 1 : 0)).Range.Text = columnNames[i];
                    }
                }
                if (rowNames != null)
                {
                    for (int i = 0; i < rowNames.Length; i++)
                    {
                        table.Cell(2, i + (rowNames != null ? 1 : 0)).Range.Text = rowNames[i];
                    }
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(fileName, ref fileFormat, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing);
                document.Close(ref missing, ref missing, ref missing);
                MessageBox.Show("Сохранение карточки поставщика прошло успешно!", "Отлично", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
            finally
            {
                winword.Quit();
            }
        }
    }
}
