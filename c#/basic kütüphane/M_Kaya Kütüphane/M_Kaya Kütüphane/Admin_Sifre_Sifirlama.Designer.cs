namespace M_Kaya_Kütüphane
{
    partial class Admin_Sifre_Sifirlama
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.txt_sifre_tekar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(60)))), ((int)(((byte)(68)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yeni Şifre";
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(112, 24);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(100, 20);
            this.txt_sifre.TabIndex = 1;
            this.txt_sifre.UseSystemPasswordChar = true;
            // 
            // txt_sifre_tekar
            // 
            this.txt_sifre_tekar.Location = new System.Drawing.Point(112, 64);
            this.txt_sifre_tekar.Name = "txt_sifre_tekar";
            this.txt_sifre_tekar.Size = new System.Drawing.Size(100, 20);
            this.txt_sifre_tekar.TabIndex = 3;
            this.txt_sifre_tekar.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yeni Şifre Tekrar";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::M_Kaya_Kütüphane.Properties.Resources.refresh;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(237, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 60);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Admin_Sifre_Sifirlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(60)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(385, 108);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_sifre_tekar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 147);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 147);
            this.Name = "Admin_Sifre_Sifirlama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Sifre_Sifirlama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_Sifre_Sifirlama_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_Sifre_Sifirlama_FormClosed);
            this.Enter += new System.EventHandler(this.Admin_Sifre_Sifirlama_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.TextBox txt_sifre_tekar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}