using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZavRadFS
{
    public partial class FormEmail : Form
    {

        public FormEmail()
        {
            InitializeComponent();
            string path = "Email.txt";
            StreamReader streamReader = new StreamReader(path);
            txtEmail.Text = streamReader.ReadLine();
            txtEmail2.Text = streamReader.ReadLine();
            streamReader.Close();
            string temp = txtEmail2.Text;

            if (txtEmail2.Text != " ")
            {
                txtEmail2.Enabled = true;
                checkBoxDrugiEmail.Checked = true;
                txtEmail2.Text = temp;
            }
            else
            {
                txtEmail2.Enabled = false;
                checkBoxDrugiEmail.Checked = false;
            }
        }

        private void FormEmail_Load_1(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void FormEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void btnOdustani1(object sender, EventArgs e)
        {
            Close();
        }
        private void checkBoxDrugiEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDrugiEmail.Checked == true)
            {
                txtEmail2.Enabled = true;
                txtEmail2.Text = "";
            }
            else
            {
                txtEmail2.Enabled = false;
                txtEmail2.Text = " ";
            }
        }

        private void btnSpremi1_Click(object sender, EventArgs e)
        {
            string path = "Email.txt";
            File.Delete(path);
            StreamWriter streamWriter = new StreamWriter("Email.txt");
            Form1.Email = txtEmail.Text;
            Form1.Email2 = txtEmail2.Text;
            if (checkBoxDrugiEmail.Checked == true)
            {
                if (txtEmail.Text.IndexOf("@") == -1 || txtEmail2.Text.IndexOf("@") == -1)
                {
                    MessageBox.Show("Unesi ispravan Gmail!");
                    streamWriter.Close();
                    txtEmail.Text = "";
                    txtEmail2.Text = "";
                    return;
                }
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Unesi ispravan Gmail!");
                }
            

                streamWriter.WriteLine(Form1.Email);
                streamWriter.WriteLine(Form1.Email2);
                streamWriter.Close();
                Close();
            }
            else
            {
                if (txtEmail.Text.IndexOf("@") == -1)
                {
                    MessageBox.Show("Unesi ispravan Gmail!");
                    streamWriter.Close();
                    txtEmail.Text = "";
                    txtEmail2.Text = "";
                    return;
                }
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Unesi ispravan Gmail!");
                }

                streamWriter.WriteLine(Form1.Email);
                streamWriter.WriteLine(" ");
                streamWriter.Close();
                Close();
            }
        }

        
    }
}
