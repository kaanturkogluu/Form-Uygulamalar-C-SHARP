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
    public partial class Admin_Sifre_Yenile : Form
    {
        public Admin_Sifre_Yenile()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_ = new Baglanti_İslemleri();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ( baglanti_.baglanti.State == ConnectionState.Open)
            {
                baglanti_.baglanti.Close();
            }
          if(baglanti_.Admin_Sifre_Yenile(txt_adminisim.Text))
            {
                Baglanti_İslemleri.id = (baglanti_.idAl(txt_adminisim.Text,"Admin")); 
                txt_cevap.Visible = true;
                txt_güvenlikSorusu.Visible = true;
                label3.Visible = true;
                label2.Visible = true;
                txt_güvenlikSorusu.Text=  baglanti_.SifreYenile(txt_adminisim.Text);
               
                button1.Visible = false;
                btn_cevap.Visible = true ;
                txt_adminisim.Enabled = false; 
              



              
            }
           
            if (baglanti_.baglanti.State == ConnectionState.Open)
            {
                baglanti_.baglanti.Close();
            }

        }
       
        private void btn_cevap_Click(object sender, EventArgs e)
        {



            baglanti_.Sifre_Cevap(txt_adminisim.Text, txt_cevap.Text);
            this.Close();
          

          




        }

        private void Admin_Sifre_Yenile_Load(object sender, EventArgs e)
        {
            btn_cevap.Visible = false;
        }

        private void Admin_Sifre_Yenile_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show(); 
        }
    }
}
