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
    public partial class Telefon_Bilgileri : Form
    {
       
        private int selectedId;
        private string isAdmin;

        public Telefon_Bilgileri(int id,string isadmin)
        {
            InitializeComponent();
            selectedId = id;
            this.isAdmin = isadmin;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        VeriTabaniSatisIslemleri vt_SatisIslemleri = new VeriTabaniSatisIslemleri(); 
        private void Telefon_Bilgileri_Load(object sender, EventArgs e)
        {
          
        }
        void bilgileriEkle()
        {
            List<string> bilgiler = vt_SatisIslemleri.bilgileriDoldur(selectedId);
          
            for (int i = 0; i < bilgiler.Count; i++)
            {
                lbl_ad.Text = bilgiler[0];
                lbl_ram.Text = bilgiler[1];
                lbl_dahili_depolama.Text = bilgiler[2];

                lbl_ekran_boyutu.Text = bilgiler[3];

               
                lbl_marka.Text = bilgiler[4];
                lbl_batarya.Text = bilgiler[5];
                lbl_hizli_sarj.Text = bilgiler[6];
                lbl_kablosuz.Text = bilgiler[7];
                lbl_kamera_coz.Text = bilgiler[8];
             
                lbl_on_kam.Text = bilgiler[9];
                lbl_ekran_yenile.Text = bilgiler[10];
                lbl_frekans.Text = bilgiler[11];
                lbl_parmakizi.Text = bilgiler[12];
                lbl_renk.Text = bilgiler[13];
                lbl_hafiza_kart.Text = bilgiler[14];

                lbl_isletim.Text = bilgiler[15];

                lbl_hat_say.Text = bilgiler[14];
                lbl_cks.Text = bilgiler[16];
                lbl_garanti.Text = bilgiler[17];
                lbl_stok.Text = bilgiler[18];
                lbl_hat_say.Text = bilgiler[19];
                lbl_fiyat.Text = bilgiler[20];

            }
        }
        VeriTabaiStok vt_stok = new VeriTabaiStok();
        private void Telefon_Bilgileri_Load_1(object sender, EventArgs e)
        {
            bilgileriEkle();

            vt_stok.resimGoster(selectedId, pcr_tel);
           
           
            

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_stok.Text)>0)
            {
                if (isAdmin.Contains("Admin"))
                {
                    MessageBox.Show("Adminler Satış Yapamazlar");
                }
                else
                {
                    this.Hide();
                    SatisYap satis = new SatisYap(selectedId,int.Parse(lbl_stok.Text));
                    satis.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Seçilen Ürün Tükenmiştir.","Stok GÜncelleyin");
            }
          







        }
    }
}
