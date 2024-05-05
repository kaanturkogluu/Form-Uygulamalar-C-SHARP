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
    public partial class Deneme : Form
    {
        public Deneme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            KayitGetir();
            dataGridView1.AllowUserToAddRows = false;
            simpleButton1.Enabled = false; 

        }
    
        public double net;

        void netHesapla(double dogru,double yanlis,TextBox text)
        {

            net = (dogru - (yanlis / 3));
            text.Text = net.ToString();

           
          

        }
      

        void KayitGetir()

        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select id,Sube,Adi, Soyadi,Okul_Numarasi  from Ogrenci", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void txt_bul_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Adi ,Soyadi, Sube,Okul_Numarasi,Soyadi,id  from Ogrenci where Adi  like '%" + txt_bul.Text + "%' or Okul_Numarasi like '%" + txt_bul.Text + "' ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

        }
        int id;
        float toplamnet=0;
        int toplamdogru=0;
        int toplamyanlis=0; 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            lbladi.Text = dataGridView1.CurrentRow.Cells["Adi"].Value.ToString();
            lblsoyadi.Text = dataGridView1.CurrentRow.Cells["Soyadi"].Value.ToString();
            lblsube.Text = dataGridView1.CurrentRow.Cells["Sube"].Value.ToString();
            lblno.Text = dataGridView1.CurrentRow.Cells["Okul_Numarasi"].Value.ToString();

            simpleButton1.Enabled = true; 
        }
        void textboxsıfırla(TextBox textBox)
        {
            if (textBox.Text=="")
            {
                textBox.Text = "0"; 

            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txttürkcedogru);
            textboxsıfırla(txttürkceyanlıs);
            netHesapla(int.Parse(txttürkcedogru.Text),int.Parse(txttürkceyanlıs.Text),txttürkcenet);
          
            

            
        }

        private void txttürkceyanlıs_TextChanged(object sender, EventArgs e)
        { textboxsıfırla(txttürkceyanlıs);
            textboxsıfırla(txttoplamyanlıs);
            netHesapla(int.Parse(txttürkcedogru.Text), int.Parse(txttürkceyanlıs.Text), txttürkcenet);
           


        }

        private void txttürkcedogru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtinklapdogru);
            textboxsıfırla(txtinklapyanlis);
            netHesapla(int.Parse(txtinklapdogru.Text), int.Parse(txtinklapyanlis.Text), txtinkalpnet);
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtdindogru);
            textboxsıfırla(txtdinyanls);
            netHesapla(int.Parse(txtdindogru.Text), int.Parse(txtdinyanls.Text), txtnet);
        }

        private void txtingilzcedogru_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtingilzcedogru);
            textboxsıfırla(txtingilizceyanlis);
            netHesapla(int.Parse(txtingilzcedogru.Text), int.Parse(txtingilizceyanlis.Text), txtingilizcenet);
        }

        private void txtmatematikdogru_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtmatematikdogru);
            textboxsıfırla(txtmatematikyanlis);
            netHesapla(int.Parse(txtmatematikdogru.Text), int.Parse(txtmatematikyanlis.Text), txtmatematiknet);
        }

        private void txtfendogru_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtfendogru);
            textboxsıfırla(txtfenyanlis);
            netHesapla(int.Parse(txtfendogru.Text), int.Parse(txtfenyanlis.Text), txtfennet);
        }

        private void txtinklapyanlis_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtinklapdogru);
            textboxsıfırla(txtinklapyanlis);
            netHesapla(int.Parse(txtinklapdogru.Text), int.Parse(txtinklapyanlis.Text), txtinkalpnet);
        }

        private void txtdinyanls_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtdindogru);
            textboxsıfırla(txtdinyanls);
            netHesapla(int.Parse(txtdindogru.Text), int.Parse(txtdinyanls.Text), txtnet);
        }

        private void txtingilizceyanlis_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtingilzcedogru);
            textboxsıfırla(txtingilizceyanlis);
            netHesapla(int.Parse(txtingilzcedogru.Text), int.Parse(txtingilizceyanlis.Text), txtingilizcenet);
        }

        private void txtmatematikyanlis_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtmatematikdogru);
            textboxsıfırla(txtmatematikyanlis);
            netHesapla(int.Parse(txtmatematikdogru.Text), int.Parse(txtmatematikyanlis.Text), txtmatematiknet);
        }

        private void txtfenyanlis_TextChanged(object sender, EventArgs e)
        {
            textboxsıfırla(txtfendogru);
            textboxsıfırla(txtfenyanlis);
            netHesapla(int.Parse(txtfendogru.Text), int.Parse(txtfenyanlis.Text), txtfennet);
        }
       
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            int[] toplamdogrular = {int.Parse(txttürkcedogru.Text), int.Parse(txtinklapdogru.Text), int.Parse(txtdindogru.Text), int.Parse(txtingilzcedogru.Text), int.Parse(txtmatematikdogru.Text),
                int.Parse(txtfendogru.Text) };
            foreach (var item in toplamdogrular)
            {
                toplamdogru += item; 
            }
            txttoplamdogru.Text = toplamdogru.ToString();
            int[] yanlıslar ={int.Parse(txttürkceyanlıs.Text), int.Parse(txtinklapyanlis.Text), int.Parse(txtdinyanls.Text), int.Parse(txtingilizceyanlis.Text), int.Parse(txtmatematikyanlis.Text),
                int.Parse(txtfenyanlis.Text) };
            foreach (var item in yanlıslar)
            {
                toplamyanlis += item; 
            }
            txttoplamyanlıs.Text = toplamyanlis.ToString();
            float[]toplamnetler= {float.Parse(txttürkcenet.Text), float.Parse(txtinkalpnet.Text), float.Parse(txtnet.Text), float.Parse(txtingilizcenet.Text), float.Parse(txtmatematiknet.Text),
                float.Parse(txtfennet.Text) };
            foreach (var item in toplamnetler)
            {
                toplamnet += item;
            }
            txttoplamnet.Text = toplamnet.ToString();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            toplamdogru = 0;
            toplamyanlis = 0;
            toplamnet = 0;
            txttoplamnet.Clear();
            txttoplamyanlıs.Clear();
            txttoplamdogru.Clear(); 
        }
        void NotuYerineKoy(string tabloismi,  TextBox textdogru, TextBox texyanlus, TextBox textnet)
        {



        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Kayıtlarin Kacinci Deneme Sınavina Ait olduğunu Belirtmeniz Gerekmektedir ", "Sol Üst Köşe Deneme Sayisi Üzerinde Seçim Yapin");
            }

            baglanti.Open();
            SqlCommand komutt = new SqlCommand("Select FenBilimleri.SinavSayisi  from FenBilimleri where FenBilimleri.Ogrenci_id='" + id + "'", baglanti);

            SqlDataAdapter adp = new SqlDataAdapter(komutt);
            SqlDataReader dr = komutt.ExecuteReader();

            dr.Read();

            if (dr.HasRows == false)
            {
                if (txttoplamdogru.Text=="0" && txttoplamyanlıs.Text=="0"&& txttoplamnet.Text=="0" )
                {

                    simpleButton2.PerformClick();
                }



                #region

                try
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into DinKültürü(Dogru,Yanliş,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);


                    komut.Parameters.AddWithValue("@Dogru ", txtdindogru.Text);
                    komut.Parameters.AddWithValue("@Yanlıs", txtdinyanls.Text);
                    komut.Parameters.AddWithValue("@Net", float.Parse(txtnet.Text));

                    komut.Parameters.AddWithValue("@ogrencid", id);
                    komut.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);

                    komut.ExecuteNonQuery();

                    SqlCommand komut2 = new SqlCommand("insert into FenBilimleri(Dogru,Yanlıs,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);
                    komut2.Parameters.AddWithValue("@Dogru ", txtfendogru.Text);
                    komut2.Parameters.AddWithValue("@Yanlıs", txtfenyanlis.Text);
                    komut2.Parameters.AddWithValue("@Net", float.Parse(txtfennet.Text));

                    komut2.Parameters.AddWithValue("@ogrencid", id);
                    komut2.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut2.ExecuteNonQuery();

                    SqlCommand komut3 = new SqlCommand("insert into İngilizce(Dogru,Yanlıs,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);
                    komut3.Parameters.AddWithValue("@Dogru ", txtingilzcedogru.Text);
                    komut3.Parameters.AddWithValue("@Yanlıs", txtingilizceyanlis.Text);
                    komut3.Parameters.AddWithValue("@Net", float.Parse(txtingilizcenet.Text));

                    komut3.Parameters.AddWithValue("@ogrencid", id);
                    komut3.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut3.ExecuteNonQuery();

                    SqlCommand komut4 = new SqlCommand("insert into İnklap(Dogru,Yanlıs,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);
                    komut4.Parameters.AddWithValue("@Dogru ", txtinklapdogru.Text);
                    komut4.Parameters.AddWithValue("@Yanlıs", txtinklapyanlis.Text);
                    komut4.Parameters.AddWithValue("@Net", float.Parse(txtinkalpnet.Text));

                    komut4.Parameters.AddWithValue("@ogrencid", id);
                    komut4.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut4.ExecuteNonQuery();

                    SqlCommand komut5 = new SqlCommand("insert into Matematik(Dogru,Yanlıs,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);
                    komut5.Parameters.AddWithValue("@Dogru ", txtmatematikdogru.Text);
                    komut5.Parameters.AddWithValue("@Yanlıs", txtmatematikyanlis.Text);
                    komut5.Parameters.AddWithValue("@Net", float.Parse(txtmatematiknet.Text));

                    komut5.Parameters.AddWithValue("@ogrencid", id);
                    komut5.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut5.ExecuteNonQuery();

                    SqlCommand komut6 = new SqlCommand("insert into Türkce(Dogru,Yanlıs,Net,Ogrenci_id,SinavSayisi) Values (@Dogru , @Yanlıs, @Net,@ogrencid,@sinavsayisi)  ", baglanti);
                    komut6.Parameters.AddWithValue("@Dogru ", txttürkcedogru.Text);
                    komut6.Parameters.AddWithValue("@Yanlıs", txttürkceyanlıs.Text);
                    komut6.Parameters.AddWithValue("@Net", float.Parse(txttürkcenet.Text));

                    komut6.Parameters.AddWithValue("@ogrencid", id);
                    komut6.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut6.ExecuteNonQuery();


                    SqlCommand komut7 = new SqlCommand("insert into Toplam_Net(Ogrenci_id,Toplam_Net , Toplam_Yanlis,Toplan_Dogru,SinavSayisi) Values (@id,@dogru, @yanlis,@net,@sinavsayisi)  ", baglanti);
                    komut7.Parameters.AddWithValue("@dogru ", toplamdogru);
                    komut7.Parameters.AddWithValue("@yanlis", toplamyanlis);

                    komut7.Parameters.AddWithValue("@id ", id);
                    komut7.Parameters.AddWithValue("@sinavsayisi", comboBox1.Text);
                    komut7.Parameters.AddWithValue("@net", toplamnet);

                    komut7.ExecuteNonQuery();









                    baglanti.Close();
                    MessageBox.Show("Ekleme Yapildi");


                }
                catch (Exception)
                {

                    throw;
                 }
                #endregion

            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Daha Önce Kaydi Yapilmis");
            }



        }
        int a;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = int.Parse(comboBox1.SelectedItem.ToString()); 
        }

        private void txtnet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
