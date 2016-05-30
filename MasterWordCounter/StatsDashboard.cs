using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace MasterWordCounter
{
    public partial class StatsDashboard : Form
    {
        public StatsDashboard()
        {
            InitializeComponent();
        }
        private List<Tekst> lista_teksta;
        private List<Statistika> lista_stats;
        private List<Statistika> lista_stats_text;
        private List<StatistikaTekst> lista_PDF;
        private int podsuma;
        private double MSEGPDF;
        private double MSENDPF;
        private void StatsDashboard_Load(object sender, EventArgs e)
        {
            c_analiza.SelectedIndex = 1;
            c_tip_analize.SelectedIndex = 1;
            lista_teksta = new List<Tekst>();
            lista_stats = new List<Statistika>();
            lista_stats_text = new List<Statistika>();
            lista_PDF = new List<StatistikaTekst>();
            podsuma = 0;
            OdbcConnection connection = new OdbcConnection();
            connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
            connection.Open();
            string q = "SELECT id,name,content,author FROM texts";
            OdbcCommand getAllTexts = new OdbcCommand(q, connection);
            OdbcDataReader odr = getAllTexts.ExecuteReader();
            lista_teksta.Clear();
            while (odr.Read())
            {
                Tekst t = new Tekst();
                t.Id = odr.GetInt32(0);
                t.Sadrzaj = odr.GetString(2);
                t.Naziv = odr.GetString(1);
                t.Autor = odr.GetString(3);
                lista_teksta.Add(t);
            }
            c_tekst.DataSource = null;
            c_tekst.DataSource = lista_teksta;
            connection.Close();
            odr.Close();
        }

        private void c_tip_analize_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateStats(c_tip_analize.SelectedItem.ToString(),c_analiza.SelectedIndex+1);
        }

        private void c_tekst_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateStats(c_tip_analize.SelectedItem.ToString(), c_analiza.SelectedIndex + 1);
            
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
        private void calculateStats(String type_of_text_amount, int type_of_stats) {
            try {
                if (type_of_text_amount.Equals("Svi tekstovi"))
                {
                    int broj_rez = (int)(numericUpDown1.Value);
                    try
                    {
                        OdbcConnection connection = new OdbcConnection();
                        connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                        connection.Open();
                        string q = "SELECT * FROM (SELECT sum(num_of_repeats) prosjek, avg(pct_of_occurence), word_text FROM stats GROUP BY word_text ORDER BY prosjek DESC) top_sve LIMIT ? OFFSET 0";
                        OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                        getAllTexts.Parameters.Add("@OFFSET", OdbcType.Int).Value = broj_rez;
                        OdbcDataReader odr = getAllTexts.ExecuteReader();
                        int a = 0;
                        lista_stats.Clear();
                        while (odr.Read())
                        {
                            a++;
                            Statistika s = new Statistika();
                            s.Broj_ponavljanja = odr.GetInt32(0);
                            s.Procenat_pojave_unutar_teksta = odr.GetDecimal(1) * 100;
                            s.Id = a;
                            s.Rijec_tekst = odr.GetString(2);
                            lista_stats.Add(s);
                        }
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = lista_stats;
                        connection.Close();
                        dataGridView1.Columns["Rijec_id"].Visible = false;
                        dataGridView1.Columns["Tekst_id"].Visible = false;
                        dataGridView1.Columns["Tip_statistike"].Visible = false;
                        dataGridView1.Columns["Rank_unutar_teksta"].Visible = false;
                        chart1.Series["Rijec"].Points.Clear();
                        for (int i = 0; i < lista_stats.Count; i++)
                            chart1.Series["Rijec"].Points.AddXY(i + 1, lista_stats[i].Broj_ponavljanja);
                        chart1.ChartAreas[0].AxisX.Maximum = broj_rez;
                        chart1.ChartAreas[0].AxisX.Minimum = 0;
                        chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(lista_stats[0].Broj_ponavljanja);
                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        chart2.Series["Rijec"].Points.Clear();
                        chart2.Series["LinearPlot"].Points.Clear();
                        for (int i = 0; i < lista_stats.Count; i++)
                        {
                            chart2.Series["Rijec"].Points.AddXY(Math.Log10(i + 1), Math.Log10(lista_stats[i].Broj_ponavljanja));
                            chart2.Series["LinearPlot"].Points.AddXY(Math.Log10(i + 1), Math.Log10(lista_stats[0].Broj_ponavljanja / (i + 1)));
                        }
                        chart2.ChartAreas[0].AxisX.Maximum = Math.Log10(broj_rez);
                        chart2.ChartAreas[0].AxisX.Minimum = 0;
                        chart2.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Math.Log10(lista_stats[0].Broj_ponavljanja));
                        chart2.ChartAreas[0].AxisY.Minimum = Math.Log10(lista_stats[lista_stats.Count - 1].Broj_ponavljanja);
                        odr.Close();
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                if (type_of_text_amount.Equals("Pojedinačan tekst"))
                {
                    Tekst trenutni_tekst = (Tekst)(c_tekst.SelectedItem);
                    int broj_rez = (int)(numericUpDown1.Value);
                    try
                    {
                        OdbcConnection connection = new OdbcConnection();
                        connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                        connection.Open();
                        string q = "SELECT * FROM (SELECT sum(num_of_repeats) prosjek, avg(pct_of_occurence), word_text FROM stats WHERE text_id = ? AND type_of_stats = ? GROUP BY word_text ORDER BY prosjek DESC) top_sve LIMIT ? OFFSET 0";
                        OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                        getAllTexts.Parameters.Add("@text_id", OdbcType.Int).Value = trenutni_tekst.Id;
                        getAllTexts.Parameters.Add("@type_of_stats", OdbcType.Int).Value = type_of_stats;
                        getAllTexts.Parameters.Add("@OFFSET", OdbcType.Int).Value = broj_rez;
                        OdbcDataReader odr = getAllTexts.ExecuteReader();
                        int a = 0;
                        podsuma = 0;
                        lista_stats.Clear();
                        while (odr.Read())
                        {
                            a++;
                            Statistika s = new Statistika();
                            s.Broj_ponavljanja = odr.GetInt32(0);
                            s.Procenat_pojave_unutar_teksta = odr.GetDecimal(1) * 100;
                            s.Id = a;
                            s.Rijec_tekst = odr.GetString(2);
                            lista_stats.Add(s);
                            podsuma += s.Broj_ponavljanja;
                        }
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = lista_stats;
                        connection.Close();
                        dataGridView1.Columns["Rijec_id"].Visible = false;
                        dataGridView1.Columns["Tekst_id"].Visible = false;
                        dataGridView1.Columns["Tip_statistike"].Visible = false;
                        dataGridView1.Columns["Rank_unutar_teksta"].Visible = false;
                        odr.Close();
                        chart1.Series["Rijec"].Points.Clear();
                        for (int i = 0; i < lista_stats.Count; i++)
                            chart1.Series["Rijec"].Points.AddXY(i + 1, lista_stats[i].Broj_ponavljanja);
                        chart1.ChartAreas[0].AxisX.Maximum = broj_rez;
                        chart1.ChartAreas[0].AxisX.Minimum = 0;
                        chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(lista_stats[0].Broj_ponavljanja);
                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        chart2.Series["Rijec"].Points.Clear();
                        chart2.Series["LinearPlot"].Points.Clear();
                        for (int i = 0; i < lista_stats.Count; i++)
                        {
                            chart2.Series["Rijec"].Points.AddXY(Math.Log10(i + 1), Math.Log10(lista_stats[i].Broj_ponavljanja));
                            chart2.Series["LinearPlot"].Points.AddXY(Math.Log10(i + 1), Math.Log10(lista_stats[0].Broj_ponavljanja / (i + 1)));
                        }
                        chart2.ChartAreas[0].AxisX.Maximum = Math.Log10(broj_rez);
                        chart2.ChartAreas[0].AxisX.Minimum = 0;
                        chart2.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Math.Log10(lista_stats[0].Broj_ponavljanja));
                        chart2.ChartAreas[0].AxisY.Minimum = Math.Log10(lista_stats[lista_stats.Count - 1].Broj_ponavljanja);
                    }
                    catch (Exception es)
                    {
                        MessageBox.Show(es.Message);
                    }
                }
                saveTextStatsToolStripMenuItem.PerformClick();
            }
            catch(Exception es2)
            {
                MessageBox.Show(es2.Message);
            }
        }
        private void saveTextStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tekst trenutni_tekst = (Tekst)(c_tekst.SelectedItem);
            try
            {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "SELECT * FROM (SELECT sum(num_of_repeats) prosjek, avg(pct_of_occurence), word_text FROM stats WHERE text_id = ? AND type_of_stats = ? GROUP BY word_text ORDER BY prosjek DESC) top_sve";
                OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                getAllTexts.Parameters.Add("@text_id", OdbcType.Int).Value = trenutni_tekst.Id;
                getAllTexts.Parameters.Add("@type_of_stats", OdbcType.Int).Value = c_analiza.SelectedIndex+1;
                OdbcDataReader odr = getAllTexts.ExecuteReader();
                int a = 0;
                lista_stats_text.Clear();
                double ukupno = 0;
                while (odr.Read())
                {
                    a++;
                    Statistika s = new Statistika();
                    s.Broj_ponavljanja = odr.GetInt32(0);
                    s.Procenat_pojave_unutar_teksta = odr.GetDecimal(1) * 100;
                    s.Id = a;
                    s.Rijec_tekst = odr.GetString(2);
                    lista_stats_text.Add(s);
                    ukupno += s.Broj_ponavljanja;
                }
                odr.Close();
                List<koordinate> pravi_rez = new List<koordinate>();
                List<koordinate> ideal_rez = new List<koordinate>();
                double suma_razlike = 0;
                for (int i = 0; i < lista_stats_text.Count; i++)
                {
                    if (double.IsNegativeInfinity(Math.Log10(lista_stats_text[i].Broj_ponavljanja))) 
                        break;
                    if (double.IsNegativeInfinity(Math.Log10(lista_stats_text[0].Broj_ponavljanja / (i + 1))))
                        break;
                    koordinate k = new koordinate();
                    k.X = Math.Log10(i + 1);
                    k.Y = Math.Log10(lista_stats_text[i].Broj_ponavljanja);
                    pravi_rez.Add(k);
                    koordinate k1 = new koordinate();
                    k1.X = Math.Log10(i + 1);
                    k1.Y = Math.Log10(lista_stats_text[0].Broj_ponavljanja / (i + 1));
                    ideal_rez.Add(k1);
                }
                try {
                    for (int i = 0; i < pravi_rez.Count; i++)
                    {
                        double a1 = Math.Round(Math.Pow((pravi_rez[i].X - ideal_rez[i].X), 2) + Math.Pow((pravi_rez[i].Y - ideal_rez[i].Y), 2), 4);
                        suma_razlike += a1;
                        suma_razlike = Math.Round(suma_razlike, 4);
                    }
               
                }
                catch (ArithmeticException ae)
                {
                    MessageBox.Show(ae.Message);
                }
                double MSE = suma_razlike / pravi_rez.Count;
                double[] lista_x = new double[ideal_rez.Count];
                double[] lista_y = new double[ideal_rez.Count];
                int j = 0;
                foreach (koordinate k in pravi_rez)
                {
                    lista_x[j] = k.X;
                    lista_y[j] = k.Y;
                    j++;
                }
                double[] f = Fit.Polynomial(lista_x, lista_y, 2, MathNet.Numerics.LinearRegression.DirectRegressionMethod.NormalEquations);
                var bestfit = Tuple.Create(0.0,0.0);
                bestfit = Fit.Line(lista_x, lista_y);
                l_text_stats.Text = "Date riječi u tabeli predstavljaju "+ Math.Round((double)(podsuma/ukupno)*100,2)  +"% od cijelog teksta. Ukupno posebnih riječi ima "+lista_stats_text.Count + " a cijeli tekst ima " + ukupno+" riječi.";
                l_nastavak.Text = "Suma odstupanja od idealnog Zipfovog zakona je "+suma_razlike+", MSE je "+Math.Round(MSE,5)+", RMSE je "+Math.Round(Math.Sqrt(MSE),5)+". Best-fit polinom za rezultate je y(x) = "+Math.Round(f[1],2)+"X + "+Math.Round(f[2],2)+"X ^ 2 + "+Math.Round(f[0],2);
                if (c_analiza.SelectedIndex == 0) MSENDPF = Math.Round(MSE, 5);
                    else MSEGPDF = Math.Round(MSE, 5);
                if (MSENDPF != 0.0 && MSEGPDF != 0.0)
                {
                    StatistikaTekst st = new StatistikaTekst();
                    st.Ime_teksta = c_tekst.SelectedItem.ToString();
                    st.RMSE_G1 = MSEGPDF;
                    st.RMSE_N1 = MSENDPF;
                    double h = Math.Round(st.RMSE_N1 - st.RMSE_G1, 5);
                    st.Pct_diff = Math.Round(h / st.RMSE_N1, 5);
                    if (st.Pct_diff > 1) st.Pct_diff = st.Pct_diff - 1;
                    lista_PDF.Add(st);
                    MSEGPDF = 0.0;
                    MSENDPF = 0.0;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                calculateStats(c_tip_analize.SelectedItem.ToString(), c_analiza.SelectedIndex + 1);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void saveResultsToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 12, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 42);
            PdfWriter pdw = PdfWriter.GetInstance(doc, new FileStream("TextsStats"+DateTime.Now.GetHashCode().ToString() + ".pdf", FileMode.Create));
            doc.Open();
            Paragraph p = new Paragraph("Text Stats for : " + DateTime.Now, times);
            doc.Add(p);
            p.Alignment = 1;
            PdfPTable pdt = new PdfPTable(4);
            pdt.HorizontalAlignment = 1;
            pdt.SpacingBefore = 20f;
            pdt.SpacingAfter = 20f;
            pdt.AddCell("Name of Text");
            pdt.AddCell("MSE (Naivna)");
            pdt.AddCell("MSE (Gramatika)");
            pdt.AddCell("PCT");
            c_tekst.SelectedIndex = 0;
            c_analiza.SelectedIndex = 0;
            foreach (Tekst t in lista_teksta)
            {
                c_analiza.SelectedIndex = 0;
                calculateStats("Pojedinačan tekst", 1);
                c_analiza.SelectedIndex = 1;
                calculateStats("Pojedinačan tekst", 2);
                if(c_tekst.SelectedIndex+1 < c_tekst.Items.Count)
                    c_tekst.SelectedIndex++;
            }
            List<StatistikaTekst> cista_lista_PDF = new List<StatistikaTekst>();
            List<String> help = new List<String>();
            StatistikaTekst ukupno = new StatistikaTekst();
            foreach(StatistikaTekst st in lista_PDF)
            {
                if (!help.Contains(st.Ime_teksta))
                {
                    help.Add(st.Ime_teksta);
                    ukupno.RMSE_G1 += st.RMSE_G1;
                    ukupno.RMSE_N1 += st.RMSE_N1;
                    cista_lista_PDF.Add(st);
                }
            }
            ukupno.Ime_teksta = "TOTAL";
            ukupno.RMSE_G1 /= cista_lista_PDF.Count();
            ukupno.RMSE_N1 /= cista_lista_PDF.Count();
            ukupno.RMSE_G1 = Math.Round(ukupno.RMSE_G1, 5);
            ukupno.RMSE_N1 = Math.Round(ukupno.RMSE_N1, 5);
            ukupno.Pct_diff = Math.Round(ukupno.RMSE_G1 / ukupno.RMSE_N1, 5);
            cista_lista_PDF.Add(ukupno);
            foreach (StatistikaTekst st in cista_lista_PDF)
            {
                pdt.AddCell(st.Ime_teksta);
                pdt.AddCell(Convert.ToString(st.RMSE_N1));
                pdt.AddCell(Convert.ToString(st.RMSE_G1));
                pdt.AddCell(Convert.ToString(st.Pct_diff*100)+'%');
            }
            /*using (MemoryStream stream = new MemoryStream())
            {
                chart1.SaveImage(stream, ChartImageFormat.Png);
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(stream.GetBuffer());
                chartImage.ScalePercent(75f);
                chartImage.Alignment = 1;
                doc.Add(chartImage);
            }*/
            doc.Add(pdt);
            doc.Close();
            using (ExcelPackage ep = new ExcelPackage())
            {
                //Here setting some document properties
                ep.Workbook.Properties.Author = "MasterWordCounter";
                ep.Workbook.Properties.Title = "Text Data";

                //Create a sheet
                ep.Workbook.Worksheets.Add("Text Data");
                ExcelWorksheet ws = ep.Workbook.Worksheets[1];
                ws.Name = "Text Data"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


                DataTable dt = new DataTable("TextsStats" + DateTime.Now.GetHashCode().ToString()); //My Function which generates DataTable
                dt.Columns.Add("Ime Djela");
                dt.Columns.Add("MSE (Naivna)");
                dt.Columns.Add("MSE (Gramatika)");
                dt.Columns.Add("Procenat (%)");
                foreach (StatistikaTekst st in cista_lista_PDF)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ime Djela"] = (st.Ime_teksta);
                    dr["MSE (Naivna)"] = st.RMSE_N1;
                    dr["MSE (Gramatika)"] = st.RMSE_G1;
                    dr["Procenat (%)"] = st.Pct_diff * 100;
                    dt.Rows.Add(dr);
                }
                //Merging cells and create a center heading for out table
                ws.Cells[1, 1].Value = "Ime Djela";
                ws.Cells[1, 2].Value = "MSE (Naivna)";
                ws.Cells[1, 3].Value = "MSE (Gramatika)";
                ws.Cells[1, 4].Value = "Procenat (%)";

                int colIndex = 1;
                int rowIndex = 2;

                foreach (DataColumn dc in dt.Columns) //Creating Headings
                {
                    var cell = ws.Cells[rowIndex, colIndex];

                    //Setting the background color of header cells to Gray
                    var fill = cell.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(Color.Gray);


                    //Setting Top/left,right/bottom borders.
                    var border = cell.Style.Border;
                    border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;

                    //Setting Value in cell
                    cell.Value = "Heading " + dc.ColumnName;

                    colIndex++;
                }

                foreach (DataRow dr in dt.Rows) // Adding Data into rows
                {
                    colIndex = 1;
                    rowIndex++;
                    foreach (DataColumn dc in dt.Columns)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        //Setting Value in cell
                        cell.Value = dr[dc.ColumnName];

                        //Setting borders of cell
                        var border = cell.Style.Border;
                        border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;
                        colIndex++;
                    }
                }

                colIndex = 0;
                foreach (DataColumn dc in dt.Columns) //Creating Headings
                {
                    colIndex++;
                    var cell = ws.Cells[rowIndex, colIndex];

                    //Setting Sum Formula
                    cell.Formula = "Sum(" +
                                    ws.Cells[3, colIndex].Address +
                                    ":" +
                                    ws.Cells[rowIndex - 1, colIndex].Address +
                                    ")";

                    //Setting Background fill color to Gray
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(Color.Gray);
                }

                //Generate A File with Random name
                Byte[] bin = ep.GetAsByteArray();
                string file = Guid.NewGuid().ToString() + ".xlsx";
                File.WriteAllBytes(file, bin);
            }
            MessageBox.Show("PDF created!");
        }

        private void poAutoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "SELECT * FROM (SELECT sum(s.num_of_repeats) prosjek, avg(s.pct_of_occurence), s.word_text, t.author FROM stats s, texts t WHERE s.text_id = t.id AND t.author = 'Agatha Christie' AND type_of_stats = 2 GROUP BY s.word_text,t.author ORDER BY prosjek DESC) top_sve OFFSET 0 LIMIT 200";
                OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                OdbcDataReader odr = getAllTexts.ExecuteReader();
                int a = 0;
                lista_stats_text.Clear();
                double ukupno = 0;
                while (odr.Read())
                {
                    a++;
                    Statistika s = new Statistika();
                    s.Broj_ponavljanja = odr.GetInt32(0);
                    s.Procenat_pojave_unutar_teksta = odr.GetDecimal(1) * 100;
                    s.Id = a;
                    s.Rijec_tekst = odr.GetString(2);
                    lista_stats_text.Add(s);
                    ukupno += s.Broj_ponavljanja;
                }
                odr.Close();
                List<koordinate> pravi_rez = new List<koordinate>();
                List<koordinate> ideal_rez = new List<koordinate>();
                double suma_razlike = 0;
                for (int i = 0; i < lista_stats_text.Count; i++)
                {
                    if (double.IsNegativeInfinity(Math.Log10(lista_stats_text[i].Broj_ponavljanja)))
                        break;
                    if (double.IsNegativeInfinity(Math.Log10(lista_stats_text[0].Broj_ponavljanja / (i + 1))))
                        break;
                    koordinate k = new koordinate();
                    k.X = Math.Log10(i + 1);
                    k.Y = Math.Log10(lista_stats_text[i].Broj_ponavljanja);
                    pravi_rez.Add(k);
                    koordinate k1 = new koordinate();
                    k1.X = Math.Log10(i + 1);
                    k1.Y = Math.Log10(lista_stats_text[0].Broj_ponavljanja / (i + 1));
                    ideal_rez.Add(k1);
                }
                try
                {
                    for (int i = 0; i < pravi_rez.Count; i++)
                    {
                        double a1 = Math.Round(Math.Pow((pravi_rez[i].X - ideal_rez[i].X), 2) + Math.Pow((pravi_rez[i].Y - ideal_rez[i].Y), 2), 4);
                        suma_razlike += a1;
                        suma_razlike = Math.Round(suma_razlike, 4);
                    }

                }
                catch (ArithmeticException ae)
                {
                    MessageBox.Show(ae.Message);
                }
                double MSE = suma_razlike / pravi_rez.Count;
                double[] lista_x = new double[ideal_rez.Count];
                double[] lista_y = new double[ideal_rez.Count];
                int j = 0;
                foreach (koordinate k in pravi_rez)
                {
                    lista_x[j] = k.X;
                    lista_y[j] = k.Y;
                    j++;
                }
                double[] f = Fit.Polynomial(lista_x, lista_y, 2, MathNet.Numerics.LinearRegression.DirectRegressionMethod.NormalEquations);
                var bestfit = Tuple.Create(0.0, 0.0);
                bestfit = Fit.Line(lista_x, lista_y);
                l_text_stats.Text = "Date riječi u tabeli predstavljaju " + Math.Round((double)(podsuma / ukupno) * 100, 2) + "% od cijelog teksta. Ukupno posebnih riječi ima " + lista_stats_text.Count + " a cijeli tekst ima " + ukupno + " riječi.";
                l_nastavak.Text = "Suma odstupanja od idealnog Zipfovog zakona je " + suma_razlike + ", MSE je " + Math.Round(MSE, 5) + ", RMSE je " + Math.Round(Math.Sqrt(MSE), 5) + ". Best-fit polinom za rezultate je y(x) = " + Math.Round(f[1], 2) + "X + " + Math.Round(f[2], 2) + "X ^ 2 + " + Math.Round(f[0], 2);
                if (c_analiza.SelectedIndex == 0) MSENDPF = Math.Round(MSE, 5);
                else MSEGPDF = Math.Round(MSE, 5);
                if (MSENDPF != 0.0 && MSEGPDF != 0.0)
                {
                    StatistikaTekst st = new StatistikaTekst();
                    st.Ime_teksta = c_tekst.SelectedItem.ToString();
                    st.RMSE_G1 = MSEGPDF;
                    st.RMSE_N1 = MSENDPF;
                    double h = Math.Round(st.RMSE_N1 - st.RMSE_G1, 5);
                    st.Pct_diff = Math.Round(h / st.RMSE_N1, 5);
                    if (st.Pct_diff > 1) st.Pct_diff = st.Pct_diff - 1;
                    lista_PDF.Add(st);
                    MSEGPDF = 0.0;
                    MSENDPF = 0.0;
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
