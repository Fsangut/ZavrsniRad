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
    public partial class FormIzmjeni : Form
    {
        public FormIzmjeni()
        {
            InitializeComponent();

            string cn_string = Properties.Settings.Default.dblNamirniceConnectionString;
            //----< Database >

            string sql_Text = "SELECT * FROM tbl_Namirnice WHERE Namirnica = '" + Form1.Namirnica + "'";
            //string sql_Text2 = "SELECT Kalorije FROM tbl_Namirnice";
            SqlConnection Conn = new SqlConnection(cn_string);

            Conn.Open();
            SqlCommand Comm1 = new SqlCommand(sql_Text, Conn);
            using (SqlDataReader reader = Comm1.ExecuteReader())
            {
                while (reader.Read())
                {

                    txtNaziv2.Text = (reader["Namirnica"].ToString());
                    txtKalorije2.Text = (reader["Kalorije"].ToString());
                    txtBjelancevine2.Text = (reader["Bjelančevine"].ToString());
                    txtMasti2.Text = (reader["Masti"].ToString());
                    txtOmega32.Text = (reader["Omega3"].ToString());
                    txtOmega62.Text = (reader["Omega6"].ToString());
                    txtUgljikohidrati2.Text = (reader["Ugljikohidrati"].ToString());
                    txtVlakna2.Text = (reader["Vlakna"].ToString());

                }
            }
                    //SqlCommand Comm2 = new SqlCommand(sql_Text2, Conn);

            //SqlDataReader DR1 = Comm1.ExecuteReader();
            //SqlDataReader DR2 = Comm2.ExecuteReader();
            /*if (DR1.Read())
            {
                txtNaziv2.Text = DR1.GetValue(0).ToString();
            }*/
            /*if (DR2.Read())
            {
                txtKalorije2.Text = DR2.GetValue(0).ToString();
            }*/
                    Conn.Close();
        }

        private void FormIzmjeni_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void FormIzmjeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
           UpdateDatabase();
        }

        private void UpdateDatabase()
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            string Naziv = txtNaziv2.Text;
            string Kalorije = ((float)System.Math.Round(float.Parse(txtKalorije2.Text, NumberStyles.Any, ci), 4)).ToString();
            string Masti = ((float)System.Math.Round(float.Parse(txtMasti2.Text, NumberStyles.Any, ci), 4)).ToString();
            string Ugljikohidrati = ((float)System.Math.Round(float.Parse(txtUgljikohidrati2.Text, NumberStyles.Any, ci), 4)).ToString();
            string Vlakna = ((float)System.Math.Round(float.Parse(txtVlakna2.Text, NumberStyles.Any, ci), 4)).ToString();
            string Bjelančevine = ((float)System.Math.Round(float.Parse(txtBjelancevine2.Text, NumberStyles.Any, ci), 4)).ToString();
            string Omega3 = ((float)System.Math.Round(float.Parse(txtOmega32.Text, NumberStyles.Any, ci), 4)).ToString();
            string Omega6 = ((float)System.Math.Round(float.Parse(txtOmega62.Text, NumberStyles.Any, ci), 4)).ToString();

            var regexItem = new Regex("^[a-zA-Z]*$");
            var regexItem2 = new Regex("^[0-9]*$");
            if (Naziv == "" || Kalorije == "" || Masti == "" || Ugljikohidrati == "" || Vlakna == "" || Bjelančevine == "" || Omega3 == "" || Omega6 == "")
            {
                MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                return;
            }
            foreach (char c in Naziv)
            {
                if (c.ToString() == "" || regexItem2.IsMatch(c.ToString()))
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Kalorije)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()) )
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }
            foreach (char c in Masti)
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
            foreach (char c in Bjelančevine)
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
            foreach (char c in Omega6)
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






            string path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            string cn_string = Properties.Settings.Default.dblNamirniceConnectionString;

            SqlConnection cn_connection = new SqlConnection(cn_string);

            string sql_Text = "UPDATE tbl_Namirnice SET Namirnica=@Namirnica, Kalorije=@Kalorije, Bjelančevine=@Bjelančevine, Masti=@Masti, Omega3=@Omega3, Omega6=@Omega6, Ugljikohidrati=@Ugljikohidrati, Vlakna=@Vlakna WHERE Namirnica='" + Form1.Namirnica + "'";

            SqlCommand cmdCommand = new SqlCommand(sql_Text, cn_connection);
            if (cn_connection.State != ConnectionState.Open)
            {
                cn_connection.Open();
            }


            cmdCommand.Parameters.AddWithValue("@Namirnica", Naziv);
            cmdCommand.Parameters.AddWithValue("@Kalorije", (float)System.Math.Round(float.Parse(Kalorije), 4));
            cmdCommand.Parameters.AddWithValue("@Masti", (float)System.Math.Round(float.Parse(Masti), 4));
            cmdCommand.Parameters.AddWithValue("@Ugljikohidrati", (float)System.Math.Round(float.Parse(Ugljikohidrati), 4));
            cmdCommand.Parameters.AddWithValue("@Vlakna", (float)System.Math.Round(float.Parse(Vlakna), 4));
            cmdCommand.Parameters.AddWithValue("@Bjelančevine", (float)System.Math.Round(float.Parse(Bjelančevine), 4));
            cmdCommand.Parameters.AddWithValue("@Omega3", (float)System.Math.Round(float.Parse(Omega3), 4));
            cmdCommand.Parameters.AddWithValue("@Omega6", (float)System.Math.Round(float.Parse(Omega6), 4));

            int test = cmdCommand.ExecuteNonQuery();

            //----</ Database >

            //----</ Database >

            cn_connection.Close();
            Close();
        }

        private void lblPodatakNapomene_Click(object sender, EventArgs e)
        {

        }
    }
}
