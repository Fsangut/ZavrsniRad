using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZavRadFS
{
    public partial class FormPromijeniGramazu : Form
    {
        Form1 ownerForm;
        public FormPromijeniGramazu(Form1 form1)
        {
            InitializeComponent();
            ownerForm = form1;
        }

        private void buttonPonisti_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPromijeniGramazu_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;
        }

        private void FormPromijeniGramazu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void buttonSpremi_Click(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[a-zA-Z]*$");
            foreach (char c in textBoxGrami.Text)
            {
                if (c.ToString() == "" || regexItem.IsMatch(c.ToString()))
                {
                    MessageBox.Show("Molim, popunite sva polja s odgovarajućim vrijednostima.");
                    return;
                }
            }

            if (textBoxGrami.Text.Equals(""))
            {
                return;
            }
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            float grami = float.Parse(textBoxGrami.Text, NumberStyles.Any, ci);
            ownerForm.PromijeniGramazu(grami);
            Close();
        }
    }
}
