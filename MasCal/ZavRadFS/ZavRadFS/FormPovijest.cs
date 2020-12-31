using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZavRadFS
{
    public partial class FormPovijest : Form
    {
        public FormPovijest()
        {
            InitializeComponent();

            string path = "Povijest.txt";
            StreamReader streamReader = new StreamReader(path);
            txtPovijest.Text = streamReader.ReadToEnd();
            streamReader.Close();
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPovijest_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void FormPovijest_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void txtPovijest_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnObrisiOznaceno_Click(object sender, EventArgs e)
        {

            int a = txtPovijest.SelectionLength;
            txtPovijest.Text = txtPovijest.Text.Remove(txtPovijest.SelectionStart, a);
            StreamWriter streamWriter = new StreamWriter("Povijest.txt");
            streamWriter.Write(txtPovijest.Text);
            streamWriter.Close();
        }
    }
}
