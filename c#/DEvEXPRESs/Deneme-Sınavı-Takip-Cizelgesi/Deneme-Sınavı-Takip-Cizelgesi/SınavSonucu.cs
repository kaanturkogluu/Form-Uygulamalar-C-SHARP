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
    public partial class SınavSonucu : Form
    {
        public SınavSonucu()
        {
            InitializeComponent();
        }

        private void SınavSonucu_Load(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;
            KayitGetir();
            
        
        
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
      
       
        void KayitGetir()

        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("  select  Adi , Soyadi , Toplam_Net,Ogrenci.Okul_Numarasi, Matematik.SinavSayisi as 'Deneme', Ogrenci.Sube,Ogrenci.id  from Ogrenci  inner join Toplam_Net on Toplam_Net.Ogrenci_id=Ogrenci.id   inner join  Matematik on Matematik.Ogrenci_id = Ogrenci.id ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        int sinavsayisi = 1; 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            sinavsayisi = int.Parse(comboBox1.SelectedItem.ToString());
            baglanti.Open();
         //     SqlCommand komut = new SqlCommand("select Ogrenci.Okul_Numarasi,Ogrenci.Adi, Ogrenci.Soyadi Matematik.Dogru as 'MAT D', Matematik.Yanlıs as 'MAT Y' , Matematik.Net as 'MAT N', Matematik.SinavSayisi as 'Deneme Sayisi', İngilizce.Dogru as 'İng D',İngilizce.Yanlıs as 'İNG Y',İngilizce.Net as 'İng N' from Ogrenci inner join Matematik on Ogrenci.id = Matematik.Ogrenci_id  inner join İngilizce on İngilizce.Ogrenci_id=Ogrenci.id  Where SinavSayisi =(" + sinavsayisi + ")", baglanti);


           SqlCommand komut = new SqlCommand("select  Adi , Soyadi , Toplam_Net,Ogrenci.Okul_Numarasi,Ogrenci.Sube,Ogrenci.id , Matematik.SinavSayisi as 'Deneme' from Ogrenci  inner join Toplam_Net on Toplam_Net.Ogrenci_id=Ogrenci.id   inner join  Matematik on Matematik.Ogrenci_id = Ogrenci.id where Matematik.SinavSayisi = '"+comboBox1.SelectedItem+"'  ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (txt_bul.Text=="")
            {
                KayitGetir();

            }
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select  Adi , Soyadi , Toplam_Net,Ogrenci.Okul_Numarasi,Ogrenci.Sube,Ogrenci.id , Matematik.SinavSayisi as 'Deneme' from Ogrenci  inner join Toplam_Net on Toplam_Net.Ogrenci_id = Ogrenci.id inner join Matematik on Matematik.Ogrenci_id = Ogrenci.id  where Ogrenci.Adi like '%" + txt_bul.Text + "%' or  Ogrenci.Okul_Numarasi like '%" + txt_bul.Text + "'", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

           
            DataTable tablo = new DataTable();
            da.Fill(tablo);


          
            dataGridView2.DataSource = tablo;



            baglanti.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select  Adi , Soyadi , Toplam_Net,Ogrenci.Okul_Numarasi,Ogrenci.Sube,Ogrenci.id , Matematik.SinavSayisi as 'Deneme' from Ogrenci  inner join Toplam_Net on Toplam_Net.Ogrenci_id=Ogrenci.id   inner join  Matematik on Matematik.Ogrenci_id = Ogrenci.id where Ogrenci.Sube = '" + comboBox2.SelectedItem.ToString() + "' and  Matematik.SinavSayisi = '" + comboBox1.SelectedItem + "'   ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();
            da.Fill(tablo);


            //  da.Fill(ds);


            //  dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.DataSource = tablo;
            baglanti.Close();

        }
        int yeniid;
       
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           yeniid=int.Parse(dataGridView2.CurrentRow.Cells["id"].Value.ToString());
            lbladi.Text = dataGridView2.CurrentRow.Cells["Adi"].Value.ToString();
            lbladi.Text+= " "+ dataGridView2.CurrentRow.Cells["Soyadi"].Value.ToString();
            lblno.Text = dataGridView2.CurrentRow.Cells["Okul_Numarasi"].Value.ToString();
            lblsube.Text = dataGridView2.CurrentRow.Cells["Sube"].Value.ToString();
            lblid.Text= dataGridView2.CurrentRow.Cells["id"].Value.ToString();

      /*  Say.SinavSay =  int.Parse(dataGridView2.CurrentRow.Cells["Deneme"].Value.ToString());
           Say.Adi = dataGridView2.CurrentRow.Cells["Adi"].Value.ToString();
           Say.id = yeniid;
      */





        }
        int o = 1; 
        private void label4_Click(object sender, EventArgs e)
        {
           
            o++;
           
            Say.Adi = dataGridView2.CurrentRow.Cells["Adi"].Value.ToString();
            Say.Soyadi = dataGridView2.CurrentRow.Cells["Soyadi"].Value.ToString();
            Say.Sube= dataGridView2.CurrentRow.Cells["Sube"].Value.ToString();

            Say.id = yeniid;
            Say.SinavSay = int.Parse(dataGridView2.CurrentRow.Cells["Deneme"].Value.ToString());

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            SonuclariGörüntüle görüntüle = new SonuclariGörüntüle();
            görüntüle.Show();
        }
    }
}
