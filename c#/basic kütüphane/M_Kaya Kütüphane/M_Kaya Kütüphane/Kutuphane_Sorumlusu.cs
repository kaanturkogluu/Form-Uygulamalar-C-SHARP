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
    public partial class Kutuphane_Sorumlusu : Form
    {
        public Kutuphane_Sorumlusu()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_ = new Baglanti_İslemleri();
        private void button1_Click(object sender, EventArgs e)
        {
            if( txt_sifre.Text == txt_SifreTekrar.Text & txt_sifre.Text !="" & txt_SifreTekrar.Text!="" & txt_kad.Text!="")
            {
                baglanti_.Refernas_Kontrol(txt_referans.Text, txt_kad.Text, txt_sifre.Text, txt_referans.Text);
                this.Close();
                AnaSayfa ana = new AnaSayfa();
                ana.Show();
               
            }
            else
            {
                MessageBox.Show("Gerekli Alanlar Tam Olarak Doldurulmamış\nTüm Alanları Doldurun","Boş Alan Hatasi");
            }

        }

        private void Kutuphane_Sorumlusu_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnaSayfa ans = new AnaSayfa();  
            ans.Show();
            
        }
    }
}
