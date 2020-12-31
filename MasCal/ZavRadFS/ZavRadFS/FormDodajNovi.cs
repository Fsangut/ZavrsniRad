using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZavRadFS
{
    public partial class FormDodajNovi : Form
    {
        public FormDodajNovi()
        {
            InitializeComponent();
            string cn_string = Properties.Settings.Default.dblNamirniceConnectionString.ToString();
            //string cn_string = "Server=(LocalDB)\\MSSQLLocalDb;Database=dblNamirnice;User ID=DESKTOP-I49ACCI\\Šangut;pwd=''";
            //----< Database >

            string sql_Text = "SELECT Namirnica FROM tbl_Namirnice";

            SqlConnection Conn = new SqlConnection(cn_string);
            SqlCommand Comm1 = new SqlCommand(sql_Text, Conn);
            /*Conn.Open();
            SqlDataReader DR1 = Comm1.ExecuteReader();
            if (DR1.Read())
            {
               txtNaziv2.Text = DR1.GetValue(0).ToString();
            }
            Conn.Close();*/
            
            
        }
        #region  Methods
        public void AddToDatabase()
        {
            if (txtKalorije2.Text=="")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtGramiUnos.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtMasti2.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtNaziv2.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtUgljikohidrati2.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtVlakna2.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtBjelancevine2.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtOmega32.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            if (txtOmega62.Text == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }

            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";


            string Naziv = txtNaziv2.Text;
            string GramiUnos = float.Parse(txtGramiUnos.Text, NumberStyles.Any, ci).ToString();
            string Kalorije = float.Parse(txtKalorije2.Text,NumberStyles.Any,ci).ToString();
            string Masti = float.Parse(txtMasti2.Text, NumberStyles.Any, ci).ToString();
            string Ugljikohidrati = float.Parse(txtUgljikohidrati2.Text, NumberStyles.Any, ci).ToString();
            string Vlakna = float.Parse(txtVlakna2.Text, NumberStyles.Any, ci).ToString();
            string Bjelančevine = float.Parse(txtBjelancevine2.Text, NumberStyles.Any, ci).ToString();
            string Omega3 = float.Parse(txtOmega32.Text, NumberStyles.Any, ci).ToString();
            string Omega6 = float.Parse(txtOmega62.Text, NumberStyles.Any, ci).ToString();

            var regexItem = new Regex("^[a-zA-Z]*$");
            var regexItem2 = new Regex("^[0-9]*$");
            foreach(char c in Kalorije)
            {
                if(c.ToString() == "" || regexItem.IsMatch(c.ToString()))
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Masti)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in GramiUnos)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()))
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Ugljikohidrati)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Vlakna)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Bjelančevine)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Omega3)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Omega6)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Naziv)
            {
                if (c.ToString() == "" || regexItem2.IsMatch(c.ToString()))
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            if (Naziv == "" || GramiUnos == "" || Kalorije == "" || Masti == "" || Ugljikohidrati == "" || Vlakna == "" || Bjelančevine == "" || Omega3 == "" || Omega6 == ""|| regexItem.IsMatch(Kalorije)|| regexItem.IsMatch(GramiUnos) || regexItem.IsMatch(Masti) || regexItem.IsMatch(Ugljikohidrati) || regexItem.IsMatch(Vlakna) || regexItem.IsMatch(Bjelančevine) || regexItem.IsMatch(Omega3) || regexItem.IsMatch(Omega6) || regexItem2.IsMatch(Naziv))
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            string cn_string = Properties.Settings.Default.dblNamirniceConnectionString;
            //string cn_string = "Server=(LocalDB)\\MSSQLLocalDb;Database=dblNamirnice;User ID=DESKTOP-I49ACCI\\Šangut;pwd=''";

            SqlConnection cn_connection = new SqlConnection(cn_string);
            
            string sql_Text = "INSERT INTO tbl_Namirnice (Namirnica, Kalorije, Bjelančevine, Masti, Omega3, Omega6, Ugljikohidrati, Vlakna) VALUES (@Namirnica, @Kalorije, @Bjelančevine, @Masti, @Omega3, @Omega6, @Ugljikohidrati, @Vlakna)";

            SqlCommand cmdCommand = new SqlCommand(sql_Text, cn_connection);
            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }
            float KalorijeFloat = (float)System.Math.Round(float.Parse(Kalorije), 2);


            cmdCommand.Parameters.AddWithValue("@Namirnica", Naziv);
            cmdCommand.Parameters.AddWithValue("@Kalorije", (float)System.Math.Round(float.Parse(Kalorije) / float.Parse(GramiUnos),4));
            cmdCommand.Parameters.AddWithValue("@Masti", (float)System.Math.Round(float.Parse(Masti) / float.Parse(GramiUnos), 4));
            cmdCommand.Parameters.AddWithValue("@Ugljikohidrati", (float)System.Math.Round(float.Parse(Ugljikohidrati) / float.Parse(GramiUnos), 4));
            cmdCommand.Parameters.AddWithValue("@Vlakna", (float)System.Math.Round(float.Parse(Vlakna) / float.Parse(GramiUnos), 4));
            cmdCommand.Parameters.AddWithValue("@Bjelančevine", (float)System.Math.Round(float.Parse(Bjelančevine) / float.Parse(GramiUnos), 4));
            cmdCommand.Parameters.AddWithValue("@Omega3", (float)System.Math.Round(float.Parse(Omega3) / float.Parse(GramiUnos), 4));
            cmdCommand.Parameters.AddWithValue("@Omega6", (float)System.Math.Round(float.Parse(Omega6) / float.Parse(GramiUnos), 4));
            
            int test = cmdCommand.ExecuteNonQuery();

            cn_connection.Close();
            Close();
        }

        #endregion
        private void btnSpremi_Click(object sender, EventArgs e)
        {
            AddToDatabase();
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDodajNovi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void FormDodajNovi_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void lblBjelancevine2_Click(object sender, EventArgs e)
        {

        }

        private void lblVlakna2_Click(object sender, EventArgs e)
        {

        }

        private void lblUgljikohidrati2_Click(object sender, EventArgs e)
        {

        }

        private void lblMasti2_Click(object sender, EventArgs e)
        {

        }

        private void lblKalorije_Click(object sender, EventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
