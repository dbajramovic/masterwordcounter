using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterWordCounter
{
    public partial class ViewTexts : Form
    {
        public List<Tekst> lista_teksta;
        public MySortableBindingList<Rijec> lista_rijeci;
        public ViewTexts(List<Tekst> lt)
        {
            lista_teksta = lt;
            lista_rijeci = new MySortableBindingList<Rijec>();
            InitializeComponent();
        }

        private void ViewTexts_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = lista_teksta;
            richTextBox1.Text = lista_teksta[0].Sadrzaj;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = lista_teksta[comboBox1.SelectedIndex].Sadrzaj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = richTextBox1.Text;
            t = t.Replace('.', ' ');
            t = t.Replace(',', ' ');
            t = t.Replace('!', ' ');
            t = t.Replace('?', ' ');
            t = t.Replace('"', ' ');
            t = t.ToLower();
            t = t.Trim();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);
            t = regex.Replace(t, @" ");
            richTextBox1.Text = t;
            progressBar1.Maximum = t.Split(' ').Length;
            int j = 0;
            while(j < t.Split(' ').Length)
            {
                string rijec = t.Split(' ')[j];
                int duz = lista_rijeci.Count;
                int i;
                if (j == 0)
                {
                    Rijec r1 = new Rijec();
                    r1.Tekst = rijec;
                    r1.Korijen = "";
                    r1.Ponavljanje = 1;
                    r1.Tip = 0;
                    lista_rijeci.Add(r1);
                    j++;
                    rijec = t.Split(' ')[j];
                }
                for(i=0;i<lista_rijeci.Count;i++)
                {
                    duz = lista_rijeci.Count;
                    if (lista_rijeci[i].Tekst.Equals(rijec))
                    {
                        lista_rijeci[i].Ponavljanje++;
                        break;
                    }
                    else if(i==duz-1)
                    {
                        Rijec r1 = new Rijec();
                        r1.Tekst = rijec;
                        r1.Korijen = "";
                        r1.Ponavljanje = 1;
                        r1.Tip = 0;
                        lista_rijeci.Add(r1);
                        break;
                    }
                } 
                j++;
                progressBar1.Value = j;
                label1.Text = j+"/"+ t.Split(' ').Length;
                label1.Refresh();
            }
            MessageBox.Show("Analizirano!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tekst t = (Tekst)(comboBox1.SelectedItem);
            TextResult tr = new TextResult(lista_rijeci, t.Naziv);
            tr.Show();
        }
    }
}
