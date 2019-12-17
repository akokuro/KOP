using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konponens
{
    public partial class WordReport : Component
    {
        /// <summary>
        /// Количество столбцов в таблице
        /// </summary>
        public int columnCount;

        /// <summary>
        /// Количество строк в таблице
        /// </summary>
        public int rowCount;

        /// <summary>
        /// Данные таблицы
        /// </summary>
        private List<List<String>> data;

        public WordReport()
        {
            InitializeComponent();
        }

        public WordReport(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /// <summary>
        /// Устанавливает содержимое таблицы
        /// </summary>
        /// <param name="contentsColumns"> список столбцов со списком строк внутри</param>
        public void SetData(List<List<String>> contentsColumns)
        {
            this.data = contentsColumns;
        }

        /// <summary>
        /// Метод, генерирующий отчет
        /// </summary>
        /// <param name="columnNames"> первая строка таблицы - название колонок(может быть null)</param>
        /// <param name="fileName"> имя файла, в который будет сохраняться отчет</param>
        /// <param name="rowNames"> первая колонка таблицы - название строк(может быть null)</param>
        public void CreateTable(String[] columnNames, String[] rowNames, String fileName)
        {
            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;
                //создаем документ
                Microsoft.Office.Interop.Word.Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref
               missing);
                //получаем ссылку на параграф
                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;
                //задаем настройки шрифта
                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;
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
                var table = document.Tables.Add(rangeTable, rowCount + (columnNames != null? 1: 0), columnCount + (rowNames != null ? 1 : 0), ref missing, ref missing);
                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";
                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;
                int columnOffset = 0;
                int rowOffset = 0;
                if (columnNames != null)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        table.Cell(1 , i + 1 + (rowNames != null ? 1 : 0)).Range.Text = columnNames[i];
                    }
                    rowOffset = 1;
                }
                if (rowNames != null)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        table.Cell(i + 1 + (columnNames != null ? 1 : 0), 1 ).Range.Text = rowNames[i];
                    }
                    columnOffset = 1;
                }
                for (int i = 0 ; i < rowCount; ++i)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        table.Cell(i + rowOffset + 1, j + columnOffset + 1).Range.Text = data[j][i];
                    }
                }
                //задаем границы таблицы
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                //paragraph = document.Paragraphs.Add(missing);
                //range = paragraph.Range;
                //range.Text = "Дата: " + DateTime.Now.ToLongDateString();
                //font = range.Font;
                //font.Size = 12;
                //font.Name = "Times New Roman";
                //paragraphFormat = range.ParagraphFormat;
                //paragraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                //paragraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle;
                //paragraphFormat.SpaceAfter = 10;
                //paragraphFormat.SpaceBefore = 10;
                //range.InsertParagraphAfter();
                //сохраняем
                object fileFormat = WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(fileName, ref fileFormat, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }
    }
}
