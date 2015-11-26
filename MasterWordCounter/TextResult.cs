using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace MasterWordCounter
{
    public partial class TextResult : Form
    {
        string naziv;
        MySortableBindingList<Rijec> lista_rijeci;
        public TextResult(MySortableBindingList<Rijec> lr, string n)
        {
            naziv = n;
            lista_rijeci = lr;
            InitializeComponent();
        }

        private void TextResult_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lista_rijeci;
            chart1.Series["Rijec"].Points.Clear();
            MessageBox.Show(Convert.ToString(dataGridView1.RowCount));
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            for (int i =0;i<lista_rijeci.Count;i++)
            chart1.Series["Rijec"].Points.AddXY(lista_rijeci[i].Ponavljanje, i);
            label1.Text = "Ukupno riječi: " + lista_rijeci.Count;
        }
        void GridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value
             = (e.RowIndex + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           chart1.Series["Rijec"].Points.Clear();
            for (int i = 0; i < lista_rijeci.Count; i++)
                chart1.Series["Rijec"].Points.AddXY(i+1,lista_rijeci[i].Ponavljanje);
            chart1.ChartAreas[0].AxisX.Maximum = 80;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            label1.Text = "Ukupno riječi: " + lista_rijeci.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER,10,10,42,42);
            PdfWriter pdw = PdfWriter.GetInstance(doc, new FileStream(naziv + ".pdf", FileMode.Create));
            doc.Open();
            Paragraph p = new Paragraph("Word Count for : "+naziv,times);
            doc.Add(p);
            p.Alignment = 1;
            PdfPTable pdt = new PdfPTable(2);
            pdt.HorizontalAlignment = 1;
            pdt.SpacingBefore = 20f;
            pdt.SpacingAfter = 20f;
            pdt.AddCell("Word");
            pdt.AddCell("No of repetitions");
            foreach (Rijec r in lista_rijeci)
            {
                pdt.AddCell(r.Tekst);
                pdt.AddCell(Convert.ToString(r.Ponavljanje));
            }
            using (MemoryStream stream = new MemoryStream())
            {
                chart1.SaveImage(stream, ChartImageFormat.Png);
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                chartImage.ScalePercent(75f);
                chartImage.Alignment = 1;
                doc.Add(chartImage);
            }
            doc.Add(pdt);
            doc.Close();
            MessageBox.Show("PDF created!");
        }
    }
}
