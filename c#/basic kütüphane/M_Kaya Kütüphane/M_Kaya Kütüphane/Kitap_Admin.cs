using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic; 

namespace M_Kaya_Kütüphane
{
    public partial class Kitap_Admin : Form
    {
        public Kitap_Admin()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_ = new Baglanti_İslemleri();
        Admin_İslemleri admin_ = new Admin_İslemleri();
        AnaSayfa anasayfa_ = new AnaSayfa(); 
        private void Kitap_Admin_Load(object sender, EventArgs e)
        {
            groupBox1.Text = Admin_İslemleri.Ad;
            lbl_tarih.Text = DateTime.UtcNow.ToString();



        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sifre = Interaction.InputBox("Şifrenizi Girin ", "Şİfrenizi Giriniz.");
          if(  admin_.Sfire_Kontrol("Admin", Admin_İslemleri.id)==sifre)
            {
                MessageBox.Show("Kayit İçin Kullanacaginiz Referans Numaraniz :\t"+admin_.Referans_Goster(groupBox1.Text));
            }
            else
            {
                MessageBox.Show("Yanlis Şifre Girişi");
            }


          
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
