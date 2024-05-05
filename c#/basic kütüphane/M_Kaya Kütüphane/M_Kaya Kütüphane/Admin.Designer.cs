namespace M_Kaya_Kütüphane
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_admin = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Giris = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tamDenetimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kütüphaneSorumlusuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreSıfırlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifremiUnuttumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.şifreyiDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapListesiniGörüntüleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_ksorumlu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txT_ksifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_admin
            // 
            this.txt_admin.Location = new System.Drawing.Point(58, 5);
            this.txt_admin.Name = "txt_admin";
            this.txt_admin.Size = new System.Drawing.Size(100, 20);
            this.txt_admin.TabIndex = 0;
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(58, 38);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(100, 20);
            this.txt_sifre.TabIndex = 1;
            this.txt_sifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Şifre ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin : ";
            // 
            // btn_Giris
            // 
            this.btn_Giris.AutoSize = true;
            this.btn_Giris.BackColor = System.Drawing.Color.Transparent;
            this.btn_Giris.BackgroundImage = global::M_Kaya_Kütüphane.Properties.Resources._lock;
            this.btn_Giris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Giris.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Giris.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Giris.Location = new System.Drawing.Point(182, 36);
            this.btn_Giris.Name = "btn_Giris";
            this.btn_Giris.Size = new System.Drawing.Size(71, 68);
            this.btn_Giris.TabIndex = 4;
            this.btn_Giris.UseVisualStyleBackColor = false;
            this.btn_Giris.Click += new System.EventHandler(this.btn_Giris_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txt_admin, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_sifre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(164, 68);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(82)))), ((int)(((byte)(76)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayarlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(462, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.BackColor = System.Drawing.Color.Coral;
            this.ayarlarToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminEkleToolStripMenuItem,
            this.şifreSıfırlaToolStripMenuItem,
            this.kitapListesiniGörüntüleToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.ayarlarToolStripMenuItem.Text = "Seçenekler";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.ayarlarToolStripMenuItem_Click);
            // 
            // adminEkleToolStripMenuItem
            // 
            this.adminEkleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.adminEkleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tamDenetimToolStripMenuItem,
            this.kütüphaneSorumlusuToolStripMenuItem});
            this.adminEkleToolStripMenuItem.Name = "adminEkleToolStripMenuItem";
            this.adminEkleToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.adminEkleToolStripMenuItem.Text = "Admin Ekle";
            // 
            // tamDenetimToolStripMenuItem
            // 
            this.tamDenetimToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tamDenetimToolStripMenuItem.Name = "tamDenetimToolStripMenuItem";
            this.tamDenetimToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.tamDenetimToolStripMenuItem.Text = "Tam Denetim";
            this.tamDenetimToolStripMenuItem.Click += new System.EventHandler(this.tamDenetimToolStripMenuItem_Click);
            // 
            // kütüphaneSorumlusuToolStripMenuItem
            // 
            this.kütüphaneSorumlusuToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kütüphaneSorumlusuToolStripMenuItem.Name = "kütüphaneSorumlusuToolStripMenuItem";
            this.kütüphaneSorumlusuToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.kütüphaneSorumlusuToolStripMenuItem.Text = "Kütüphane Sorumlusu";
            this.kütüphaneSorumlusuToolStripMenuItem.Click += new System.EventHandler(this.kütüphaneSorumlusuToolStripMenuItem_Click);
            // 
            // şifreSıfırlaToolStripMenuItem
            // 
            this.şifreSıfırlaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.şifreSıfırlaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şifremiUnuttumToolStripMenuItem,
            this.şifreyiDeğiştirToolStripMenuItem});
            this.şifreSıfırlaToolStripMenuItem.Name = "şifreSıfırlaToolStripMenuItem";
            this.şifreSıfırlaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.şifreSıfırlaToolStripMenuItem.Text = "Şifre Sıfırla";
            this.şifreSıfırlaToolStripMenuItem.Click += new System.EventHandler(this.şifreSıfırlaToolStripMenuItem_Click);
            // 
            // şifremiUnuttumToolStripMenuItem
            // 
            this.şifremiUnuttumToolStripMenuItem.Name = "şifremiUnuttumToolStripMenuItem";
            this.şifremiUnuttumToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.şifremiUnuttumToolStripMenuItem.Text = "Şifremi Unuttum ";
            this.şifremiUnuttumToolStripMenuItem.Click += new System.EventHandler(this.şifremiUnuttumToolStripMenuItem_Click);
            // 
            // şifreyiDeğiştirToolStripMenuItem
            // 
            this.şifreyiDeğiştirToolStripMenuItem.Name = "şifreyiDeğiştirToolStripMenuItem";
            this.şifreyiDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.şifreyiDeğiştirToolStripMenuItem.Text = "Şifreyi Değiştir";
            this.şifreyiDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.şifreyiDeğiştirToolStripMenuItem_Click);
            // 
            // kitapListesiniGörüntüleToolStripMenuItem
            // 
            this.kitapListesiniGörüntüleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.kitapListesiniGörüntüleToolStripMenuItem.Name = "kitapListesiniGörüntüleToolStripMenuItem";
            this.kitapListesiniGörüntüleToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.kitapListesiniGörüntüleToolStripMenuItem.Text = "Kitap Listesini Görüntüle";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(82)))), ((int)(((byte)(76)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(430, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 24);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.txt_ksorumlu, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txT_ksifre, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 121);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(164, 68);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // txt_ksorumlu
            // 
            this.txt_ksorumlu.Location = new System.Drawing.Point(64, 5);
            this.txt_ksorumlu.Name = "txt_ksorumlu";
            this.txt_ksorumlu.Size = new System.Drawing.Size(100, 20);
            this.txt_ksorumlu.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre ";
            // 
            // txT_ksifre
            // 
            this.txT_ksifre.Location = new System.Drawing.Point(64, 38);
            this.txT_ksifre.Name = "txT_ksifre";
            this.txT_ksifre.Size = new System.Drawing.Size(100, 20);
            this.txT_ksifre.TabIndex = 1;
            this.txT_ksifre.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sorumlu :";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::M_Kaya_Kütüphane.Properties.Resources._lock;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.Location = new System.Drawing.Point(182, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 68);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AnaSayfa
            // 
            this.AcceptButton = this.btn_Giris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImage = global::M_Kaya_Kütüphane.Properties.Resources.kitap11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(462, 261);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Giris);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(462, 261);
            this.MinimumSize = new System.Drawing.Size(462, 261);
            this.Name = "AnaSayfa";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnaSayga";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Giris;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifreSıfırlaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tamDenetimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kütüphaneSorumlusuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapListesiniGörüntüleToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem şifremiUnuttumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem şifreyiDeğiştirToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txt_ksorumlu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txT_ksifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox txt_admin;
    }
}

