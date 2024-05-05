using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 


namespace Deneme_Sınavı_Takip_Cizelgesi
{
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
        void temizle()
        {
            txt_ad.Clear();
            txt_oklno.Clear();
            txt_soyad.Clear();
            txt_telno.Clear(); 
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_telno.Text != "")
            {


                try
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        string kayit = "insert into Ogrenci(Adi,Soyadi,Okul_Numarasi,Sube) values (@adi,@soyadi,@okulnumarasi,@sube)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@adi", txt_ad.Text);
                        komut.Parameters.AddWithValue("@soyadi", txt_soyad.Text);
                        komut.Parameters.AddWithValue("@okulnumarasi", txt_oklno.Text);
                        komut.Parameters.AddWithValue("@sube", txt_telno.Text.ToUpper());
                        komut.ExecuteNonQuery();





                        baglanti.Close();
                        MessageBox.Show("Kayit Basarili");
                        temizle();
                        txt_ad.Focus(); 
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                MessageBox.Show("Şube Girişi Yapilmadi ","Şube Girişi Zorunludur");
            }

        }

        private void Ekle_Load(object sender, EventArgs e)
        {

        }

        private void txt_oklno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_oklno_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Okul_Numarasi from Ogrenci" +
                " where Okul_Numarasi='" + txt_oklno.Text + "'", baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            SqlDataReader dr = komut.ExecuteReader();

            dr.Read();

            if (dr.HasRows == true)
            {
                label5.Text = "Numara Kullanılmakta ";
            }
            else
            {
                label5.Text = " ";
            }
            baglanti.Close();
        }
    }
}
