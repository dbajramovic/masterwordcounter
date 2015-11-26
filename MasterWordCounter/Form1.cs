using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterWordCounter
{
    public partial class Form1 : Form
    {
        public List<Tekst> lista_tekstova;
        public List<Rijec> lista_rijeci;
        public Form1()
        {
            lista_tekstova = new List<Tekst>();
            lista_rijeci = new List<Rijec>();
            InitializeComponent();
        }

        private void importTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportText it = new ImportText(lista_tekstova);
            it.Show();
        }

        private void viewTextsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTexts vt = new ViewTexts(lista_tekstova);
            vt.Show();
        }
    }
}
