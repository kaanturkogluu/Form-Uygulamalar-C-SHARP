using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        string resimPath;
        byte[] resim;
        private void txt_resim_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Aç";
          
            openFileDialog1.Filter = "Jpeg Dosyası(*.jpg)|.jpg|Gif Dosyası (*.gif)|*.gif|Png Dosyası (*.png)|*.png|Tif Dosyası (*.tif)|*.tif";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    resimPath = openFileDialog1.FileName.ToString();

                }
                if (resimPath != null)
                {
                    FileStream fs = new FileStream(resimPath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    resim = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("Resim Seçiniz ");
                }

            }
            catch (System.OutOfMemoryException )
            {

                MessageBox.Show("Resim Boyutu Fazla Büyük , Lütfen Resim Değiştirin");
                
            }
          
          


        }
        VeriTabaiStok vt_stok = new VeriTabaiStok();
        private void button1_Click(object sender, EventArgs e)
        {


            // isim kontrolü
            if (TelefonAdi.Text != "")
            {

                // fiyatt konrolü
                if (Fiyat.Text != "")
                {

                    //garanti kontrolü
                    if (GarantiSuresi.Text == "")
                    {
                        MessageBox.Show("Garanti Suresini Girin");
                    }
                    if (StokAdeti.Text =="0")
                    {
                        MessageBox.Show("Geçerli ADET girin");

                    }
                    else
                    {
                        //comboboxlar kontrolü 
                        bool hepsindeSecimYapildi = true;

                        foreach (Control control in this.Controls) // Form üzerindeki kontrol elemanlarını döngüyle kontrol ediyoruz
                        {
                            if (control is ComboBox comboBox && comboBox.Name.StartsWith("Table")) // Sadece ComboBox kontrolünü ve istediğiniz isim desenine sahip olanları kontrol ediyoruz
                            {
                                if (comboBox.SelectedIndex == -1) // ComboBox'ta seçim yapılmamışsa
                                {
                                    hepsindeSecimYapildi = false;
                                    break; // En az bir ComboBox'ta seçim yapılmamışsa döngüden çıkıyoruz
                                }
                              
                            }
                        }

                        if (hepsindeSecimYapildi)
                        {
                            // resim kontrolü boşdeğil ise ise
                            if (!string.IsNullOrWhiteSpace(resimPath))
                            {
                                //comboboxtaki verileri sözlüğe aktaralım
                                Dictionary<string, object> comboBoxData = new Dictionary<string, object>();
                                Dictionary<string, object> eklenecekData = new Dictionary<string, object>(); 

                                // Formunuzda yer alan tüm kontrolleri tarayın
                                // seçilen verileri sözlüğe aktardık
                                // döngü ile tüm ögelerdeki degerleri sözlük yapısına aktardık

                                foreach (Control control in this.Controls)
                                {
                                    if (control is ComboBox comboBox && comboBox.Name.StartsWith("Table") )
                                    {


                                        string comboBoxName = comboBox.Name;
                                        string selectedValue = comboBox.SelectedItem?.ToString() ?? string.Empty;

                                        //verileri eklemeden önce idAl metotu ile verilerin direk olarak idsini ekleyelim 
                                        // id stunu  - tablo ismi  -stunadi -gelendegeri parametre alip bize id dönderecek

                                        // comboox name ile tablo ismi geliyor , selected value gelen değeri temsil ediyor
                                        // id stunu için tabloismindeki _ leri cıkarıp sonuna Id eklememiz gerekecek

                                        //telefon degeri için farklı işlem yapılacak
                                        string idstunu;
                                        string tabloismi;
                                        string stunadi;
                                        string gelendeger; 
                                       
                                        
                                            //metotoa gidecek örnek ifade 
                                            // "BataryaKapasitesiId","Table_Batarya_Kapasitesi","BataryaKapasitesi","3700 mAh"
                                       
                                     
                                       
                                       
                                        
                                            idstunu = comboBoxName.Replace("Table_","").Replace("_","") + "Id";
                                            stunadi = comboBoxName.Replace("Table_","").Replace("_","");
                                             tabloismi = comboBoxName;
                                            gelendeger = selectedValue;
                                            comboBoxData.Add(comboBoxName.Replace("Table_","").Replace("_","")+"ID", vt_stok.idAl(idstunu, tabloismi, stunadi, gelendeger).ToString());
                                      
                                        

                                      

                                     



                                     


                                    }

                                    // teextboxlardan gelen degeler kontrol ediliyor
                                    if (control is TextBox textBox && textBox.Name.StartsWith("TelefonAdi") | textBox.Name.StartsWith("Garanti") | textBox.Name.StartsWith("Fiyat") | textBox.Name.StartsWith("StokAdeti"))
                                    {
                                        string textBoxName = textBox.Name.Replace("Table_","");
                                        string invalue = textBox.Text.ToString() ?? string.Empty;
                                       


                                        comboBoxData.Add(textBoxName, invalue);
                                      

                                    }

                                }





                                comboBoxData.Add("OrnekResim", resim);
                                // kayıt işlemi içn olan metota sözlüğü gönderek kayıt işlemeni tamamlayalım
                                vt_stok.telefonEkle(comboBoxData);


                                MessageBox.Show("Kayıt İşlemi Tamamlandı");


                                // anasayfadaki gridi  güncelliyelim
                                VeriTabaniSatisIslemleri vt_satis = new VeriTabaniSatisIslemleri(); 
                                AnaSayfa ana = new AnaSayfa(1);
                                ana.dtgrid_stok.DataSource = vt_satis.stokListele(); 
                                
                                //formu kapat 
                                this.Close();

                                // resim kaydınıda ekleyelim
                             


                            }
                            else
                            {
                                MessageBox.Show("Resim Seçimi Yapınız");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Tüm Bilgileri Eksiksiz Giriniz");
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Fiyat Bilgisini Girin");
                }

            }
            else
            {
                MessageBox.Show("İsim Giriniz");
            }
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            vt_stok.comboBoxDoldur(Table_Batarya_Kapasitesi, "Table_Batarya_Kapasitesi", "BataryaKapasitesi");
            vt_stok.comboBoxDoldur(Table_Cikis_Yili, "Table_Cikis_Yili", "CikisYili");
            vt_stok.comboBoxDoldur(Table_Dahili_Depolama, "Table_Dahili_Depolama", "DahiliDepolama");
            vt_stok.comboBoxDoldur(Table_Ekran_Boyutu, "Table_Ekran_Boyutu", "EkranBoyutu");
            vt_stok.comboBoxDoldur(Table_Desteklenen_Frekans, "Table_Desteklenen_Frekans", "DesteklenenFrekans");
            vt_stok.comboBoxDoldur(Table_Hafiza_Karti_Destegi, "Table_Hafiza_Karti_Destegi", "HafizaKartiDestegi");
            vt_stok.comboBoxDoldur(Table_Hat_Sayisi, "Table_Hat_Sayisi", "HatSayisi");
            vt_stok.comboBoxDoldur(Table_Hizli_Sarj_Destegi, "Table_Hizli_Sarj_Destegi", "HizliSarjDestegi");
            vt_stok.comboBoxDoldur(Table_Ekran_Yenileme_Hizi, "Table_Ekran_Yenileme_Hizi", "EkranYenilemeHizi");
            vt_stok.comboBoxDoldur(Table_Isletim_Sistemi, "Table_Isletim_Sistemi", "IsletimSistemi");
            vt_stok.comboBoxDoldur(Table_Kamera_Cozunurlugu, "Table_Kamera_Cozunurlugu", "KameraCozunurlugu");

            vt_stok.comboBoxDoldur(Table_Marka, "Table_Marka", "Marka");

            vt_stok.comboBoxDoldur(Table_On_Kamera_Cozunurlugu, "Table_On_Kamera_Cozunurlugu", "OnKameraCozunurlugu");
            vt_stok.comboBoxDoldur(Table_Parmak_Izi_Okuyucu, "Table_Parmak_Izi_Okuyucu", "ParmakIziOkuyucu");
            vt_stok.comboBoxDoldur(Table_Ram_Bellek, "Table_Ram_Bellek", "RamBellek");
            vt_stok.comboBoxDoldur(Table_Renk, "Table_Renk", "Renk");
            vt_stok.comboBoxDoldur(Table_Kablosuz_Sarj_Destegi, "Table_Kablosuz_Sarj_Destegi", "KablosuzSarjDestegi");

        

        }



        public void veriLeriKaydet()
        {

           
   
        
        }

        private void txt_fiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StokAdeti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    
}
