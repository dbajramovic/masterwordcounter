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
    public partial class InsertVerbRegularRoot : Form
    {
        private List<string> samoglasnik;
        private Rijec root;
        private List<string> lista_vremena;
        private List<string> prezent;
        private List<string> aorist;
        private List<string> gpr;
        private List<string> gpt;
        private List<string> imperativ;
        private List<string> gps;
        private List<string> gpp;
        private List<string> perfekt;
        private List<string> pluskvamperfekt;
        private List<string> futur1;
        private List<string> futur2;
        private List<string> kondicional;
        public InsertVerbRegularRoot(Rijec r)
        {
            root = r;
            lista_vremena = new List<string>();
            prezent = new List<string>();
            aorist = new List<string>();
            gpr = new List<string>();
            gpt = new List<string>();
            gps = new List<string>();
            gpp = new List<string>();
            imperativ = new List<string>();
            perfekt = new List<string>();
            pluskvamperfekt = new List<string>();
            futur1 = new List<string>();
            futur2 = new List<string>();
            kondicional = new List<string>();
            samoglasnik = new List<string>();
            InitializeComponent();
        }
        private void GenerisiVremena(Rijec r) {
            //Prezent za "sti"
            if(r.Tekst.Substring(r.Tekst.Length-3)=="sti")
            {
                
            }//prezent za "ći"
            else if(r.Tekst.Substring(r.Tekst.Length - 2) == "ći")
            {

            }
            else //prezent za ti
            {
                prezent.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                prezent.Add(baza + "m");
                prezent.Add(baza + "š");
                prezent.Add(baza);
                prezent.Add(baza + "mo");
                prezent.Add(baza + "te");
                prezent.Add(baza + "ju");
            }
            //Aorist za "ti"
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ti")
            {
                aorist.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                if (!samoglasnik.Contains(baza.Substring(baza.Length-1).ToUpper())) {
                    aorist.Add(baza + "oh");
                    aorist.Add(baza + "e");
                    aorist.Add(baza + "e");
                    aorist.Add(baza + "osmo");
                    aorist.Add(baza + "oste");
                    aorist.Add(baza + "oše");
                }
                else
                {
                    aorist.Add(baza + "h");
                    aorist.Add(baza);
                    aorist.Add(baza);
                    aorist.Add(baza + "smo");
                    aorist.Add(baza + "ste");
                    aorist.Add(baza + "še");
                }
            }
            //Aorist za "ći"
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ći")
            {
                aorist.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                baza += "k";
                aorist.Add(baza + "oh");
                aorist.Add(baza + "e");
                aorist.Add(baza + "e");
                aorist.Add(baza + "osmo");
                aorist.Add(baza + "oste");
                aorist.Add(baza + "oše");
            }
            //Glagolski pridjev radni za "ti"
            if(r.Tekst.Substring(r.Tekst.Length - 2) == "ti")
            {
                gpr.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                gpr.Add(baza + "o");
                gpr.Add(baza + "la");
                gpr.Add(baza + "lo");
                gpr.Add(baza + "li");
                gpr.Add(baza + "le");
                gpr.Add(baza + "la");
            }
            //GPR za "ći"
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ći")
            {
                gpr.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                baza += "k";
                gpr.Add(baza + "o");
                gpr.Add(baza + "la");
                gpr.Add(baza + "lo");
                gpr.Add(baza + "li");
                gpr.Add(baza + "le");
                gpr.Add(baza + "la");
            }
            //Glagolski pridjev trpni za "ti"
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ti")
            {
                gpt.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                gpt.Add(baza + "n");
                gpt.Add(baza + "na");
                gpt.Add(baza + "no");
                gpt.Add(baza + "ni");
                gpt.Add(baza + "ne");
                gpt.Add(baza + "na");
            }
            //GPT za "ći"
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ći")
            {
                gpt.Clear();
                string baza = r.Tekst.Substring(0, r.Tekst.Length - 2);
                baza += "k";
                gpt.Add(baza + "n");
                gpt.Add(baza + "na");
                gpt.Add(baza + "no");
                gpt.Add(baza + "ni");
                gpt.Add(baza + "ne");
                gpt.Add(baza + "na");
            }
            //Imperativ bez "a"
            if (!(r.Tekst.Substring(r.Tekst.Length - 3) == "ati"))
            {
                imperativ.Clear();
                string baza = prezent[5].Substring(0, prezent[5].Length - 1);
                imperativ.Add(baza);
                imperativ.Add(baza + "i");
                imperativ.Add(baza);
                imperativ.Add(baza + "imo");
                imperativ.Add(baza + "ite");
                imperativ.Add(baza);
            }
            //Imperativ sa "a"
            if ((r.Tekst.Substring(r.Tekst.Length - 3) == "ati"))
            {
                imperativ.Clear();
                string baza = prezent[5].Substring(0, prezent[5].Length - 2);
                imperativ.Add(baza);
                imperativ.Add(baza + "j");
                imperativ.Add(baza);
                imperativ.Add(baza + "jmo");
                imperativ.Add(baza + "jte");
                imperativ.Add(baza);
            }
            //Gl. prilog sadašnji
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ti")
            {
                gps.Clear();
                string baza = prezent[5];
                gps.Add(baza + "ći");
            }
            //Gl. prilog prošli
            if (r.Tekst.Substring(r.Tekst.Length - 2) == "ti")
            {
                gpp.Clear();
                string baza = prezent[5];
                gpp.Add(baza + "vši");
            }
        }
        private void InsertVerbRegularRoot_Load(object sender, EventArgs e)
        {
            t_infinitiv.Text = root.Tekst;
            lista_vremena.Add("Prezent");
            lista_vremena.Add("Aorist");
            lista_vremena.Add("Glagolski pridjev radni");
            lista_vremena.Add("Glagolski pridjev trpni");
            lista_vremena.Add("Imperativ");
            lista_vremena.Add("Glagolski prilog sadašnji");
            lista_vremena.Add("Glagolski prilog prošli");
            lista_vremena.Add("Perfekt");
            lista_vremena.Add("Imperfekt");
            lista_vremena.Add("Pluskvamperfekt");
            lista_vremena.Add("Futur I");
            lista_vremena.Add("Futur II");
            lista_vremena.Add("Kondicional");
            samoglasnik.Add("A");
            samoglasnik.Add("E");
            samoglasnik.Add("I");
            samoglasnik.Add("O");
            samoglasnik.Add("U");
            c_glagolska_vremena.DataSource = lista_vremena;
            GenerisiVremena(root);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            root.Tekst = t_infinitiv.Text;
            if(!c_manual.Checked)
            GenerisiVremena(root);
        }

        private void c_glagolska_vremena_SelectedIndexChanged(object sender, EventArgs e)
        {
            string vrijeme = (string)(c_glagolska_vremena.SelectedItem);
            if (!c_manual.Checked)
            GenerisiVremena(root);
            //Prikaz
            try {
                if (vrijeme == "Prezent")
                {
                    t_1_lice_jed.Text = prezent[0];
                    t_2_lice_jed.Text = prezent[1];
                    t_3_lice_jed.Text = prezent[2];
                    t_1_lice_mno.Text = prezent[3];
                    t_2_lice_mno.Text = prezent[4];
                    t_3_lice_mno.Text = prezent[5];
                    g_lica.Visible = true;
                    g_rodovi.Visible = false;
                }
                if (vrijeme == "Aorist")
                {
                    t_1_lice_jed.Text = aorist[0];
                    t_2_lice_jed.Text = aorist[1];
                    t_3_lice_jed.Text = aorist[2];
                    t_1_lice_mno.Text = aorist[3];
                    t_2_lice_mno.Text = aorist[4];
                    t_3_lice_mno.Text = aorist[5];
                    g_lica.Visible = true;
                    g_rodovi.Visible = false;
                }
                if (vrijeme == "Glagolski pridjev radni")
                {
                    t_muski_jed.Text = gpr[0];
                    t_zen_jed.Text = gpr[1];
                    t_sred_jed.Text = gpr[2];
                    t_muski_mno.Text = gpr[3];
                    t_zen_mno.Text = gpr[4];
                    t_sred_mno.Text = gpr[5];
                    g_lica.Visible = false;
                    g_rodovi.Visible = true;
                }
                if (vrijeme == "Glagolski pridjev trpni")
                {
                    t_muski_jed.Text = gpt[0];
                    t_zen_jed.Text = gpt[1];
                    t_sred_jed.Text = gpt[2];
                    t_muski_mno.Text = gpt[3];
                    t_zen_mno.Text = gpt[4];
                    t_sred_mno.Text = gpt[5];
                    g_lica.Visible = false;
                    g_rodovi.Visible = true;
                }
                if (vrijeme == "Imperativ")
                {
                    t_1_lice_jed.Text = imperativ[0];
                    t_2_lice_jed.Text = imperativ[1];
                    t_3_lice_jed.Text = imperativ[2];
                    t_1_lice_mno.Text = imperativ[3];
                    t_2_lice_mno.Text = imperativ[4];
                    t_3_lice_mno.Text = imperativ[5];
                    g_lica.Visible = true;
                    g_rodovi.Visible = false;
                }
                if (vrijeme == "Glagolski prilog sadašnji")
                {
                    t_1_lice_jed.Text = gps[0];
                    t_2_lice_jed.Text = "";
                    t_3_lice_jed.Text = "";
                    t_1_lice_mno.Text = "";
                    t_2_lice_mno.Text = "";
                    t_3_lice_mno.Text = "";
                    g_lica.Visible = true;
                    g_rodovi.Visible = false;
                }
                if (vrijeme == "Glagolski prilog prošli")
                {
                    t_1_lice_jed.Text = gpp[0];
                    t_2_lice_jed.Text = "";
                    t_3_lice_jed.Text = "";
                    t_1_lice_mno.Text = "";
                    t_2_lice_mno.Text = "";
                    t_3_lice_mno.Text = "";
                    g_lica.Visible = true;
                    g_rodovi.Visible = false;
                }
            }
            catch(Exception es1)
            {
                MessageBox.Show(es1.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = 0;
                OdbcConnection connection = new OdbcConnection();
                connection.ConnectionString = "DSN=PostgreSQL35W;UID=masterwordcounter;PWD=masterwordcounter";
                connection.Open();
                string q = "INSERT INTO words(id, word, root, type, irregular) VALUES(nextval('words_id_seq'), ?, ?, ?, false); ";
                OdbcCommand insertRootText = new OdbcCommand(q, connection);
                OdbcCommand insertText = new OdbcCommand(q, connection);
                Rijec root = new Rijec();
                root.Tekst = t_infinitiv.Text;
                root.Tip = 2;
                root.Korijen = "";
                root.Irregular = false;
                root.Ponavljanje = 1;
                root.Id = 2;
                insertRootText.Parameters.Add("@word", OdbcType.Text).Value = root.Tekst;
                insertRootText.Parameters.Add("@root", OdbcType.Int).Value = 0;
                insertRootText.Parameters.Add("@type", OdbcType.Int).Value = root.Tip;
                insertRootText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                insertRootText.ExecuteNonQuery();
                string q1 = "SELECT id FROM words WHERE word=?";
                OdbcCommand getRootId = new OdbcCommand(q1,connection);
                getRootId.Parameters.Add("@word", OdbcType.Text).Value = t_infinitiv.Text;
                OdbcDataReader odr = getRootId.ExecuteReader();
                while(odr.Read())
                {
                    Id = odr.GetInt32(0);
                }
                foreach (string s in prezent)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in aorist)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in gpr)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in gpt)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in gps)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in gpp)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in imperativ)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in perfekt)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in pluskvamperfekt)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in futur1)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in futur2)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                foreach (string s in kondicional)
                {
                    insertText.Parameters.Clear();
                    Rijec t = new Rijec();
                    t.Tekst = s;
                    t.Tip = 2;
                    t.Korijen = t_infinitiv.Text;
                    t.Irregular = false;
                    t.Ponavljanje = 1;
                    t.Id = 2;
                    insertText.Parameters.Add("@word", OdbcType.Text).Value = t.Tekst;
                    insertText.Parameters.Add("@root", OdbcType.Int).Value = Id;
                    insertText.Parameters.Add("@type", OdbcType.Int).Value = t.Tip;
                    insertText.Parameters.Add("@irregular", OdbcType.Int).Value = 0;
                    insertText.ExecuteNonQuery();
                }
                connection.Close();
                MessageBox.Show("Snimljeno!");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void c_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (c_manual.Checked)
                button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vrijeme = (string)(c_glagolska_vremena.SelectedItem);
            try {
                if (vrijeme == "Prezent")
                {
                    prezent[0] = t_1_lice_jed.Text;
                    prezent[1] = t_2_lice_jed.Text;
                    prezent[2] = t_3_lice_jed.Text;
                    prezent[3] = t_1_lice_mno.Text;
                    prezent[4] = t_2_lice_mno.Text;
                    prezent[5] = t_3_lice_mno.Text;
                }
                if (vrijeme == "Aorist")
                {
                    aorist[0] = t_1_lice_jed.Text;
                    aorist[1] = t_2_lice_jed.Text;
                    aorist[2] = t_3_lice_jed.Text;
                    aorist[3] = t_1_lice_mno.Text;
                    aorist[4] = t_2_lice_mno.Text;
                    aorist[5] = t_3_lice_mno.Text;
                }
                if (vrijeme == "Glagolski pridjev radni")
                {
                    gpr[0] = t_muski_jed.Text;
                    gpr[1] = t_zen_jed.Text;
                    gpr[2] = t_sred_jed.Text;
                    gpr[3] = t_muski_mno.Text;
                    gpr[4] = t_zen_mno.Text;
                    gpr[5] = t_sred_mno.Text;
                }
                if (vrijeme == "Glagolski pridjev trpni")
                {
                    gpt[0] = t_muski_jed.Text;
                    gpt[1] = t_zen_jed.Text;
                    gpt[2] = t_sred_jed.Text;
                    gpt[3] = t_muski_mno.Text;
                    gpt[4] = t_zen_mno.Text;
                    gpt[5] = t_sred_mno.Text;
                }
                if (vrijeme == "Imperativ")
                {
                    imperativ[0] = t_1_lice_jed.Text;
                    imperativ[1] = t_2_lice_jed.Text;
                    imperativ[2] = t_3_lice_jed.Text;
                    imperativ[3] = t_1_lice_mno.Text;
                    imperativ[4] = t_2_lice_mno.Text;
                    imperativ[5] = t_3_lice_mno.Text;
                }
                if (vrijeme == "Glagolski prilog sadašnji")
                {
                    gps[0] = t_1_lice_jed.Text;
                }
                if (vrijeme == "Glagolski prilog prošli")
                {
                    gpp[0] = t_1_lice_jed.Text;
                }
            }
            catch(Exception es2)
            {
                MessageBox.Show(es2.Message);
            }
        }
    }
}
