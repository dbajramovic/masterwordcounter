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

namespace MasterWordCounter
{
    public partial class InsertWords : Form
    {
        private MySortableBindingList<Rijec> lista_rijeci;
        private MySortableBindingList<Rijec> filtrirana_lista_rijeci;
        private List<Rijec> lista_svih_rijeci_koje_su_root;
        private List<Rijec> lista_svih_rijeci;
        private List<Rijec> temp_lista = new List<Rijec>();
        private List<TipRijeci> lista_tipova;
        private int brojUnesenihRijeci;
        public InsertWords(MySortableBindingList<Rijec> lr)
        {
            lista_svih_rijeci = new List<Rijec>();
            lista_svih_rijeci_koje_su_root = new List<Rijec>();
            lista_tipova = new List<TipRijeci>();
            filtrirana_lista_rijeci = new MySortableBindingList<Rijec>();
            lista_rijeci = lr;
            brojUnesenihRijeci = 0;
            InitializeComponent();
        }

        private void InsertWords_Load(object sender, EventArgs e)
        {
            try
            {

                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "SELECT id, word, root, type, irregular FROM words WHERE (root IS NULL) OR (root = 0)";
                OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                OdbcDataReader odr = getAllTexts.ExecuteReader();
                lista_svih_rijeci_koje_su_root.Clear();
                while (odr.Read())
                {
                    Rijec t = new Rijec();
                    t.Tekst = odr.GetString(1);
                    t.Korijen = odr.GetString(1);
                    t.Tip = odr.GetInt32(3);
                    t.Irregular = odr.GetBoolean(4);
                    t.Id = odr.GetInt32(0);
                    lista_svih_rijeci_koje_su_root.Add(t);
                }
              /*  c_root.DropDownStyle = ComboBoxStyle.DropDown;
                c_root.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                c_root.AutoCompleteSource = AutoCompleteSource.ListItems;*/
                c_root.DataSource = null;
                c_root.DataSource = lista_svih_rijeci_koje_su_root;
                q = "SELECT id, type FROM word_types";
                odr.Close();
                OdbcCommand getAllTypes = new OdbcCommand(q, connection);
                OdbcDataReader odr1 = getAllTypes.ExecuteReader();
                int i = 1;
                while (odr1.Read())
                {
                    TipRijeci t = new TipRijeci();
                    t.Id = i;
                    t.Naziv = odr1.GetValue(1).ToString();
                    lista_tipova.Add(t);
                    i++;
                }
                c_type.DataSource = null;
                c_type.DataSource = lista_tipova;
                odr1.Close();
                q = "SELECT DISTINCT word, COALESCE(root,0), type, irregular,id FROM words";
                OdbcCommand getAllWords = new OdbcCommand(q, connection);
                OdbcDataReader odr2 = getAllWords.ExecuteReader();
                lista_svih_rijeci.Clear();
                while (odr2.Read())
                {
                    Rijec t = new Rijec();
                    t.Tekst = odr2.GetString(0);
                    t.Korijen = odr2.GetString(1);
                    t.Tip = odr2.GetInt32(2);
                    t.Irregular = odr2.GetBoolean(3);
                    t.Id = odr2.GetInt32(4);
                    lista_svih_rijeci.Add(t);
                }
                odr2.Close();
                connection.Close();
                int broj_poznatih = 0;
                bool dodaj = true;
                foreach (Rijec r in lista_rijeci)
                {
                   foreach (Rijec r1 in lista_svih_rijeci)
                    {
                        if (r1.Tekst == r.Tekst)
                        {
                            broj_poznatih++;
                            dodaj = false;
                            break;
                        }
                    }
                   if(dodaj)
                    filtrirana_lista_rijeci.Add(r);
                    dodaj = true;
                }
                l_words.Text = lista_svih_rijeci_koje_su_root.Count.ToString();
                t_word.Text = filtrirana_lista_rijeci[0].Tekst;
                l_InList.Text = "1/" + filtrirana_lista_rijeci.Count.ToString();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ch_root.Checked) {
                if (c_type.SelectedIndex == 0 || c_type.SelectedIndex == 2 || c_type.SelectedIndex == 5)
                {
                    Rijec r = new Rijec();
                    r.Tekst = t_word.Text;
                    InsertNounsPronouns inp = new InsertNounsPronouns(r);
                    inp.Show();
                }
                if (c_type.SelectedIndex == 1)
                {
                    Rijec r = new Rijec();
                    r.Tekst = t_word.Text;
                    InsertVerbRegularRoot irr = new InsertVerbRegularRoot(r);
                    irr.Show();
                }
            }
            try {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "INSERT INTO words(id, word, root, type, irregular) VALUES(nextval('words_id_seq'), ?, ?, ?, false); ";
                OdbcCommand insertText = new OdbcCommand(q, connection);
                Rijec t = (Rijec)(c_root.SelectedItem);
                insertText.Parameters.Add("@word", OdbcType.Text).Value = t_word.Text;
                if(ch_root.Checked)
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = null;
                else
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = t.Id;
                insertText.Parameters.Add("@type", OdbcType.Int).Value = c_type.SelectedIndex+1;
                if (ch_regular.Checked)
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 1;
                else
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                insertText.ExecuteNonQuery();
                brojUnesenihRijeci++;
                t_word.Text = filtrirana_lista_rijeci[brojUnesenihRijeci].Tekst;
                l_InList.Text = brojUnesenihRijeci + 1 + "/"+filtrirana_lista_rijeci.Count.ToString();
                connection.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            brojUnesenihRijeci++;
            t_word.Text = filtrirana_lista_rijeci[brojUnesenihRijeci].Tekst;
            l_InList.Text = brojUnesenihRijeci + 1 + "/" + filtrirana_lista_rijeci.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "SELECT id, word, root, type, irregular FROM words WHERE (root IS NULL) OR (root = 0)";
                OdbcCommand getAllTexts = new OdbcCommand(q, connection);
                OdbcDataReader odr = getAllTexts.ExecuteReader();
                lista_svih_rijeci_koje_su_root.Clear();
                while (odr.Read())
                {
                    Rijec t = new Rijec();
                    t.Tekst = odr.GetString(1);
                    t.Korijen = odr.GetString(1);
                    t.Tip = odr.GetInt32(3);
                    t.Irregular = odr.GetBoolean(4);
                    t.Id = odr.GetInt32(0);
                    lista_svih_rijeci_koje_su_root.Add(t);
                }
                c_root.DataSource = null;
                c_root.DataSource = lista_svih_rijeci_koje_su_root;
                q = "SELECT id, type FROM word_types";
                odr.Close();
                OdbcCommand getAllTypes = new OdbcCommand(q, connection);
                OdbcDataReader odr1 = getAllTypes.ExecuteReader();
                lista_svih_rijeci_koje_su_root.Clear();
                int i = 1;
                while (odr1.Read())
                {
                    TipRijeci t = new TipRijeci();
                    t.Id = i;
                    t.Naziv = odr1.GetValue(1).ToString();
                    lista_tipova.Add(t);
                    i++;
                }
                c_type.DataSource = null;
                c_type.DataSource = lista_tipova;
                odr1.Close();
                q = "SELECT DISTINCT word, COALESCE(root,0), type, irregular,id FROM words";
                OdbcCommand getAllWords = new OdbcCommand(q, connection);
                OdbcDataReader odr2 = getAllWords.ExecuteReader();
                lista_svih_rijeci.Clear();
                while (odr2.Read())
                {
                    Rijec t = new Rijec();
                    t.Tekst = odr2.GetString(0);
                    t.Korijen = odr2.GetString(1);
                    t.Tip = odr2.GetInt32(2);
                    t.Irregular = odr2.GetBoolean(3);
                    t.Id = odr2.GetInt32(4);
                    lista_svih_rijeci.Add(t);
                }
                odr2.Close();
                connection.Close();
                int broj_poznatih = 0;
                bool dodaj = true;
                filtrirana_lista_rijeci.Clear();
                foreach (Rijec r in lista_rijeci)
                {
                    foreach (Rijec r1 in lista_svih_rijeci)
                    {
                        if (r1.Tekst == r.Tekst)
                        {
                            broj_poznatih++;
                            dodaj = false;
                            break;
                        }
                    }
                    if (dodaj)
                        filtrirana_lista_rijeci.Add(r);
                    dodaj = true;
                }
                l_words.Text = lista_svih_rijeci_koje_su_root.Count.ToString();
                t_word.Text = filtrirana_lista_rijeci[0].Tekst;
                l_InList.Text = "1/" + filtrirana_lista_rijeci.Count.ToString();
            }
            catch(Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }

        private void c_root_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void c_root_TextUpdate(object sender, EventArgs e)
        {

            string s = c_root.Text;
            temp_lista.Clear();
            foreach (Rijec r in lista_svih_rijeci_koje_su_root)
            {
                if (r.Tekst.Contains(c_root.Text))
                {
                    temp_lista.Add(r);
                }
            }
            c_root.DataSource = null;
            c_root.DataSource = temp_lista;
            c_root.Text = s;
        }
    }
}
