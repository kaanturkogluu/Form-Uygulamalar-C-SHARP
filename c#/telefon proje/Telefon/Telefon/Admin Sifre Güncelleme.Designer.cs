﻿
namespace Telefon
{
    partial class Admin_Sifre_Güncelleme
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
            this.txt_Ad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_mevcut_sifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txT_yeni_sifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_sifre_tekrar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Ad
            // 
            this.txt_Ad.Location = new System.Drawing.Point(124, 32);
            this.txt_Ad.Name = "txt_Ad";
            this.txt_Ad.Size = new System.Drawing.Size(100, 20);
            this.txt_Ad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "AD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mevcut Şifre";
            // 
            // txt_mevcut_sifre
            // 
            this.txt_mevcut_sifre.Location = new System.Drawing.Point(124, 78);
            this.txt_mevcut_sifre.Name = "txt_mevcut_sifre";
            this.txt_mevcut_sifre.Size = new System.Drawing.Size(100, 20);
            this.txt_mevcut_sifre.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Yeni Şifre";
            // 
            // txT_yeni_sifre
            // 
            this.txT_yeni_sifre.Location = new System.Drawing.Point(124, 122);
            this.txT_yeni_sifre.Name = "txT_yeni_sifre";
            this.txT_yeni_sifre.Size = new System.Drawing.Size(100, 20);
            this.txT_yeni_sifre.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Yeni Şifre Tekrar";
            // 
            // txt_sifre_tekrar
            // 
            this.txt_sifre_tekrar.Location = new System.Drawing.Point(124, 159);
            this.txt_sifre_tekrar.Name = "txt_sifre_tekrar";
            this.txt_sifre_tekrar.Size = new System.Drawing.Size(100, 20);
            this.txt_sifre_tekrar.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Onayla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Admin_Sifre_Güncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(306, 275);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_sifre_tekrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txT_yeni_sifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_mevcut_sifre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Ad);
            this.Name = "Admin_Sifre_Güncelleme";
            this.Text = "Admin_Sifre_Güncelleme";
            this.Load += new System.EventHandler(this.Admin_Sifre_Güncelleme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Ad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_mevcut_sifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txT_yeni_sifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_sifre_tekrar;
        private System.Windows.Forms.Button button1;
    }
}