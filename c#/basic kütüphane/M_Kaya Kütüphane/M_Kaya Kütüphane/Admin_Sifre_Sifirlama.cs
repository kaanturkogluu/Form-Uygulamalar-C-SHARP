using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_Kaya_Kütüphane
{
    public partial class Admin_Sifre_Sifirlama : Form
    {
        public Admin_Sifre_Sifirlama()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_ = new Baglanti_İslemleri();
        private void button1_Click(object sender, EventArgs e)
        {
            if(txt_sifre.Text == txt_sifre_tekar.Text & txt_sifre.Text!= "" & txt_sifre_tekar.Text!="") {
                baglanti_.yeniSifre(txt_sifre.Text);
                MessageBox.Show("Şifre Basariyla Degistirildi ","Sifre Yenileme");
                this.Close();
                AnaSayfa anaSayfa = new AnaSayfa(); 
                anaSayfa.Show();
                

                



            }
            else
            {
                MessageBox.Show("Şifreyler Uyuşmuyor , Tekrar Deneyin ","Şifre Hatasi");
            }
        }

        private void Admin_Sifre_Sifirlama_FormClosed(object sender, FormClosedEventArgs e)
        {
            Admin_Sifre_Yenile admin_Sifre_Yenile = new Admin_Sifre_Yenile();
            admin_Sifre_Yenile.Close();
        }

        private void Admin_Sifre_Sifirlama_Enter(object sender, EventArgs e)
        {
           
        }

        private void Admin_Sifre_Sifirlama_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            
        }
    }
}
