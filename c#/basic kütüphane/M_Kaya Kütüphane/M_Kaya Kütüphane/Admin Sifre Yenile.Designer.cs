namespace M_Kaya_Kütüphane
{
    partial class Admin_Sifre_Yenile
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
            this.txt_güvenlikSorusu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_adminisim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cevap = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_cevap = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin Ad : ";
            // 
            // txt_güvenlikSorusu
            // 
            this.txt_güvenlikSorusu.Location = new System.Drawing.Point(95, 122);
            this.txt_güvenlikSorusu.Name = "txt_güvenlikSorusu";
            this.txt_güvenlikSorusu.ReadOnly = true;
            this.txt_güvenlikSorusu.Size = new System.Drawing.Size(100, 20);
            this.txt_güvenlikSorusu.TabIndex = 15;
            this.txt_güvenlikSorusu.Visible = false;
            this.txt_güvenlikSorusu.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(4, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Güvenlik Sorusu";
            this.label2.Visible = false;
            // 
            // txt_adminisim
            // 
            this.txt_adminisim.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_adminisim.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txt_adminisim.Location = new System.Drawing.Point(95, 79);
            this.txt_adminisim.Name = "txt_adminisim";
            this.txt_adminisim.Size = new System.Drawing.Size(100, 20);
            this.txt_adminisim.TabIndex = 0;
            this.txt_adminisim.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cevap : ";
            this.label3.Visible = false;
            // 
            // txt_cevap
            // 
            this.txt_cevap.Location = new System.Drawing.Point(95, 159);
            this.txt_cevap.Name = "txt_cevap";
            this.txt_cevap.Size = new System.Drawing.Size(100, 20);
            this.txt_cevap.TabIndex = 1;
            this.txt_cevap.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Sorgula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Büyük Küçük Harf Duyarlilğina Dikkat Etmelisiniz ";
            // 
            // btn_cevap
            // 
            this.btn_cevap.Location = new System.Drawing.Point(109, 185);
            this.btn_cevap.Name = "btn_cevap";
            this.btn_cevap.Size = new System.Drawing.Size(75, 23);
            this.btn_cevap.TabIndex = 3;
            this.btn_cevap.Text = "Cevapla";
            this.btn_cevap.UseVisualStyleBackColor = true;
            this.btn_cevap.Click += new System.EventHandler(this.btn_cevap_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::M_Kaya_Kütüphane.Properties.Resources.istockphoto_1321309032_612x612;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Location = new System.Drawing.Point(218, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 217);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // Admin_Sifre_Yenile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(492, 251);
            this.Controls.Add(this.btn_cevap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_cevap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_adminisim);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_güvenlikSorusu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Admin_Sifre_Yenile";
            this.Text = "Admin Sifre Yenileme";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_Sifre_Yenile_FormClosed);
            this.Load += new System.EventHandler(this.Admin_Sifre_Yenile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_adminisim;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_güvenlikSorusu;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_cevap;
        private System.Windows.Forms.Button btn_cevap;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}