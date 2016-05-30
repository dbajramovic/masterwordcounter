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
    public partial class InsertNounsPronouns : Form
    {
        private Rijec dekl_rijec;
        private List<String> lista_deklinacija;
        List<String> palatalni = new List<string>();
        public InsertNounsPronouns(Rijec r)
        {
            dekl_rijec = r;       
            palatalni.Add("ž");
            palatalni.Add("ć");
            palatalni.Add("č");
            palatalni.Add("đ");
            palatalni.Add("dž");
            palatalni.Add("š");
            lista_deklinacija = new List<String>();
            InitializeComponent();
        }

        private void InsertNounsPronouns_Load(object sender, EventArgs e)
        {
            t_nom_jed.Text = dekl_rijec.Tekst;
            button2.Enabled = false;
            r_male.Checked = true;
        }

        private void r_male_CheckedChanged(object sender, EventArgs e)
        {
            r_female.Checked = false;
            r_middle.Checked = false;
        }

        private void r_female_CheckedChanged(object sender, EventArgs e)
        {
            r_male.Checked = false;
            r_middle.Checked = false;
        }

        private void r_middle_CheckedChanged(object sender, EventArgs e)
        {
            r_female.Checked = false;
            r_male.Checked = false;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                if (r_male.Checked && (t_nom_mno.Text.Substring(t_nom_mno.Text.Length - 3) == "ovi" || (t_nom_mno.Text.Substring(t_nom_mno.Text.Length - 3) == "evi")))
                {
                    t_gen_jed.Text = t_nom_jed.Text + "a";
                    t_dat_jed.Text = t_nom_jed.Text + "u";
                    t_akuz_jed.Text = t_nom_jed.Text + "a";
                    if (palatalni.Contains(t_nom_jed.Text.Substring(t_nom_jed.Text.Length - 1)))
                    {
                        t_vok_jed.Text = t_nom_jed.Text + "u";
                        t_inst_jed.Text = t_nom_jed.Text + "em";
                    }
                    else
                    {
                        t_vok_jed.Text = t_nom_jed.Text + "e";
                        t_inst_jed.Text = t_nom_jed.Text + "om";
                    }
                    t_lok_jed.Text = t_nom_jed.Text + "u";
                    t_gen_mno.Text = t_nom_mno.Text.Substring(0, t_nom_mno.Text.Length - 1) + "a";
                    t_dat_mno.Text = t_nom_mno.Text + "ma";
                    t_lok_mno.Text = t_nom_mno.Text + "ma";
                    t_inst_mno.Text = t_nom_mno.Text + "ma";
                    t_vok_mno.Text = t_nom_mno.Text;
                    t_aku_mno.Text = t_nom_mno.Text.Substring(0, t_nom_mno.Text.Length - 1) + "e";
                }
                else if (t_nom_jed.Text.Substring(t_nom_jed.Text.Length - 1) == "a")
                {
                    String baza = t_nom_jed.Text.Substring(0, t_nom_jed.Text.Length - 1);
                    t_gen_jed.Text = baza + "e";
                    t_dat_jed.Text = baza + "i";
                    t_lok_jed.Text = baza + "i";
                    t_akuz_jed.Text = baza + "u";
                    t_vok_jed.Text = baza + "o";
                    t_inst_jed.Text = baza + "om";
                    t_lok_jed.Text = baza + "i";
                    t_aku_mno.Text = t_nom_mno.Text;
                    t_vok_mno.Text = t_nom_mno.Text;
                    t_gen_mno.Text = baza + "a";
                    t_dat_mno.Text = baza + "ama";
                    t_lok_mno.Text = baza + "ama";
                    t_inst_mno.Text = baza + "ama";
                }
                else if (r_middle.Checked)
                {
                    if (t_nom_jed.Text.Substring(t_nom_jed.Text.Length - 1) == "o")
                    {
                        String baza = t_nom_jed.Text.Substring(0, t_nom_jed.Text.Length - 1);
                        t_vok_jed.Text = t_nom_jed.Text;
                        t_gen_jed.Text = baza + "a";
                        t_dat_jed.Text = baza + "u";
                        t_akuz_jed.Text = baza + "o";
                        t_lok_jed.Text = baza + "u";
                        t_inst_jed.Text = baza + "om";
                        t_vok_mno.Text = t_nom_mno.Text;
                        t_gen_mno.Text = baza + "a";
                        t_dat_mno.Text = baza + "ima";
                        t_lok_mno.Text = baza + "ima";
                        t_inst_mno.Text = baza + "ima";
                        t_aku_mno.Text = baza + "a";
                    }
                    if (t_nom_jed.Text.Substring(t_nom_jed.Text.Length - 1) == "e")
                    {
                        String baza = t_nom_jed.Text.Substring(0, t_nom_jed.Text.Length - 1);
                        t_vok_jed.Text = t_nom_jed.Text;
                        t_gen_jed.Text = baza + "a";
                        t_dat_jed.Text = baza + "u";
                        t_akuz_jed.Text = baza + "e";
                        t_lok_jed.Text = baza + "u";
                        t_inst_jed.Text = baza + "em";
                        t_vok_mno.Text = t_nom_mno.Text;
                        t_gen_mno.Text = baza + "a";
                        t_dat_mno.Text = baza + "ima";
                        t_lok_mno.Text = baza + "ima";
                        t_inst_mno.Text = baza + "ima";
                        t_aku_mno.Text = baza + "a";
                    }
                }
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                lista_deklinacija.Clear();
                lista_deklinacija.Add(t_nom_jed.Text);
                lista_deklinacija.Add(t_gen_jed.Text);
                lista_deklinacija.Add(t_dat_jed.Text);
                lista_deklinacija.Add(t_akuz_jed.Text);
                lista_deklinacija.Add(t_vok_jed.Text);
                lista_deklinacija.Add(t_inst_jed.Text);
                lista_deklinacija.Add(t_lok_jed.Text);
                lista_deklinacija.Add(t_nom_mno.Text);
                lista_deklinacija.Add(t_gen_mno.Text);
                lista_deklinacija.Add(t_dat_mno.Text);
                lista_deklinacija.Add(t_aku_mno.Text);
                lista_deklinacija.Add(t_vok_mno.Text);
                lista_deklinacija.Add(t_inst_mno.Text);
                lista_deklinacija.Add(t_lok_mno.Text);
                int Id = 0;
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "INSERT INTO words(id, word, root, type, irregular) VALUES(nextval('words_id_seq'), ?, ?, ?, false); ";
                OdbcCommand insertRootText = new OdbcCommand(q, connection);
                OdbcCommand insertText = new OdbcCommand(q, connection);
                Rijec root = new Rijec();
                root.Tekst = lista_deklinacija[0];
                root.Tip = 1;
                root.Korijen = "";
                root.Irregular = false;
                root.Ponavljanje = 1;
                root.Id = 2;
                insertRootText.Parameters.Add("@word", OdbcType.Text).Value = root.Tekst;
                insertRootText.Parameters.Add("@root", OdbcType.Int).Value = 0;
                insertRootText.Parameters.Add("@type", OdbcType.Int).Value = root.Tip;
                insertRootText.Parameters.Add("@irregular", OdbcType.Int).Value = false;
                insertRootText.ExecuteNonQuery();
                string q1 = "SELECT id FROM words WHERE word=?";
                OdbcCommand getRootId = new OdbcCommand(q1, connection);
                getRootId.Parameters.Add("@word", OdbcType.Text).Value = lista_deklinacija[0];
                OdbcDataReader odr = getRootId.ExecuteReader();
                while (odr.Read())
                {
                    Id = odr.GetInt32(0);
                }
                lista_deklinacija.RemoveAt(0);
                foreach(String s in lista_deklinacija)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 1;
                    t.Korijen = lista_deklinacija[0];
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = false;
                    insertText.ExecuteNonQuery();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
