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
    public partial class SatisYap : Form
    {
        private int selectedId ;
        private int stokadeti;
        public SatisYap(int id,int stokadeti )
        {
            InitializeComponent();
            selectedId = id;
            this.stokadeti = stokadeti; 
        }

        private void SatisYap_Load(object sender, EventArgs e)
        {
            bilgileriEkle();
            personeldoldur();
            cmb_adet.SelectedIndex = 0;
        }
        VeriTabaiStok vt_stok = new VeriTabaiStok();
        void personeldoldur()
        {
            vt_stok.comboBoxDoldur(cmb_personeller, "Table_Personeller", "PersonelAdi");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        VeriTabaniSatisIslemleri vt_SatisIslemleri = new VeriTabaniSatisIslemleri();
        void bilgileriEkle()
        {
            List<string> bilgiler = vt_SatisIslemleri.bilgileriDoldur(selectedId);

            for (int i = 0; i < bilgiler.Count; i++)
            {
               lbl_isim.Text = bilgiler[0];
             
               lbl_hafiza.Text = bilgiler[2];

                


              

                lbl_isletim.Text = bilgiler[15];

              lbl_granti.Text = bilgiler[17];
               
                lbl_fiyat.Text = bilgiler[20];

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11; 
            
        }

       VeriTabaniMusteri vt_musteriIslemleri = new VeriTabaniMusteri(); 
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Geçerli Tc Giriniz");
            }
            else 
            if (vt_musteriIslemleri.musteritcKontrol(textBox1.Text)) 
            {

            

            
                lbl_ad.Text = vt_SatisIslemleri.musteriGetir(textBox1.Text)[0];

                lbl_adres.Text = vt_SatisIslemleri.musteriGetir(textBox1.Text)[1];

                lbl_bakiye.Text = vt_SatisIslemleri.musteriGetir(textBox1.Text)[2];

                lbl_tel.Text = vt_SatisIslemleri.musteriGetir(textBox1.Text)[3];
                lbl_musteri_id.Text = vt_SatisIslemleri.musteriGetir(textBox1.Text)[4];


            }
            else
            {
                MessageBox.Show("Girilen Tc sistemde Kayıtlı Değildir");
            }



        }

        private void Table_Personeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedİtem = cmb_personeller.SelectedItem.ToString();
            lbl_sube.Text = vt_SatisIslemleri.personelBilgileriniGetir(selectedİtem)[1];
            lbl_sube_id.Text= vt_SatisIslemleri.personelBilgileriniGetir(selectedİtem)[0];
            lbl_toplam_satis.Text= vt_SatisIslemleri.personelBilgileriniGetir(selectedİtem)[3];  // adet
            lbl_personel_id.Text = vt_SatisIslemleri.personelBilgileriniGetir(selectedİtem)[4]; // personel id

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( lbl_sube.Text == "-")
            {
                MessageBox.Show("Satış Yapan Personeli  Seçin");
            }
            else if (lbl_tel.Text=="-")
            {
                MessageBox.Show("Müşteriyi Seçin");
            }
            else


            {
                if (int.Parse( lbl_fiyat.Text ) <= int.Parse(lbl_bakiye.Text))
                {
                    if (stokadeti -int.Parse( cmb_adet.SelectedItem.ToString()) >=0)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Satış İşlemini Onaylayın", "Satış Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                        {

                            // satıs islemi gerçekleştirilecek

                            vt_SatisIslemleri.satisTablosubaEkle(selectedId, int.Parse(lbl_personel_id.Text), int.Parse(lbl_musteri_id.Text), int.Parse(lbl_sube_id.Text), int.Parse(cmb_adet.SelectedItem.ToString()));
                            //bakiye islemleri
                        

                            MessageBox.Show("Satış İşlemi Tamamlanmıstır");
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seçilen Adete Göre Stok Miktarı Yetersizdir","Yetersiz Stok");
                    }

                   
                }
                else
                {
                    MessageBox.Show("Bakiye Yetersiz , Bakiye Yüklemesi Yapın","Bakiye");

                }
              
            }
          
        }
        double esasfiyat;
        int say = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
         
            if (say==0)
            {
                 esasfiyat = double.Parse(lbl_fiyat.Text);
            }
            say++;

           double birimFiyat = esasfiyat;

           
            

;             int adet = Convert.ToInt32(cmb_adet.SelectedItem); // Comboboxtan seçilen adet değeri

            lbl_fiyat.Text =( birimFiyat * adet).ToString();
          

           
          
        }
    }
}
