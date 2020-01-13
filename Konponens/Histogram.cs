using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Rectangle = System.Drawing.Rectangle;
using System.Drawing.Imaging;

namespace Konponens
{
    public partial class Histogram : Component
    {
        String Abs;
        String Ord;

        public Histogram()
        {
            InitializeComponent();
        }

        public Histogram(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void draw_text(Graphics gr, string text, System.Drawing.Font font, Brush brush, StringFormat format, int x, int y, int a)
        {
            GraphicsState gs = gr.Save();
            Matrix mat = new Matrix();
            mat.RotateAt(a, new PointF(x, y), MatrixOrder.Prepend);
            gr.Transform = mat;
            gr.DrawString(text, font, brush, x, y);
            gr.Restore(gs);
        }

        private List<KeyValuePair<string, int>> rescale(List<KeyValuePair<string, int>> data)
        {
            int max = data.Max(t => t.Value);
            return data.Select(t => new KeyValuePair<string, int>(t.Key, t.Value * 100 / max)).ToList();
        }
        public void SetTitle(String Abs, String Ord)
        {
            this.Abs = Abs;
            this.Ord = Ord;
        }

        private Bitmap drawHistogram(Dictionary<String, int> data)
        {
            var companies = rescale(data.ToList());
            int max_val = data.Max(t => t.Value);
            Bitmap bm = new Bitmap(800, 500);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                using (Pen thick_pen = new Pen(Color.Black, 2))
                {
                    gr.DrawLine(thick_pen, 190, 400, 800, 400);
                    gr.DrawLine(thick_pen, 188, 100, 192, 100);
                    gr.DrawLine(thick_pen, 190, 400, 190, 0);
                }
                using (Pen thick_pen = new Pen(Color.Blue, 18))
                {
                    gr.DrawString(Abs, new System.Drawing.Font("Calibri", 12), Brushes.Blue, new Point(300, 460));
                    gr.DrawString(Ord, new System.Drawing.Font("Calibri", 12), Brushes.Blue, new PointF(30, 250));

                    for (int i = 0; i < data.Count; i++)
                    {
                        gr.DrawString(companies[i].Value.ToString(), new System.Drawing.Font("Calibri", 8), Brushes.Black, new Point(i * 20 + 190, 390 - companies[i].Value * 3));
                        gr.DrawLine(thick_pen, i * 20 + 200, 400, i * 20 + 200, 400 - companies[i].Value * 3);
                        draw_text(gr, companies[i].Key, new System.Drawing.Font("Calibri", 10), Brushes.Black, new StringFormat(), i * 20 + 200, 410, 40);
                    }
                }
            }
            return bm;
        }

        public void createPDF(string fileName, string title, Dictionary<String, int> data)
        {        //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("TIMCYR.TTF"))
            {
                File.WriteAllBytes("TIMCYR.TTF", Properties.Resources.TIMCYR);
            }
            //открываем файл для работы
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate,
           FileAccess.Write);
            //создаем документ, задаем границы, связываем документ и поток
            Document doc = new Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("TIMCYR.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //вставляем заголовок
            var phraseTitle = new Phrase(title,
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new
            iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };

            doc.Add(paragraph);
            System.Drawing.Image image = drawHistogram(data);
            var hist = iTextSharp.text.Image.GetInstance(image, new BaseColor(255, 255, 255));
            doc.Add(hist);
            doc.Add(paragraph);
            doc.Close();
        }
    }
}
