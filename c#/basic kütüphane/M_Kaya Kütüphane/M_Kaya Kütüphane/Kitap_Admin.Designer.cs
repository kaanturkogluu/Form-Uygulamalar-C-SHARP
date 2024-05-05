namespace M_Kaya_Kütüphane
{
    partial class Kitap_Admin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_tarih = new System.Windows.Forms.Label();
            this.lbl_isim = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Verilen_Kitaplar = new System.Windows.Forms.Button();
            this.btn_Kitap_hasar = new System.Windows.Forms.Button();
            this.btn_Mevcut_Kitaplar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_Kitap_KAyit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbl_tarih);
            this.groupBox1.Controls.Add(this.lbl_isim);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Admin ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(259, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Çıkış ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refereans Görüntüle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_tarih
            // 
            this.lbl_tarih.AutoSize = true;
            this.lbl_tarih.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_tarih.Location = new System.Drawing.Point(101, 26);
            this.lbl_tarih.Name = "lbl_tarih";
            this.lbl_tarih.Size = new System.Drawing.Size(25, 15);
            this.lbl_tarih.TabIndex = 2;
            this.lbl_tarih.Text = "- - -";
            // 
            // lbl_isim
            // 
            this.lbl_isim.AutoSize = true;
            this.lbl_isim.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_isim.Location = new System.Drawing.Point(23, 26);
            this.lbl_isim.Name = "lbl_isim";
            this.lbl_isim.Size = new System.Drawing.Size(72, 15);
            this.lbl_isim.TabIndex = 1;
            this.lbl_isim.Text = "Giriş Saati : ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.groupBox2.Controls.Add(this.btn_Verilen_Kitaplar);
            this.groupBox2.Controls.Add(this.btn_Kitap_hasar);
            this.groupBox2.Controls.Add(this.btn_Mevcut_Kitaplar);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btn_Kitap_KAyit);
            this.groupBox2.Location = new System.Drawing.Point(12, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlemler";
            // 
            // btn_Verilen_Kitaplar
            // 
            this.btn_Verilen_Kitaplar.Location = new System.Drawing.Point(582, 33);
            this.btn_Verilen_Kitaplar.Name = "btn_Verilen_Kitaplar";
            this.btn_Verilen_Kitaplar.Size = new System.Drawing.Size(105, 79);
            this.btn_Verilen_Kitaplar.TabIndex = 5;
            this.btn_Verilen_Kitaplar.Text = "Teslim Beklenen";
            this.btn_Verilen_Kitaplar.UseVisualStyleBackColor = true;
            // 
            // btn_Kitap_hasar
            // 
            this.btn_Kitap_hasar.Location = new System.Drawing.Point(431, 33);
            this.btn_Kitap_hasar.Name = "btn_Kitap_hasar";
            this.btn_Kitap_hasar.Size = new System.Drawing.Size(100, 79);
            this.btn_Kitap_hasar.TabIndex = 4;
            this.btn_Kitap_hasar.Text = "Kitap Hasar";
            this.btn_Kitap_hasar.UseVisualStyleBackColor = true;
            // 
            // btn_Mevcut_Kitaplar
            // 
            this.btn_Mevcut_Kitaplar.Location = new System.Drawing.Point(26, 33);
            this.btn_Mevcut_Kitaplar.Name = "btn_Mevcut_Kitaplar";
            this.btn_Mevcut_Kitaplar.Size = new System.Drawing.Size(103, 79);
            this.btn_Mevcut_Kitaplar.TabIndex = 3;
            this.btn_Mevcut_Kitaplar.Text = "Mevcut Kitaplar";
            this.btn_Mevcut_Kitaplar.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(802, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 79);
            this.button4.TabIndex = 1;
            this.button4.Text = "Kayit Sil";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_Kitap_KAyit
            // 
            this.btn_Kitap_KAyit.Location = new System.Drawing.Point(291, 33);
            this.btn_Kitap_KAyit.Name = "btn_Kitap_KAyit";
            this.btn_Kitap_KAyit.Size = new System.Drawing.Size(89, 79);
            this.btn_Kitap_KAyit.TabIndex = 0;
            this.btn_Kitap_KAyit.Text = "Kitap Kayit";
            this.btn_Kitap_KAyit.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(933, 126);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Öğrenciler";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(158, 29);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 79);
            this.button11.TabIndex = 5;
            this.button11.Text = "Kayit Sil";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(26, 29);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 79);
            this.button5.TabIndex = 4;
            this.button5.Text = "Öğrenci Kayit";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(734, 29);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(100, 79);
            this.button10.TabIndex = 3;
            this.button10.Text = "Hasar Raporu";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // Kitap_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Kitap_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap_Admin";
            this.Load += new System.EventHandler(this.Kitap_Admin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_tarih;
        private System.Windows.Forms.Label lbl_isim;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Verilen_Kitaplar;
        private System.Windows.Forms.Button btn_Kitap_hasar;
        private System.Windows.Forms.Button btn_Mevcut_Kitaplar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_Kitap_KAyit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button5;
    }
}