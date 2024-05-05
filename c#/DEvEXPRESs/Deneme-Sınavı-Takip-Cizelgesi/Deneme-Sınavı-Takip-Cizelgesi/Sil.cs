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

namespace Deneme_Sınavı_Takip_Cizelgesi
{
    public partial class Sil : Form
    {
        public Sil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
        private void Sil_Load(object sender, EventArgs e)
        {
            KayitGetir();
            dataGridView1.AllowUserToAddRows = false; 

            falsele(txt_ad);
           
            falsele(txt_okulno);
           
            falsele(txt_soyad);
            falsele(txt_sube);
            simpleButton2.Enabled = false;

        }
       void falsele(TextBox text)
        {
            text.Enabled = false; 
        }
        void truela(TextBox text)
        {
            text.Enabled = true ;
        }
            void KayitGetir()

            {

                baglanti.Open();
                SqlCommand komut = new SqlCommand("select id,Sube,Adi, Soyadi , Okul_Numarasi  from Ogrenci", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
      
         void KayitSil()
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("Silmek İstediğinize Emin Misiniz? ", "Öğrenci Kayıt  Silme İşlemi ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlCommand komut = new SqlCommand("Delete from Ogrenci Where id =(" + id + ")", baglanti);
                SqlCommand komut2 = new SqlCommand("Delete from DinKültürü Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut3 = new SqlCommand("Delete from FenBilimleri Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut4= new SqlCommand("Delete from İngilizce Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut5 = new SqlCommand("Delete from İnklap Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut6 = new SqlCommand("Delete from Matematik Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut7 = new SqlCommand("Delete from Türkce Where Ogrenci_id =(" + id + ")", baglanti);
                SqlCommand komut8 = new SqlCommand("Delete from Toplam_Net Where Ogrenci_id =(" + id + ")", baglanti);
              
                baglanti.Open();
               komut.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
                komut3.ExecuteNonQuery();
                komut4.ExecuteNonQuery();
                komut5.ExecuteNonQuery();
                komut6.ExecuteNonQuery();
                komut7.ExecuteNonQuery();
                komut8.ExecuteNonQuery();

                baglanti.Close();
                KayitGetir();
                MessageBox.Show("Silme İşlemi Başarılı");

            }
            else
      
            
            
            {
                MessageBox.Show("İşlem İptal Edildi");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            KayitSil(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select  id,Adi,Soyadi,Okul_Numarasi,Sube from Ogrenci where Adi  like '%" + txt_bul.Text + "%' or  Soyadi  like '%" + txt_bul.Text +
                "%' or Okul_Numarasi  like '%" + txt_bul.Text + "%' or  Telefon_Numarasi like '%" +   txt_bul.Text + "' ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            baglanti.Close();


            //  da.Fill(ds);


            //  dataGridView2.DataSource = ds.Tables[0];
            dataGridView1.DataSource = tablo;
            if (txt_bul.Text=="")
            {
                KayitGetir();

            }


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        int say = 1;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            say++;
            if (say % 2 == 1)
            {
                falsele(txt_ad);
                simpleButton2.Enabled = false;
                falsele(txt_okulno);
               
                falsele(txt_soyad);
                falsele(txt_sube);
            }
            else
            {
                simpleButton2.Enabled = true;
                truela(txt_ad);

                truela(txt_okulno);
               
                truela(txt_soyad);
                truela(txt_sube);
            }
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            string adi = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            if (adi == "")
            {
                MessageBox.Show("Lütfen Geçerli Bir Satir Seçiniz ");
            }
            else
            {



                if (MessageBox.Show("Bilgiler Güncellenecek Emin Misiniz ? ", "KAYIT DEĞİŞİKLİĞİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("update Ogrenci set  Adi = '" + txt_ad.Text + "', Soyadi='" + txt_soyad.Text +"',Sube= '"+txt_sube.Text.ToUpper()+"' ,Okul_Numarasi = '" + txt_okulno.Text +

                "'  where id='" + id + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    KayitGetir();
                    MessageBox.Show("KAYITLAR GÜNCELLENDİ ");
                }
                else
                {
                    MessageBox.Show("DEĞİŞİKLİK İPTAL EDİLDİ");
                }
            }

        }

        private void txt_okulno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ad.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            txt_okulno.Text = dataGridView1.CurrentRow.Cells["Okul_Numarasi"].Value.ToString();
            txt_soyad.Text = dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
       
            txt_sube.Text = dataGridView1.CurrentRow.Cells["Sube"].Value.ToString();

        }

        private void txt_sube_TextChanged(object sender, EventArgs e)
        {

        }
    }

      

    
}
