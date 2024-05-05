namespace AyseNurProje
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_satıs = new System.Windows.Forms.Button();
            this.btn_cks = new System.Windows.Forms.Button();
            this.btn_genel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_satıs
            // 
            this.btn_satıs.Location = new System.Drawing.Point(442, 306);
            this.btn_satıs.Name = "btn_satıs";
            this.btn_satıs.Size = new System.Drawing.Size(134, 27);
            this.btn_satıs.TabIndex = 1;
            this.btn_satıs.Text = "Satış İşlemleri";
            this.btn_satıs.UseVisualStyleBackColor = true;
            this.btn_satıs.Click += new System.EventHandler(this.btn_satıs_Click);
            // 
            // btn_cks
            // 
            this.btn_cks.Location = new System.Drawing.Point(761, 349);
            this.btn_cks.Name = "btn_cks";
            this.btn_cks.Size = new System.Drawing.Size(100, 22);
            this.btn_cks.TabIndex = 5;
            this.btn_cks.Text = "Çıkış";
            this.btn_cks.UseVisualStyleBackColor = true;
            this.btn_cks.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_genel
            // 
            this.btn_genel.Location = new System.Drawing.Point(266, 306);
            this.btn_genel.Name = "btn_genel";
            this.btn_genel.Size = new System.Drawing.Size(134, 27);
            this.btn_genel.TabIndex = 6;
            this.btn_genel.Text = "Genel İşlemler";
            this.btn_genel.UseVisualStyleBackColor = true;
            this.btn_genel.Click += new System.EventHandler(this.btn_genel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(865, 373);
            this.Controls.Add(this.btn_genel);
            this.Controls.Add(this.btn_cks);
            this.Controls.Add(this.btn_satıs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pet Shopping";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_satıs;
        private System.Windows.Forms.Button btn_cks;
        private System.Windows.Forms.Button btn_genel;
    }
}

