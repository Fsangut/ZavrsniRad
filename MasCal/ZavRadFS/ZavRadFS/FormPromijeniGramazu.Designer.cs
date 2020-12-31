namespace ZavRadFS
{
    partial class FormPromijeniGramazu
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
            this.buttonSpremi = new System.Windows.Forms.Button();
            this.textBoxGrami = new System.Windows.Forms.TextBox();
            this.buttonPonisti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSpremi
            // 
            this.buttonSpremi.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.buttonSpremi.Location = new System.Drawing.Point(119, 62);
            this.buttonSpremi.Name = "buttonSpremi";
            this.buttonSpremi.Size = new System.Drawing.Size(75, 23);
            this.buttonSpremi.TabIndex = 0;
            this.buttonSpremi.Text = "Spremi";
            this.buttonSpremi.UseVisualStyleBackColor = true;
            this.buttonSpremi.Click += new System.EventHandler(this.buttonSpremi_Click);
            // 
            // textBoxGrami
            // 
            this.textBoxGrami.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBoxGrami.Location = new System.Drawing.Point(13, 13);
            this.textBoxGrami.Name = "textBoxGrami";
            this.textBoxGrami.Size = new System.Drawing.Size(181, 23);
            this.textBoxGrami.TabIndex = 1;
            // 
            // buttonPonisti
            // 
            this.buttonPonisti.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.buttonPonisti.Location = new System.Drawing.Point(13, 62);
            this.buttonPonisti.Name = "buttonPonisti";
            this.buttonPonisti.Size = new System.Drawing.Size(75, 23);
            this.buttonPonisti.TabIndex = 2;
            this.buttonPonisti.Text = "Poništi";
            this.buttonPonisti.UseVisualStyleBackColor = true;
            this.buttonPonisti.Click += new System.EventHandler(this.buttonPonisti_Click);
            // 
            // FormPromijeniGramazu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 99);
            this.Controls.Add(this.buttonPonisti);
            this.Controls.Add(this.textBoxGrami);
            this.Controls.Add(this.buttonSpremi);
            this.Name = "FormPromijeniGramazu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promijeni gramažu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPromijeniGramazu_FormClosed);
            this.Load += new System.EventHandler(this.FormPromijeniGramazu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSpremi;
        private System.Windows.Forms.TextBox textBoxGrami;
        private System.Windows.Forms.Button buttonPonisti;
    }
}