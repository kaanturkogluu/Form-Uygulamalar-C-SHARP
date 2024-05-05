using System;
using System.Windows.Forms;

namespace M_Kaya_Kütüphane
{
    public partial class Sifre_Degistir : Form
    {
        public Sifre_Degistir()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_ = new Baglanti_İslemleri();

        private void Sifre_Degistir_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            MessageBox.Show("Şifre Değiştirme İşlemi " + checkBox1.Text + "için Uygulanacaktir");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked) { baglanti_.Giris_Kontrol_Admin(txt_Ad.Text, txt_sifre.Text, groupBox1); groupBox2.Enabled = false; baglanti_.idAl(txt_Ad.Text,checkBox1.Text);  }
            if (checkBox2.Checked) { baglanti_.Giris_Kontrol_Sorumlu(txt_Ad.Text, txt_sifre.Text, groupBox1); groupBox2.Enabled = false; baglanti_.idAl(txt_Ad.Text,checkBox2.Text); }
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            checkBox2.Enabled = false;
            txt_Ad.Focus(); 
           if( !checkBox1.Checked)
            {
                groupBox1.Enabled=false;
                checkBox2.Enabled = true;
                groupBox2.Enabled = false;
                txt_Ad.Clear();
                txt_sifre.Clear(); 
                

            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            checkBox1.Enabled = false;
            groupBox1.Enabled = false;
            if (!checkBox2.Checked)
            {
                checkBox1.Enabled = true;
                groupBox2.Enabled = false;
                txt_Ad.Clear();
                txt_sifre.Clear();

            }
        }

        private void btn_degistir_Click(object sender, EventArgs e)
        {
           
            
            

            
            if (txt_eskisifre.Text !="" & txt_yenisifre.Text==txt_YeniSifreTekrar.Text)
            {

                if (checkBox1.Checked)
                {
                    baglanti_.Sifreyi_Kontrol_Et(txt_eskisifre.Text, baglanti_.idAl(txt_Ad.Text,checkBox1.Text), txt_yenisifre.Text,checkBox1.Text);
                  


                }
                if (checkBox2.Checked)
                {

                    baglanti_.Sifreyi_Kontrol_Et(txt_eskisifre.Text, baglanti_.idAl(txt_Ad.Text,checkBox2.Text), txt_yenisifre.Text, checkBox2.Text); 

                }
             
               
               
               
            }
            else
            {
                MessageBox.Show("Alanlarin Doldurulmasi Zorunludur","Eksik Veri");
            }
            txt_yenisifre.Clear();
            txt_eskisifre.Clear();
            txt_YeniSifreTekrar.Clear();

        }
    }
}
