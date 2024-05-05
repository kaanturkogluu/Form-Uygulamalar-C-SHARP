using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace M_Kaya_Kütüphane
{
    public partial class Admin_Kayit : Form
    {
        public Admin_Kayit()
        {
            InitializeComponent();
        }
        Baglanti_İslemleri baglanti_İslemleri = new Baglanti_İslemleri();
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
        private void Admin_Kayit_Load(object sender, EventArgs e)
        {
            txt_referans.Text = RandomOlustur(); 
        }
        private string RandomOlustur()
        {
            Random random = new Random();
            return random.Next(100000, 1000000).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try


            {

                if (txt_sifre_tekrar.Text == txt_sifre.Text)
                {


                    if (txt_ad.Text == "" | txt_cevap.Text == "" | txt_guvenlik.Text == "" | txt_kyt_referans.Text == "" | txt_sifre.Text == "")
                    {
                        MessageBox.Show("Tüm Alanlarin Doldurulmasi Zorunludur", "Bos Birakilan Yerler Var");

                    }
                    else
                    {






                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();

                        }

                      
                        txt_referans.Text = RandomOlustur();

                        baglanti_İslemleri.Admin_Kayit(txt_ad.Text, txt_sifre.Text, txt_guvenlik.Text, txt_cevap.Text, txt_referans.Text, txt_kyt_referans.Text);



                        #region temizleme 
                        baglanti_İslemleri.Temizle(txt_ad);
                        baglanti_İslemleri.Temizle(txt_cevap);
                        baglanti_İslemleri.Temizle(txt_guvenlik);
                        baglanti_İslemleri.Temizle(txt_kyt_referans);
                        baglanti_İslemleri.Temizle(txt_sifre);
                        baglanti_İslemleri.Temizle(txt_sifre_tekrar);
                        #endregion




                        if (baglanti.State == ConnectionState.Open)
                        {
                            baglanti.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmadı","Yanlış Şifre Tekrari");
                }
            }
            catch (Exception ex)
            {
                baglanti.Close(); 
                MessageBox.Show(ex.Message);
                MessageBox.Show("Tekrar Deneyin Yada Uygulamayi Bastan Baslatmayi Deneyin");
                throw;
            }

          
        }

        private void txt_geri_Click(object sender, EventArgs e)
        {
            
            this.Hide();
          

        }
    }
}
