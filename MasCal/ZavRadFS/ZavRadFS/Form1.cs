using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //SQL Server Local DataBase
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Timers;
using System.Globalization;
using System.Collections;
using System.Text.RegularExpressions;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ZavRadFS
{
    public partial class Form1 : Form
    {

        string Bjelanèevine, Masti, Omega3, Omega6, Ugljikohidrati, Vlakna;
        public static string Namirnica;
        public static int selectedItem;
        private DataTable tbl;
        public static string Email;
        public static string Email2;


        #region Forms


        public Form1()
        {
            InitializeComponent();

            /*const string sourcePath = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\bin\Debug\dblNamirnice.mdf";
            const string targetPath = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\dblNamirnice.mdf";
            File.Copy(sourcePath, targetPath, true);
            const string sourcePath2 = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\bin\Debug\dblNamirnice_log.ldf";
            const string targetPath2 = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\dblNamirnice_log.ldf";
            File.Copy(sourcePath2, targetPath2, true);*/


            /*const string sourcePath2 = @"dblNamirnice.mdf";
             var gparent = Directory.GetParent(Directory.GetParent(sourcePath2).ToString());
            string targetPath2 = gparent + @"dblNamirnice.mdf";
            File.Copy(sourcePath2, targetPath2, true);*/

            //const string sourcePath = "bin\\Debug\\dblNamirnice.mdf";
            //const string targetPath = "dblNamirnice.mdf";
            //const string file = "dblNamirnice.mdf";

            txtBjelancevine.Enabled = false;
            txtMasti.Enabled = false;
            txtOmega3.Enabled = false;
            txtOmega6.Enabled = false;
            txtUgljikohidrati.Enabled = false;
            txtVlakna.Enabled = false;
            btnSpremi.Enabled = false;
            txtKalorije2.Enabled = false;
            txtBjelancevine2.Enabled = false;
            txtMasti2.Enabled = false;
            txtOmega32.Enabled = false;
            txtOmega62.Enabled = false;
            txtUgljikohidrati2.Enabled = false;
            txtVlakna2.Enabled = false;
            //const string statusParametara = "StatusParametara.txt";
            {
                StreamReader streamReader = new StreamReader("podaci.txt");

                txtBjelancevine.Text = streamReader.ReadLine();
                txtMasti.Text = streamReader.ReadLine();
                txtOmega3.Text = streamReader.ReadLine();
                txtOmega6.Text = streamReader.ReadLine();
                txtUgljikohidrati.Text = streamReader.ReadLine();
                txtVlakna.Text = streamReader.ReadLine();
                streamReader.Close();

                Bjelanèevine = txtBjelancevine.Text;
                Masti = txtMasti.Text;
                Omega3 = txtOmega3.Text;
                Omega6 = txtOmega6.Text;
                Ugljikohidrati = txtUgljikohidrati.Text;
                Vlakna = txtVlakna.Text;



                string path = "Email.txt";
                StreamReader streamReaderEmail = new StreamReader(path);
                Email = streamReaderEmail.ReadLine();
                Email2 = streamReaderEmail.ReadLine();
                streamReaderEmail.Close();
            }


            provjeri();

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(SendEmail);
            timer.Interval = 1000;
            timer.Enabled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load_list();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBoxOdabraneNamirnice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void PromijeniGramazu(float grami)
        {
            var selected = listViewOdabraneNamirnice.Items[selectedItem];

            float kalorijeNamirnice = float.Parse(selected.SubItems[8].Text);
            float bjelancevineNamirnice = float.Parse(selected.SubItems[2].Text);
            float mastiNamirnice = float.Parse(selected.SubItems[3].Text);
            float omega3Namirnice = float.Parse(selected.SubItems[4].Text);
            float omega6Namirnice = float.Parse(selected.SubItems[5].Text);
            float ugljikohidratiNamirnice = float.Parse(selected.SubItems[6].Text);
            float vlaknaNamirnice = float.Parse(selected.SubItems[7].Text);

            RemoveFromTotal(kalorijeNamirnice, bjelancevineNamirnice, mastiNamirnice, omega3Namirnice, omega6Namirnice,
                    ugljikohidratiNamirnice, vlaknaNamirnice);

            listViewOdabraneNamirnice.Items[selectedItem].SubItems[1].Text = grami.ToString();
            //string cn_string = Properties.Settings.Default.dblNamirniceConnectionString;
            string cn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dblNamirnice.mdf;Integrated Security=True;Connect Timeout=30";
            string sql_Text = "SELECT * FROM tbl_Namirnice WHERE Namirnica = '" + listViewOdabraneNamirnice.Items[selectedItem].SubItems[0].Text + "'";
            SqlConnection Conn = new SqlConnection(cn_string);
            Conn.Open();
            SqlCommand Comm1 = new SqlCommand(sql_Text, Conn);
            using (SqlDataReader reader = Comm1.ExecuteReader())
            {
                string kalorije = "", bjelancevine = "", masti = "", omega3 = "", omega6 = "", ugljikohidrati = "", vlakna = "";
                while (reader.Read())
                {

                    kalorije = (reader["Kalorije"].ToString());
                    bjelancevine = (reader["Bjelančevine"].ToString());
                    masti = (reader["Masti"].ToString());
                    omega3 = (reader["Omega3"].ToString());
                    omega6 = (reader["Omega6"].ToString());
                    ugljikohidrati = (reader["Ugljikohidrati"].ToString());
                    vlakna = (reader["Vlakna"].ToString());
                }
                kalorijeNamirnice = grami * float.Parse(kalorije);
                bjelancevineNamirnice = grami * float.Parse(bjelancevine);
                mastiNamirnice = grami * float.Parse(masti);
                omega3Namirnice = grami * float.Parse(omega3);
                omega6Namirnice = grami * float.Parse(omega6);
                ugljikohidratiNamirnice = grami * float.Parse(ugljikohidrati);
                vlaknaNamirnice = grami * float.Parse(vlakna);

                listViewOdabraneNamirnice.Items[selectedItem].SubItems[2].Text = bjelancevineNamirnice.ToString();
                listViewOdabraneNamirnice.Items[selectedItem].SubItems[3].Text = mastiNamirnice.ToString();
                listViewOdabraneNamirnice.Items[selectedItem].SubItems[4].Text = omega3Namirnice.ToString();
                listViewOdabraneNamirnice.Items[selectedItem].SubItems[5].Text = omega6Namirnice.ToString();
                listViewOdabraneNamirnice.Items[selectedItem].SubItems[6].Text = ugljikohidratiNamirnice.ToString();
                listViewOdabraneNamirnice.Items[selectedItem].SubItems[7].Text = vlaknaNamirnice.ToString();

                AddToTotal(kalorijeNamirnice, bjelancevineNamirnice, mastiNamirnice, omega3Namirnice, omega6Namirnice,
                    ugljikohidratiNamirnice, vlaknaNamirnice);

                Conn.Close();

            }
        }
        private void checkStanjeParametara_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStanjeParametara.Checked == true)
            {
                textBoxBjelancevine.Visible = true;
                textBoxMasti.Visible = true;
                textBoxOmega3.Visible = true;
                textBoxOmega6.Visible = true;
                textBoxUgljikohidrati.Visible = true;
                textBoxVlakna.Visible = true;
                labelBjelancevine.Visible = true;
                labelMasti.Visible = true;
                labelOmega3.Visible = true;
                labelOmega6.Visible = true;
                labelUgljikohidrati.Visible = true;
                labelVlakna.Visible = true;
            }
            else
            {
                textBoxBjelancevine.Visible = false;
                textBoxMasti.Visible = false;
                textBoxOmega3.Visible = false;
                textBoxOmega6.Visible = false;
                textBoxUgljikohidrati.Visible = false;
                textBoxVlakna.Visible = false;
                labelBjelancevine.Visible = false;
                labelMasti.Visible = false;
                labelOmega3.Visible = false;
                labelOmega6.Visible = false;
                labelUgljikohidrati.Visible = false;
                labelVlakna.Visible = false;
            }
        }

        private void checkUredi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUredi.Checked == true)
            {
                txtBjelancevine.Enabled = true;
                txtMasti.Enabled = true;
                txtOmega3.Enabled = true;
                txtOmega6.Enabled = true;
                txtUgljikohidrati.Enabled = true;
                txtVlakna.Enabled = true;
                btnSpremi.Enabled = true;
            }
            else
            {
                txtBjelancevine.Enabled = false;
                txtMasti.Enabled = false;
                txtOmega3.Enabled = false;
                txtOmega6.Enabled = false;
                txtUgljikohidrati.Enabled = false;
                txtVlakna.Enabled = false;
                btnSpremi.Enabled = false;
            }
        }

        private void txtPretrazi_TextChanged(object sender, EventArgs e)
        {
            DataView dataViewNamirnice = tbl.DefaultView;
            dataViewNamirnice.RowFilter = "Namirnica LIKE '%" + txtPretrazi.Text + "%'";
        }

        #endregion /Forms

        #region Buttons


        private void btnDodajNovi_Click(object sender, EventArgs e)
        {
            kartica_dodaj();
        }
        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form1_EnabledChanged(object sender, EventArgs e)
        {
            if (Enabled == true)
            {
                load_list();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();

            //string destinationPath = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\dblNamirnice.mdf";
            //string sourcePath = @"C:\Users\Šangut\Desktop\Proba\ZavRadFS\ZavRadFS\bin\Debug\dblNamirnice.mdf";
            //System.IO.File.Copy(sourcePath, destinationPath, true);
        }

        private void btnIzbrisi_Click(object sender, EventArgs e)
        {

            string name = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.SelectedItem);

            //string cn_string = Properties.Settings.Default.dblNamirniceConnectionString.ToString();
            string cn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dblNamirnice.mdf;Integrated Security=True;Connect Timeout=30";


            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }
            string sql_Text = "DELETE FROM tbl_Namirnice WHERE Namirnica='" + name + "'";
            SqlCommand cmdCommand = new SqlCommand(sql_Text, cn_connection);
            cmdCommand.ExecuteNonQuery();
            cn_connection.Close();
            load_list();
        }

        private void btnIzmjeni_Click(object sender, EventArgs e)
        {
            kartica_izmjeni();
        }

        private void btnDodajNamirnicuOnClick(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9]*$");
            
            if (txtGrami.Text.Equals("") || regexItem.IsMatch(txtGrami.ToString()))
            {
                return;
            }
            string unosNamirnice;
            string unosGNamirnice;
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            unosGNamirnice = float.Parse(txtGrami.Text, NumberStyles.Any, ci).ToString();
            unosNamirnice = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.SelectedItem);

            //string cn_string = Properties.Settings.Default.dblNamirniceConnectionString;
            string cn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dblNamirnice.mdf;Integrated Security=True;Connect Timeout=30";
            string sql_Text = "SELECT * FROM tbl_Namirnice WHERE Namirnica = '" + unosNamirnice + "'";
            SqlConnection Conn = new SqlConnection(cn_string);
            //SqlConnection Conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\tbl_Namirnice.mdf;Integrated Security=True;User Instance=True");
            Conn.Open();
            SqlCommand Comm1 = new SqlCommand(sql_Text, Conn);
            using (SqlDataReader reader = Comm1.ExecuteReader())
            {
                string kalorije = "", bjelancevine = "", masti = "", omega3 = "", omega6 = "", ugljikohidrati = "", vlakna = "";
                while (reader.Read())
                {

                    kalorije = (reader["Kalorije"].ToString());
                    bjelancevine = (reader["Bjelančevine"].ToString());
                    masti = (reader["Masti"].ToString());
                    omega3 = (reader["Omega3"].ToString());
                    omega6 = (reader["Omega6"].ToString());
                    ugljikohidrati = (reader["Ugljikohidrati"].ToString());
                    vlakna = (reader["Vlakna"].ToString());
                }
                float kalorijeNamirnice = float.Parse(unosGNamirnice) * float.Parse(kalorije);
                float bjelancevineNamirnice = float.Parse(unosGNamirnice) * float.Parse(bjelancevine);
                float mastiNamirnice = float.Parse(unosGNamirnice) * float.Parse(masti);
                float omega3Namirnice = float.Parse(unosGNamirnice) * float.Parse(omega3);
                float omega6Namirnice = float.Parse(unosGNamirnice) * float.Parse(omega6);
                float ugljikohidratiNamirnice = float.Parse(unosGNamirnice) * float.Parse(ugljikohidrati);
                float vlaknaNamirnice = float.Parse(unosGNamirnice) * float.Parse(vlakna);

                var row = new String[] { unosNamirnice, unosGNamirnice, bjelancevineNamirnice.ToString(),
                    mastiNamirnice.ToString(), omega3Namirnice.ToString(), omega6Namirnice.ToString(),
                    ugljikohidratiNamirnice.ToString(), vlaknaNamirnice.ToString(), kalorijeNamirnice.ToString()};
                var listViewItem = new ListViewItem(row);
                listViewOdabraneNamirnice.Items.Add(listViewItem);
                AddToTotal(kalorijeNamirnice, bjelancevineNamirnice, mastiNamirnice, omega3Namirnice, omega6Namirnice,
                    ugljikohidratiNamirnice, vlaknaNamirnice);
            }Conn.Close();
            txtGrami.Text = "";
        }

        private void btnIzbrisiOdabranuNamirnicu_Click(object sender, EventArgs e)
        {
            if (listViewOdabraneNamirnice.TopItem == null)
            {
                MessageBox.Show("Neispravna naredba!!");
                return;
            }
            var selected = listViewOdabraneNamirnice.SelectedItems[0];
            
            float kalorijeNamirnice = float.Parse(selected.SubItems[8].Text);
            float bjelancevineNamirnice = float.Parse(selected.SubItems[2].Text);
            float mastiNamirnice = float.Parse(selected.SubItems[3].Text);
            float omega3Namirnice = float.Parse(selected.SubItems[4].Text);
            float omega6Namirnice = float.Parse(selected.SubItems[5].Text);
            float ugljikohidratiNamirnice = float.Parse(selected.SubItems[6].Text);
            float vlaknaNamirnice = float.Parse(selected.SubItems[7].Text);

            listViewOdabraneNamirnice.Items[selected.Index].Remove();
            RemoveFromTotal(kalorijeNamirnice, bjelancevineNamirnice, mastiNamirnice, omega3Namirnice, omega6Namirnice,
                    ugljikohidratiNamirnice, vlaknaNamirnice);
        }

        private void btnPromjeniGramazu_Click(object sender, EventArgs e)
        {
            
                if (listViewOdabraneNamirnice.TopItem == null)
                {
                    MessageBox.Show("Neispravna naredba!!");
                    return;
                }
            
            
            selectedItem = listViewOdabraneNamirnice.SelectedItems[0].Index;
            FormPromijeniGramazu formPromijeniGramazu = new FormPromijeniGramazu(this);
            formPromijeniGramazu.Owner = this;
            formPromijeniGramazu.Show();
        }

        private void btnSpremi_MouseClick(object sender, MouseEventArgs e)
        {
            Bjelanèevine = txtBjelancevine.Text;
            Masti = txtMasti.Text;
            Omega3 = txtOmega3.Text;
            Omega6 = txtOmega6.Text;
            Ugljikohidrati = txtUgljikohidrati.Text;
            Vlakna = txtVlakna.Text;


            var regexItem = new Regex("^[a-zA-Z]*$");
            foreach (char c in Bjelanèevine)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Masti)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Ugljikohidrati)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Vlakna)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Omega3)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Omega6)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) || c.ToString() == ",")
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
                    return;
                }
            }
            if (regexItem.IsMatch(Masti) || regexItem.IsMatch(Ugljikohidrati) || regexItem.IsMatch(Vlakna) || regexItem.IsMatch(Bjelanèevine) || regexItem.IsMatch(Omega3) || regexItem.IsMatch(Omega6))
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajuæim vrijednostima.");
            }
            StreamWriter streamWriter = new StreamWriter("podaci.txt");
            streamWriter.WriteLine(Bjelanèevine);
            streamWriter.WriteLine(Masti);
            streamWriter.WriteLine(Omega3);
            streamWriter.WriteLine(Omega6);
            streamWriter.WriteLine(Ugljikohidrati);
            streamWriter.WriteLine(Vlakna);
            streamWriter.Close();
        }

        private void btnSpremiUkupno_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();
            string tipJela = comboBoxTipJela.Text.ToString();
            if (tipJela.Equals("Odaberi obrok"))
            {
                MessageBox.Show("Molim odaberite jedan od obroka!"); return;
            }
            string kalorije = "Kalorije: " + txtKalorije2.Text;
            string bjelancevine = "Bjelancevine: " + txtBjelancevine2.Text;
            string masti = "Masti: " + txtMasti2.Text;
            string omega3 = "Omega3: " + txtOmega32.Text;
            string omega6 = "Omega6: " + txtOmega62.Text;
            string ugljikohidrati = "Ugljikohidrati: " + txtUgljikohidrati2.Text;
            string vlakna = "Vlakna: " + txtVlakna2.Text;
            List<string> namirnice = new List<string>();

            for (int j = 0; j < listViewOdabraneNamirnice.Items.Count; j++)
            {
                string gramiNamirnice = "Grami: " + listViewOdabraneNamirnice.Items[j].SubItems[1].Text;
                string kalorijeNamirnice = "Kalorije: " + listViewOdabraneNamirnice.Items[j].SubItems[2].Text;
                string imeNamirnice = listViewOdabraneNamirnice.Items[j].SubItems[0].Text;
                int index = imeNamirnice.IndexOf("  ");
                imeNamirnice = imeNamirnice.Substring(0, index);
                string namirnica = "Namirnica " + (j + 1) + ": " + imeNamirnice;
                namirnice.Add(namirnica);
                namirnice.Add(gramiNamirnice);
                //namirnice.Add(kalorijeNamirnice);
            }

            string path = "Povijest.txt";
            if (!File.Exists(path))
            {
                StreamWriter streamWriter = File.CreateText(path);
                streamWriter.Close();
            }
            StreamWriter streamWriter2 = File.AppendText(path);
            streamWriter2.WriteLine("  " + tipJela + "\n\t" + date);
            for (int i = 0; i < namirnice.Count; i++)
            {
                streamWriter2.WriteLine("  " + namirnice[i] + " - " + namirnice[i + 1].ToLower());
                i = i + 1;
            }
            streamWriter2.WriteLine("  Sadrži:");
            streamWriter2.WriteLine("\t o  " + kalorije);
            streamWriter2.WriteLine("\t o  " + bjelancevine);
            streamWriter2.WriteLine("\t o  " + masti);
            streamWriter2.WriteLine("\t o  " + omega3);
            streamWriter2.WriteLine("\t o  " + omega6);
            streamWriter2.WriteLine("\t o  " + ugljikohidrati);
            streamWriter2.WriteLine("\t o  " + vlakna);
            streamWriter2.WriteLine("----------------------------------------------------------");
            streamWriter2.Close();
            MessageBox.Show("Uspješno spremljeno.");


            oduzmi();
            provjeri();
            CompareToLimit();


        }

        private void btnPovijest_MouseClick(object sender, MouseEventArgs e)
        {
            FormPovijest formPovijest = new FormPovijest();
            formPovijest.Owner = this;
            formPovijest.Show();


        }

        private void btnEmailClick(object sender, MouseEventArgs e)
        {
            unesiEmail();
        }
        #endregion /Buttons

        #region Methods

        private void load_list()
        {
            //string cn_string = Properties.Settings.Default.dblNamirniceConnectionString.ToString();
            string cn_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|dblNamirnice.mdf;Integrated Security=True;Connect Timeout=30";
            //string cn_string = "Server=localhost;Database=dblNamirnice;User ID='root';pwd=''";
            //string cn_string = "AttachDbFileName=|DataDirectory|\\data\\dblNamirnice.mdf;integrated security=true;database=dblNamirnice.mdf";

            SqlConnection cn_connection = new SqlConnection(cn_string);
            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }
            string sql_Text = "SELECT * FROM tbl_Namirnice";

            tbl = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_Text, cn_connection);
            adapter.Fill(tbl);

            listBoxSveNamirnice.DisplayMember = "Namirnica";
            listBoxSveNamirnice.ValueMember = "IDnamirnice";
            listBoxSveNamirnice.Sorted = true;
            this.Controls.Add(listBoxSveNamirnice);
            listBoxSveNamirnice.DataSource = tbl;


        }



        private void AddToTotal(float kalorijeNamirnice, float bjelancevineNamirnice, float mastiNamirnice,
            float omega3Namirnice, float omega6Namirnice, float ugljikohidratiNamirnice, float vlaknaNamirnice)
        {
            if (txtKalorije2.Text.Equals(""))
            {
                txtKalorije2.Text = "0";
            }
            txtKalorije2.Text = (kalorijeNamirnice + float.Parse(txtKalorije2.Text.ToString())).ToString();
            if (txtBjelancevine2.Text.Equals(""))
            {
                txtBjelancevine2.Text = "0";
            }
            txtBjelancevine2.Text = (bjelancevineNamirnice + float.Parse(txtBjelancevine2.Text.ToString())).ToString();
            if (txtMasti2.Text.Equals(""))
            {
                txtMasti2.Text = "0";
            }
            txtMasti2.Text = (mastiNamirnice + float.Parse(txtMasti2.Text.ToString())).ToString();
            if (txtOmega32.Text.Equals(""))
            {
                txtOmega32.Text = "0";
            }
            txtOmega32.Text = (omega3Namirnice + float.Parse(txtOmega32.Text.ToString())).ToString();
            if (txtOmega62.Text.Equals(""))
            {
                txtOmega62.Text = "0";
            }
            txtOmega62.Text = (omega6Namirnice + float.Parse(txtOmega62.Text.ToString())).ToString();
            if (txtUgljikohidrati2.Text.Equals(""))
            {
                txtUgljikohidrati2.Text = "0";
            }
            txtUgljikohidrati2.Text = (ugljikohidratiNamirnice + float.Parse(txtUgljikohidrati2.Text.ToString())).ToString();
            if (txtVlakna2.Text.Equals(""))
            {
                txtVlakna2.Text = "0";
            }
            txtVlakna2.Text = (vlaknaNamirnice + float.Parse(txtVlakna2.Text.ToString())).ToString();

            //CompareToLimit();

        }

        private void CompareToLimit()
        {
            if (float.Parse(textBoxBjelancevine.Text.ToString()) <= 0)
            {
                MessageBox.Show("Bjelancevine iznad ogranicenja!");
            }
            if (float.Parse(textBoxMasti.Text.ToString()) <= 0)
            {
                MessageBox.Show("Masti iznad ogranicenja!");
            }
            if (float.Parse(textBoxOmega3.Text.ToString()) <= 0)
            {
                MessageBox.Show("Omega3 iznad ogranicenja!");
            }
            if (float.Parse(textBoxOmega6.Text.ToString()) <= 0)
            {
                MessageBox.Show("Omega6 iznad ogranicenja!");
            }
            if (float.Parse(textBoxUgljikohidrati.Text.ToString()) <= 0)
            {
                MessageBox.Show("Ugljikohidrati iznad ogranicenja!");
            }
            if (float.Parse(textBoxVlakna.Text.ToString()) <= 0)
            {
                MessageBox.Show("Vlakna iznad ogranicenja!");
            }
        }

        private static void SendEmail(object sender, EventArgs e)
        {
            string path = "Povijest.txt";
            /*DateTime date1 = new DateTime(2019, 8, 20, 16, 17, 0);
            DateTime date2 = new DateTime(2019, 9, 1, 0, 0, 0);
            DateTime date3 = new DateTime(2019, 10, 1, 0, 0, 0);
            DateTime date4 = new DateTime(2019, 11, 1, 0, 0, 0);
            DateTime date5 = new DateTime(2019, 12, 1, 0, 0, 0);
            DateTime date6 = new DateTime(2020, 1, 1, 0, 0, 0);
            DateTime date7 = new DateTime(2020, 2, 1, 0, 0, 0);
            DateTime date8 = new DateTime(2020, 3, 1, 0, 0, 0);
            DateTime date9 = new DateTime(2020, 4, 1, 0, 0, 0);
            DateTime date10 = new DateTime(2020, 5, 1, 0, 0, 0);
            DateTime date11 = new DateTime(2020, 6, 1, 0, 0, 0);
            DateTime date12 = new DateTime(2020, 7, 1, 0, 0, 0);*/
            DateTime date = DateTime.Now;
            String month = date.Month.ToString();
            String day = date.Day.ToString();
            String hour = date.Hour.ToString();
            String minute = date.Minute.ToString();
            String second = date.Second.ToString();

            //if (date1.Month == date2.Month || date1.Month == date2.Month || date1.Month == date3.Month || date1.Month == date4.Month || date1.Month == date5.Month || date1.Month == date6.Month || date1.Month == date7.Month || date1.Month == date8.Month || date1.Month == date9.Month || date1.Month == date10.Month || date1.Month == date11.Month || date1.Month == date12.Month || date1.Month == date1.Month && date1.Day == date1.Day && date1.Hour == date1.Hour && date1.Minute == date1.Minute && date1.Second == date1.Second)
            if ((month == "1" || month == "2" || month == "3" || month == "4" || month == "5" || month == "6" || month == "7" || month == "8" || month == "9" || month == "10" || month == "11" || month == "12") && day == "1")//&& hour == "0" && minute == "25" )//&& second == "30")
            {

                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587);
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("neznam0070@gmail.com");
                mailMessage.To.Add(new MailAddress(Email));
                if (Email2 != " ")
                {
                    mailMessage.To.Add(new MailAddress(Email2));
                }
                mailMessage.Subject = "Mjesećno izvješće" + date.Year.ToString() + "-" + month + "-" + day;
                mailMessage.Body = "";
                mailMessage.Attachments.Add(new Attachment(path));

                smtpServer.Host = "smtp.gmail.com";
                smtpServer.Port = 587;//465
                smtpServer.UseDefaultCredentials = false;
                smtpServer.EnableSsl = true;
                smtpServer.Credentials = new System.Net.NetworkCredential("neznam0070@gmail.com", "Automobil007");

                smtpServer.Send(mailMessage);

                mailMessage.Dispose();
                string sourcePath = path;
                string destPath = "Povijest\\MjesecnoIzvjesce" + date.Year.ToString() + month + ".txt";
                Directory.CreateDirectory("Povijest");
                File.Copy(sourcePath, destPath);
                File.Create(path).Close();
                File.WriteAllText("Povijest.txt", String.Empty);
                StreamWriter brisi = new StreamWriter(sourcePath);
                brisi.Flush();
                brisi.Close();
                //File.Delete(sourcePath);

                //File.WriteAllText(sourcePath, string.Empty);
                /*File.Delete(path);
                StreamWriter streamWriter = new StreamWriter(path);
                streamWriter.Close();*/


                //MessageBox.Show("Uspješno poslano!!");
                /* mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                smtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string userstate = "Sending...";
                smtpServer.SendAsync(mailMessage, userstate);*/
            }
        }



        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Send cancelled: " + e.UserState);
            }
            else if (e.Error != null)
            {
                MessageBox.Show(e.UserState + " " + e.Error);
            }
            else
            {
                MessageBox.Show("Successfully sended!!");
            }
        }

        private void RemoveFromTotal(float kalorijeNamirnice, float bjelancevineNamirnice, float mastiNamirnice, float omega3Namirnice, float omega6Namirnice, float ugljikohidratiNamirnice, float vlaknaNamirnice)
        {

            txtKalorije2.Text = (float.Parse(txtKalorije2.Text.ToString()) - kalorijeNamirnice).ToString();

            txtBjelancevine2.Text = (float.Parse(txtBjelancevine2.Text.ToString()) - bjelancevineNamirnice).ToString();

            txtMasti2.Text = (float.Parse(txtMasti2.Text.ToString()) - mastiNamirnice).ToString();

            txtOmega32.Text = (float.Parse(txtOmega32.Text.ToString()) - omega3Namirnice).ToString();

            txtOmega62.Text = (float.Parse(txtOmega62.Text.ToString()) - omega6Namirnice).ToString();

            txtUgljikohidrati2.Text = (float.Parse(txtUgljikohidrati2.Text.ToString()) - ugljikohidratiNamirnice).ToString();

            txtVlakna2.Text = (float.Parse(txtVlakna2.Text.ToString()) - vlaknaNamirnice).ToString();

            //CompareToLimit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void posaljiOdmahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "Povijest.txt";

            DateTime date = DateTime.Now;
            String month = date.Month.ToString();
            String day = date.Day.ToString();
            String hour = date.Hour.ToString();
            String minute = date.Minute.ToString();
            String second = date.Second.ToString();

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com", 587);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("neznam0070@gmail.com");
            mailMessage.To.Add(new MailAddress(Email));
            if (Email2 != " ")
            {
                mailMessage.To.Add(new MailAddress(Email2));
            }
            mailMessage.Subject = "Mjesećno izvješće" + date.Year.ToString() + "-" + month + "-" + day;
            mailMessage.Body = "";
            mailMessage.Attachments.Add(new Attachment(path)) ;

            smtpServer.Host = "smtp.gmail.com";
            smtpServer.Port = 587;//465
            smtpServer.UseDefaultCredentials = false;
            smtpServer.EnableSsl = true;
            smtpServer.Credentials = new System.Net.NetworkCredential("neznam0070@gmail.com", "Automobil007");

            smtpServer.Send(mailMessage);
            MessageBox.Show("Uspješno poslano!");
            mailMessage.Dispose();

            string sourcePath = path;
            string destPath = "Povijest\\MjesecnoIzvjesce" + date.Year.ToString() + "-" + month + "-" + day + ".txt";
            Directory.CreateDirectory("Povijest");
            File.Copy(sourcePath, destPath);
            File.Create(path).Close();
            File.WriteAllText("Povijest.txt", String.Empty);
            StreamWriter brisi = new StreamWriter(sourcePath);
            brisi.Flush();
            brisi.Close();
        
    //System.IO.File.WriteAllText(path, string.Empty);
    /*File.Copy(sourcePath, destPath);
    File.WriteAllText("Povijest.txt", String.Empty);
    StreamWriter brisi = new StreamWriter(sourcePath);
    brisi.Flush();
    brisi.Close();*/
}
        


        private void listBoxSveNamirnice_MouseMove(object sender, MouseEventArgs e)
        {
            string strTip = "";

            //Get the item
            string index = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.GetItemText(e.Y));
            string index2 = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.Location);
            int nIdx = listBoxSveNamirnice.IndexFromPoint(e.Location);

            if ((nIdx >= 0) && (nIdx < listBoxSveNamirnice.Items.Count))

                strTip = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.SelectedItem);
                //strTip = listBoxSveNamirnice.GetItemText(nIdx);
                //strTip = listBoxSveNamirnice.Items[nIdx].ToString();
            toolTip6.SetToolTip(listBoxSveNamirnice, strTip);
        }

       

        public void provjeri()
        {
            string statusParametara = "StatusParametara.txt";
            string putanjaUvjeta = "Uvjet.txt";
            string trenutniDan = DateTime.Now.Day.ToString();
            string trenutniMjesec = DateTime.Now.Month.ToString();
            string trenutnaGodina = DateTime.Now.Year.ToString();
            string trenutniDatum = trenutniDan + "." + trenutniMjesec + "." + trenutnaGodina + ".";
            StreamReader streamReaderUvjet = new StreamReader(putanjaUvjeta);
            if (streamReaderUvjet.ReadLine() != trenutniDatum)
            {
                streamReaderUvjet.Close();
                File.WriteAllText(putanjaUvjeta, trenutniDatum);
                StreamReader streamReader = new StreamReader("podaci.txt");
                string tempBjelancevine = streamReader.ReadLine();
                string tempMasti = streamReader.ReadLine();
                string tempOmega3 = streamReader.ReadLine();
                string tempOmega6 = streamReader.ReadLine();
                string tempUgljikohidrati = streamReader.ReadLine();
                string tempVlakna = streamReader.ReadLine();
                streamReader.Close();

                StreamWriter streamWriterUvjet = new StreamWriter(statusParametara);
                streamWriterUvjet.WriteLine(tempBjelancevine);
                streamWriterUvjet.WriteLine(tempMasti);
                streamWriterUvjet.WriteLine(tempOmega3);
                streamWriterUvjet.WriteLine(tempOmega6);
                streamWriterUvjet.WriteLine(tempUgljikohidrati);
                streamWriterUvjet.WriteLine(tempVlakna);
                streamWriterUvjet.Close();
            }
            StreamReader streamReaderProvjera = new StreamReader(statusParametara);
            textBoxBjelancevine.Text = streamReaderProvjera.ReadLine();
            textBoxMasti.Text = streamReaderProvjera.ReadLine();
            textBoxOmega3.Text = streamReaderProvjera.ReadLine();
            textBoxOmega6.Text = streamReaderProvjera.ReadLine();
            textBoxUgljikohidrati.Text = streamReaderProvjera.ReadLine();
            textBoxVlakna.Text = streamReaderProvjera.ReadLine();
            streamReaderProvjera.Close();
        }
        public void oduzmi()
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            string statusParametara = "StatusParametara.txt";
            StreamReader streamReaderStatus = new StreamReader(statusParametara);
            float tempBjelancevine = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            float tempMasti = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            float tempOmega3 = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            float tempOmega6 = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            float tempUgljikohidrati = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            float tempVlakna = float.Parse(streamReaderStatus.ReadLine(), NumberStyles.Any, ci);
            streamReaderStatus.Close();
            /*float tempBjelancevine = float.Parse(textBoxBjelancevine.Text) - float.Parse(txtBjelancevine2.Text);
            float tempMasti = float.Parse(textBoxMasti.Text) - float.Parse(txtMasti2.Text);
            float tempOmega3 = float.Parse(textBoxOmega3.Text) - float.Parse(txtOmega32.Text);
            float tempOmega6 = float.Parse(textBoxOmega6.Text) - float.Parse(txtOmega62.Text);
            float tempUgljikohidrati = float.Parse(textBoxUgljikohidrati.Text) - float.Parse(txtUgljikohidrati2.Text);
            float tempVlakna = float.Parse(textBoxVlakna.Text) - float.Parse(txtVlakna2.Text);*/

            string tempBjelancevineString = /*tempBjelancevine.ToString()*/(tempBjelancevine - float.Parse(txtBjelancevine2.Text, NumberStyles.Any, ci)).ToString();
            string tempMastiString = /*tempMasti.ToString() ; */(tempMasti - float.Parse(txtMasti2.Text, NumberStyles.Any, ci)).ToString();
            string tempOmega3String = /*tempOmega3.ToString(); */ (tempOmega3 - float.Parse(txtOmega32.Text, NumberStyles.Any, ci)).ToString();
            string tempOmega6String = /*tempOmega6.ToString(); */ (tempOmega6 - float.Parse(txtOmega62.Text, NumberStyles.Any, ci)).ToString();
            string tempUgljikohidratiString = /*tempUgljikohidrati.ToString(); */ (tempUgljikohidrati - float.Parse(txtUgljikohidrati2.Text, NumberStyles.Any, ci)).ToString();
            string tempVlaknaString = /*tempVlakna.ToString(); */ (tempVlakna - float.Parse(txtVlakna2.Text, NumberStyles.Any, ci)).ToString();
            StreamWriter streamWriterTrenutno = new StreamWriter(statusParametara);
            streamWriterTrenutno.WriteLine(tempBjelancevineString);
            streamWriterTrenutno.WriteLine(tempMastiString);
            streamWriterTrenutno.WriteLine(tempOmega3String);
            streamWriterTrenutno.WriteLine(tempOmega6String);
            streamWriterTrenutno.WriteLine(tempUgljikohidratiString);
            streamWriterTrenutno.WriteLine(tempVlaknaString);
            streamWriterTrenutno.Close();
        }
       
        private void kartica_dodaj()
        {
           
            FormDodajNovi formDodajNovi = new FormDodajNovi();
            formDodajNovi.Owner = this;
            formDodajNovi.Show();
            
        }
        private void kartica_izmjeni()
        {
            Namirnica = listBoxSveNamirnice.GetItemText(listBoxSveNamirnice.SelectedItem);
            FormIzmjeni formIzmjeni = new FormIzmjeni();
            formIzmjeni.Owner = this;
            formIzmjeni.Show();
        }
        
        private void unesiEmail()
        {
            FormEmail formEmail = new FormEmail();
            formEmail.Owner = this;
            formEmail.Show();
        }
        #endregion /Methods   
    }
}
