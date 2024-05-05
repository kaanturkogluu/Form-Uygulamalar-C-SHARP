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
    public partial class Giris : Form
    {

        VeriTabaniAdmin vt_class = new VeriTabaniAdmin();
        VeriTabaniPersonel vt_personel = new VeriTabaniPersonel();
        public Giris()
        {
            InitializeComponent();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if(txt_ad.Text !="" & txt_sifre.Text != "")
            {

                // admin ise 
                if (vt_class.adminGiris(txt_ad.Text, txt_sifre.Text))
                {
                    AnaSayfa ana = new AnaSayfa(1);
                    ana.Show();
                    this.Hide();

                }
                // personel ise 
                else if(vt_personel.personelGiris(txt_ad.Text, txt_sifre.Text))
                {
                    Personel personel = new Personel(0);
                    personel.Show();
                    this.Hide();
                }
               
                else
                {
                    MessageBox.Show("Kullanıcı Adi veya Sifre Hatalı");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Sifre Bos Bırakılamaz","Giriş Hatası");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
