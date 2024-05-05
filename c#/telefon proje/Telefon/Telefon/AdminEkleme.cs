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
    public partial class AdminEkleme : Form
    {
        public AdminEkleme()
        {
            InitializeComponent();
        }
        VeriTabaniAdmin vt_Admin = new VeriTabaniAdmin(); 
        private void button1_Click(object sender, EventArgs e)
        {
            //şifreyi kontrol edip , hatalı ise temizleme
            if (sifreKontrol(txt_sifre.Text,txt_sifre_tekrar.Text))
            {
                // kullanıcı adı kullanılıyor mu kontrolü eğe var ise true değeri dönecek  
                if (!vt_Admin.adminKullaniciAdiKontrol(txt_kul_adi.Text))
                {

                    if (vt_Admin.adminReferansKontrol(txt_referans.Text))
                    {   // yeni ref numara kontrol

                        if (txt_yeni_Ref.TextLength<10)
                        {
                            MessageBox.Show("Refernas Almak için 10 haneli rakam giriniz");
                        }
                        else
                        {
                            string[] adminInfo = { txt_kul_adi.Text, txt_sifre.Text, txt_yeni_Ref.Text, txt_referans.Text,admindegeri.ToString() };
                            vt_Admin.adminEkle(adminInfo);
                            MessageBox.Show("Kayit İşlemi Başarı ile yapıldı");
                            this.Close();
                        }
                     

                    }
                    else
                    {
                        MessageBox.Show("Girilen Kayıt Yapan Adminin Referans Numarası Hatalıdır");
                        temizle();
                       
                       
                    }

                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Zaten Alınmış", "Admin Kullanıcı Adı Hatası");
                    temizle();
                   
                   
                }
             

            }
            else
            {
                temizle();
                
              

            }

        }

        // hata olması halinde txtboxları temizlemk için metot 
        private void temizle()
        {
            txt_kul_adi.Clear();
            txt_referans.Clear();
            txt_sifre.Clear();
            txt_sifre_tekrar.Clear();
            txt_yeni_Ref.Clear();
        }

        //sifreler uyusuyor mu kontrolü 
        private bool sifreKontrol(string sifre, string sifre_tekrar)
        {
            bool sonuc = false; 
          if(sifre== sifre_tekrar)
            {
                sonuc = true; 

            }else
            {
                MessageBox.Show("Şifreler Uyuşmuyor ","Şifre Hatası");
            }
            return sonuc; 
        }

        private void txt_referans_TextChanged(object sender, EventArgs e)
        {

            txt_referans.MaxLength = 10; 
        }

        private void txt_yeni_Ref_TextChanged(object sender, EventArgs e)
        {

            txt_yeni_Ref.MaxLength = 10;
            
        }

        private void AdminEkleme_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }
        bool admindegeri = false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            admindegeri = true;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            admindegeri = false;
        }
    }
}
