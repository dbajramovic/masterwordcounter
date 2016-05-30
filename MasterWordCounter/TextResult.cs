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
using System.Data.Odbc;

namespace MasterWordCounter
{
    public partial class TextResult : Form
    {
        string naziv;
        MySortableBindingList<Rijec> lista_rijeci;
        MySortableBindingList<Rijec> lista_rijeci_poslije_gramatike;
        MySortableBindingList<Rijec> lista_rijeci_gramatika;
        bool Gramatika;
        Tekst tekst;
        public TextResult(MySortableBindingList<Rijec> lr, string n, Tekst t)
        {
            naziv = n;
            lista_rijeci = lr;
            lista_rijeci_gramatika = new MySortableBindingList<Rijec>();
            lista_rijeci_poslije_gramatike = new MySortableBindingList<Rijec>();
            Gramatika = false;
            tekst = t;
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
            dataGridView1.Columns["Korijen"].Visible = false;
            dataGridView1.Columns["Irregular"].Visible = false;
            dataGridView1.Columns["Tip"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;
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
            button5.Enabled = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            
            InsertWords iw = new InsertWords(lista_rijeci);
            iw.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Gramatika = true;
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "SELECT DISTINCT word, COALESCE(root,0), type, irregular,id FROM words ORDER BY word";
                OdbcCommand getAllWords = new OdbcCommand(q, connection);
                OdbcDataReader odr2 = getAllWords.ExecuteReader();
                lista_rijeci_gramatika.Clear();
                while (odr2.Read())
                {
                    Rijec t = new Rijec();
                    t.Tekst = odr2.GetString(0);
                    t.Korijen = odr2.GetString(1);
                    t.Tip = odr2.GetInt32(2);
                    t.Irregular = odr2.GetBoolean(3);
                    t.Id = odr2.GetInt32(4);
                    lista_rijeci_gramatika.Add(t);
                }
                odr2.Close();
                connection.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            lista_rijeci_poslije_gramatike.Clear();
            foreach (Rijec r in lista_rijeci)
            {
                foreach (Rijec r1 in lista_rijeci_gramatika)
                {
                    if (r.Tekst == r1.Tekst)
                    {
                        if(!r1.Korijen.Equals("0"))
                        {
                            foreach(Rijec r3 in lista_rijeci_gramatika)
                            {
                                if (r3.Id.ToString().Equals(r1.Korijen))
                                {
                                    foreach(Rijec r4 in lista_rijeci)
                                    {
                                        if(r4.Tekst == r3.Tekst)
                                        {
                                            r4.Ponavljanje += r.Ponavljanje;
                                            r.Irregular = true;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            foreach(Rijec r in lista_rijeci)
            {
                if(r.Irregular == false)
                {
                    lista_rijeci_poslije_gramatike.Add(r);
                }
            }
            dataGridView1.DataSource = lista_rijeci_poslije_gramatike;
            chart1.Series["Rijec"].Points.Clear();
            MessageBox.Show(Convert.ToString(dataGridView1.RowCount));
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            for (int i = 0; i < lista_rijeci_poslije_gramatike.Count; i++)
                chart1.Series["Rijec"].Points.AddXY(lista_rijeci[i].Ponavljanje, i);
            label1.Text = "Ukupno riječi: " + lista_rijeci_poslije_gramatike.Count;
            chart1.Series["Rijec"].Points.Clear();
            for (int i = 0; i < lista_rijeci_poslije_gramatike.Count; i++)
                chart1.Series["Rijec"].Points.AddXY(i + 1, lista_rijeci_poslije_gramatike[i].Ponavljanje);
            chart1.ChartAreas[0].AxisX.Maximum = 80;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value);
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            label1.Text = "Ukupno riječi: " + lista_rijeci_poslije_gramatike.Count;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Statistika s = new Statistika();
            int tip = 0;
            if (Gramatika) tip = 2;
            else tip = 1;
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
            connection.Open();
            int Rank = 0;
            int ukupno_rijeci = 0;
            foreach(Rijec r in lista_rijeci)
            {
                ukupno_rijeci += r.Ponavljanje;
            }
            if (!Gramatika)
            {
                foreach (Rijec r in lista_rijeci)
                {
                    Rank++;
                    s.Rijec_id = r.Id;
                    s.Tekst_id = tekst.Id;
                    s.Broj_ponavljanja = r.Ponavljanje;
                    s.Tip_statistike = tip;
                    s.Rank_unutar_teksta = Rank;
                    s.Procenat_pojave_unutar_teksta = Decimal.Round((Decimal)r.Ponavljanje / ukupno_rijeci, 3);
                    string q = "INSERT INTO stats (word_id,word_text,text_id,type_of_stats,num_of_repeats,rank_in_text,pct_of_occurence) VALUES (?,?,?,?,?,?,?);";
                    OdbcCommand insertStat = new OdbcCommand(q, connection);
                    insertStat.Parameters.Add("@word_id", OdbcType.Numeric).Value = 5445;
                    insertStat.Parameters.Add("@word_text", OdbcType.Char).Value = r.Tekst;
                    insertStat.Parameters.Add("@text_id", OdbcType.Numeric).Value = s.Tekst_id;
                    insertStat.Parameters.Add("@type_of_stats", OdbcType.Numeric).Value = s.Tip_statistike;
                    insertStat.Parameters.Add("@num_of_repeats", OdbcType.Numeric).Value = s.Broj_ponavljanja;
                    insertStat.Parameters.Add("@rank_in_text", OdbcType.Numeric).Value = s.Rank_unutar_teksta;
                    insertStat.Parameters.Add("@pct_of_occurence", OdbcType.Real).Value = s.Procenat_pojave_unutar_teksta;
                    insertStat.ExecuteNonQuery();

                }
            }
            else
            {
                foreach (Rijec r in lista_rijeci_poslije_gramatike)
                {
                    Rank++;
                    s.Rijec_id = r.Id;
                    s.Tekst_id = tekst.Id;
                    s.Broj_ponavljanja = r.Ponavljanje;
                    s.Tip_statistike = tip;
                    s.Rank_unutar_teksta = Rank;
                    s.Procenat_pojave_unutar_teksta = Decimal.Round((Decimal)r.Ponavljanje / ukupno_rijeci, 3);
                    string q = "INSERT INTO stats (word_id,word_text,text_id,type_of_stats,num_of_repeats,rank_in_text,pct_of_occurence) VALUES (?,?,?,?,?,?,?);";
                    OdbcCommand insertStat = new OdbcCommand(q, connection);
                    insertStat.Parameters.Add("@word_id", OdbcType.Numeric).Value = 5445;
                    insertStat.Parameters.Add("@word_text", OdbcType.Char).Value = r.Tekst;
                    insertStat.Parameters.Add("@text_id", OdbcType.Numeric).Value = s.Tekst_id;
                    insertStat.Parameters.Add("@type_of_stats", OdbcType.Numeric).Value = s.Tip_statistike;
                    insertStat.Parameters.Add("@num_of_repeats", OdbcType.Numeric).Value = s.Broj_ponavljanja;
                    insertStat.Parameters.Add("@rank_in_text", OdbcType.Numeric).Value = s.Rank_unutar_teksta;
                    insertStat.Parameters.Add("@pct_of_occurence", OdbcType.Real).Value = s.Procenat_pojave_unutar_teksta;
                    insertStat.ExecuteNonQuery();

                }
            }
            MessageBox.Show("Unešena statistika!");
        }
    }
}
