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
    public partial class SonuclariGörüntüle : Form
    {
        public SonuclariGörüntüle()
        {
            InitializeComponent();
        }
        public string Kullanicid;
        private void SonuclariGörüntüle_Load(object sender, EventArgs e)
        {
            label2.Text = Say.SinavSay.ToString();
            label3.Text = Say.Adi;
            label3.Text += "" + Say.Soyadi;
            label4.Text = Say.Sube;

              KayitGetir();


            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();
            
            SqlCommand komut = new SqlCommand("Select  DinKültürü.Ogrenci_id,DinKültürü.Net , DinKültürü.SinavSayisi  from DinKültürü  where DinKültürü.SinavSayisi<= '"+Say.SinavSay+"' and DinKültürü.Ogrenci_id='"+Say.id+"' ", baglanti);
            
            SqlCommand komut1 = new SqlCommand(" Select  Matematik.Ogrenci_id,   Matematik.Net  , Matematik.SinavSayisi  from Matematik  where Matematik.SinavSayisi<= '" + Say.SinavSay + "' and Matematik.Ogrenci_id='" + Say.id + "'  ", baglanti);

            SqlCommand komut2 = new SqlCommand("Select  Türkce.Ogrenci_id,Türkce.Net ,   Türkce.SinavSayisi  from   Türkce  where   Türkce.SinavSayisi<= '" + Say.SinavSay + "' and   Türkce.Ogrenci_id='" + Say.id + "'  ", baglanti);
            SqlCommand komut3 = new SqlCommand("Select  İnklap.Ogrenci_id, İnklap.Net ,  İnklap.SinavSayisi  from  İnklap  where  İnklap.SinavSayisi<= '" + Say.SinavSay + "' and  İnklap.Ogrenci_id='" + Say.id + "'  ", baglanti);
            SqlCommand komut4 = new SqlCommand("Select  İngilizce.Ogrenci_id,İngilizce.Net , İngilizce.SinavSayisi  from İngilizce  where İngilizce.SinavSayisi<= '" + Say.SinavSay + "' and İngilizce.Ogrenci_id='" + Say.id + "'  ", baglanti);
            SqlCommand komut5 = new SqlCommand("Select  FenBilimleri.Ogrenci_id,FenBilimleri.Net , FenBilimleri.SinavSayisi  from FenBilimleri  where FenBilimleri.SinavSayisi<= '" + Say.SinavSay + "' and FenBilimleri.Ogrenci_id='" + Say.id + "'  ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            SqlDataAdapter mat = new SqlDataAdapter(komut1);
            SqlDataAdapter turk = new SqlDataAdapter(komut2);

            SqlDataAdapter ink = new SqlDataAdapter(komut3);

            SqlDataAdapter ing = new SqlDataAdapter(komut4);
            SqlDataAdapter fen = new SqlDataAdapter(komut5);
           


            DataTable dt = new DataTable();
            DataTable mattable = new DataTable();
            DataTable tukrtable = new DataTable();
            DataTable inktable = new DataTable();
            DataTable ingtable = new DataTable();
            DataTable fentable = new DataTable();

            da.Fill(dt);
            mat.Fill(mattable);
            fen.Fill(fentable);
            ink.Fill(inktable);
            turk.Fill(tukrtable);
            ing.Fill(ingtable);



            chart1.DataSource = tukrtable;
            chart2.DataSource = mattable;
            chart3.DataSource = fentable;
            chart4.DataSource = inktable;
            chart5.DataSource = dt;
            chart6.DataSource = ingtable;


            baglanti.Close();





        }
       
       
     

            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");


      
        void KayitGetir()

        {
            int sayisi = Say.SinavSay;
          
           
            baglanti.Open();
                SqlCommand komut2 = new SqlCommand("select Türkce.Dogru as 'Türk\n D ', Türkce.Yanlıs as 'Türk\n Y', Türkce.Net as 'Türk\n N'" +
                    " , Matematik.Dogru as 'Mat\nD', Matematik.Yanlıs as 'Mat\nY',Matematik.Net as 'Mat\nN', FenBilimleri.Dogru as 'Fen\n D', FenBilimleri.Yanlıs as 'Fen\n Y', FenBilimleri.Net as 'Fen\n N', " +
                    " DinKültürü.Dogru  as 'Din\n D', DinKültürü.Yanliş as 'Din\n Y', DinKültürü.Net as 'Din\n N', " +
                    " İnklap.Dogru as 'İnk\n D', İnklap.Yanlıs as 'İnk\n Y', İnklap.Net as 'İnk\n N' , " +
                    " İngilizce.Dogru as 'İng\nD ', İngilizce.Yanlıs as 'İng Y', İngilizce.Net as 'İng N' , " +
                    " Toplam_Net.Toplan_Dogru as 'TOP\nD' , Toplam_Net.Toplam_Yanlis as'TOP\nY ', Toplam_Net.Toplam_Net as 'TOP\nN' from Ogrenci " +
                     " inner join FenBilimleri on FenBilimleri.SinavSayisi= '"+Say.SinavSay+ "' and  FenBilimleri.Ogrenci_id=Ogrenci.id " +
                     " inner join Matematik on Matematik.SinavSayisi=  '"+Say.SinavSay+ "' and Matematik.Ogrenci_id=Ogrenci.id  " +
                     " inner join İnklap  on İnklap.SinavSayisi = '"+Say.SinavSay+"' and İnklap.Ogrenci_id = Ogrenci.id  " +
                     "  inner join İngilizce on İngilizce.SinavSayisi =  '" + Say.SinavSay + "' and İngilizce.Ogrenci_id = Ogrenci.id " +
                     " inner join DinKültürü on DinKültürü.SinavSayisi= '" +Say.SinavSay+"' and DinKültürü.Ogrenci_id=Ogrenci.id " +
                     " inner join Toplam_Net on Toplam_Net.SinavSayisi= '"+Say.SinavSay+"' and Toplam_Net.Ogrenci_id =Ogrenci.id " +
                    " inner join Türkce on Türkce.SinavSayisi = '"+Say.SinavSay+ "' and Türkce.Ogrenci_id=Ogrenci.id where Ogrenci.id= '" + Say.id+"'  ", baglanti);

           // SqlCommand komut2 = new SqlCommand("select Ogrenci.Adi as 'Adi' , TÜrkce.Dogru as 'Türk D from Ogrenci  inner join'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
           

            
            




            


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void SonuclariGörüntüle_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
      
        private void chart1_Click(object sender, EventArgs e)
        {
            TürkceGrafik türkce = new TürkceGrafik();
            türkce.Show(); 


        }

        private void chart4_Click(object sender, EventArgs e)
        {
            İnkGrafik grafik = new İnkGrafik();
            grafik.Show(); 

        }

        private void chart2_Click(object sender, EventArgs e)
        {
            MatGrafik mat = new MatGrafik();
            mat.Show(); 
        }

        private void chart3_Click(object sender, EventArgs e)
        {
            FenGrafik fen = new FenGrafik();
            fen.Show();
        }

        private void chart6_Click(object sender, EventArgs e)
        {
            İngGrafik ing = new İngGrafik();

           
            ing.Show(); 
                 
        }

        private void chart5_Click(object sender, EventArgs e)
        {
            DinGrafik din = new DinGrafik();
            din.Show(); 
        }
    }
}
