using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    public partial class Admin_Sifre_Güncelleme : Form
    {
        public Admin_Sifre_Güncelleme()
        {
            InitializeComponent();
        }

        // textboxları temizlemek için textbox dizisi  ileparametre  alan metot 
        public void temizle(params TextBox[] text)
        {
            foreach (TextBox item in text)
            {
                item.Clear();  

            }
        } 
        VeriTabaniAdmin vt_admin = new VeriTabaniAdmin(); 
        private void button1_Click(object sender, EventArgs e)
        {

            // kullanıcı adını kotrol ediyoruz
            if (vt_admin.adminKullaniciAdiKontrol(txt_Ad.Text))
            {

                // mevcut şifreyi kontrol ediyoruz
                if (vt_admin.adminSifresiKontrol(txt_Ad.Text, txt_mevcut_sifre.Text))
                {
                    // metot ile sifreleri karıslastırdık , dönen sonuca göre işlem yapılcak
                    if (vt_admin.sifreKarsilastir(txT_yeni_sifre.Text, txt_sifre_tekrar.Text))
                    {
                        // sifre güncelleme işlemi yapılacak
                        vt_admin.adminGuncelle(txt_Ad.Text, txT_yeni_sifre.Text);
                        temizle(txt_Ad,txt_mevcut_sifre,txt_sifre_tekrar,txT_yeni_sifre);
                        this.Close(); 


                    }
                    else
                    {
                        temizle(txt_Ad, txt_mevcut_sifre, txt_sifre_tekrar, txT_yeni_sifre);
                        MessageBox.Show("Yeni Şifreler Uyuşmuyor","Yeni Şifre");
                    }
                }
                else
                {
                    temizle(txt_Ad, txt_mevcut_sifre, txt_sifre_tekrar, txT_yeni_sifre);
                    MessageBox.Show("Girilen Şifre Sistemdeki ile Eşleşmemektedir","Mevcut Şifre");
                }
              
            }
            else
            {
                temizle(txt_Ad, txt_mevcut_sifre, txt_sifre_tekrar, txT_yeni_sifre);
                MessageBox.Show("Belirtilen Admin Sistemde Bulunamadı","Admin");
            }

          
        }

        private void Admin_Sifre_Güncelleme_Load(object sender, EventArgs e)
        {

        }
    }
}
