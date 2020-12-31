namespace ZavRadFS
{
    partial class FormEmail
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
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnOdustani = new System.Windows.Forms.Button();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.checkBoxDrugiEmail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblEmail.Location = new System.Drawing.Point(81, 10);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 16);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(12, 37);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // btnOdustani
            // 
            this.btnOdustani.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnOdustani.Location = new System.Drawing.Point(12, 118);
            this.btnOdustani.Name = "btnOdustani";
            this.btnOdustani.Size = new System.Drawing.Size(75, 23);
            this.btnOdustani.TabIndex = 2;
            this.btnOdustani.Text = "Odustani";
            this.btnOdustani.UseVisualStyleBackColor = true;
            this.btnOdustani.Click += new System.EventHandler(this.btnOdustani1);
            // 
            // btnSpremi
            // 
            this.btnSpremi.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnSpremi.Location = new System.Drawing.Point(111, 118);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 3;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi1_Click);
            // 
            // txtEmail2
            // 
            this.txtEmail2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtEmail2.Location = new System.Drawing.Point(12, 66);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(174, 23);
            this.txtEmail2.TabIndex = 4;
            // 
            // checkBoxDrugiEmail
            // 
            this.checkBoxDrugiEmail.AutoSize = true;
            this.checkBoxDrugiEmail.Location = new System.Drawing.Point(51, 95);
            this.checkBoxDrugiEmail.Name = "checkBoxDrugiEmail";
            this.checkBoxDrugiEmail.Size = new System.Drawing.Size(110, 17);
            this.checkBoxDrugiEmail.TabIndex = 5;
            this.checkBoxDrugiEmail.Text = "Odobri drugi email";
            this.checkBoxDrugiEmail.UseVisualStyleBackColor = true;
            this.checkBoxDrugiEmail.CheckedChanged += new System.EventHandler(this.checkBoxDrugiEmail_CheckedChanged);
            // 
            // FormEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 152);
            this.Controls.Add(this.checkBoxDrugiEmail);
            this.Controls.Add(this.txtEmail2);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.btnOdustani);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEmail_FormClosing);
            this.Load += new System.EventHandler(this.FormEmail_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnOdustani;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.CheckBox checkBoxDrugiEmail;
    }
}