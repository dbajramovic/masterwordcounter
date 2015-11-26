using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MasterWordCounter
{
    public partial class ImportText : Form
    {
        public List<Tekst> lista_tekstova;
        public ImportText(List<Tekst> lt)
        {
            lista_tekstova = lt;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string linija = "";
            try
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {            
                    linija = sr.ReadToEnd();
                    Tekst t = new Tekst();
                    t.Sadrzaj = linija;
                    t.Naziv = textBox2.Text;
                    MessageBox.Show("Tekst unošen!");
                    lista_tekstova.Add(t);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
