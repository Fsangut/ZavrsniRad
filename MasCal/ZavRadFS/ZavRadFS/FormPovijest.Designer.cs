namespace ZavRadFS
{
    partial class FormPovijest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPovijest = new System.Windows.Forms.TextBox();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnObrisiOznaceno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPovijest
            // 
            this.txtPovijest.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPovijest.Location = new System.Drawing.Point(8, 12);
            this.txtPovijest.Multiline = true;
            this.txtPovijest.Name = "txtPovijest";
            this.txtPovijest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPovijest.Size = new System.Drawing.Size(320, 381);
            this.txtPovijest.TabIndex = 0;
            this.txtPovijest.TextChanged += new System.EventHandler(this.txtPovijest_TextChanged);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnIzlaz.Location = new System.Drawing.Point(338, 370);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 23);
            this.btnIzlaz.TabIndex = 1;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnObrisiOznaceno
            // 
            this.btnObrisiOznaceno.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnObrisiOznaceno.Location = new System.Drawing.Point(338, 303);
            this.btnObrisiOznaceno.Name = "btnObrisiOznaceno";
            this.btnObrisiOznaceno.Size = new System.Drawing.Size(75, 47);
            this.btnObrisiOznaceno.TabIndex = 2;
            this.btnObrisiOznaceno.Text = "Obriši označeno";
            this.btnObrisiOznaceno.UseVisualStyleBackColor = true;
            this.btnObrisiOznaceno.Click += new System.EventHandler(this.btnObrisiOznaceno_Click);
            // 
            // FormPovijest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 411);
            this.Controls.Add(this.btnObrisiOznaceno);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.txtPovijest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPovijest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Povijest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPovijest_FormClosing);
            this.Load += new System.EventHandler(this.FormPovijest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPovijest;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnObrisiOznaceno;
    }
}