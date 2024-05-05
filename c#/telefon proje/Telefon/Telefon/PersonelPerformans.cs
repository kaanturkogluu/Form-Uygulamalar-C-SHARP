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
using System.Windows.Forms.DataVisualization.Charting;

namespace Telefon
{
    public partial class PersonelPerformans : Form
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;
        public PersonelPerformans()
        {
            InitializeComponent();
        }
        VeriTabaniPersonel vt_personel = new VeriTabaniPersonel(); 
        private void PersonelPerformans_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddDays(-7);
            adetyaz();
        }
     
     
        void adetyaz()
        {
           
            baglanti.Open();
            string query = "SELECT TOP 10 p.PersonelId, SUM(s.UrunAdeti) as ToplamSatis " +
               "FROM Table_Personeller p " +
               "INNER JOIN Table_Satislar s ON p.PersonelId = s.PersonelId " +
               "WHERE s.SatisTarihi BETWEEN @startDate AND @endDate " +
               "GROUP BY p.PersonelId " +
               "ORDER BY ToplamSatis DESC";

            SqlCommand cmd = new SqlCommand(query, baglanti);
            cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            // Sorguyu çalıştır ve sonuçları al
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Personel adlarını ve toplam satışları tutacak listeleri oluştur
                List<int> personelIdleri = new List<int>();
                List<int> toplamSatislar = new List<int>();
                List<string> personelAdlari = new List<string>();
                while (reader.Read())
                {
                    int personelID = reader.GetInt32(0);
                    int toplamSatis = reader.GetInt32(1);

                    personelIdleri.Add(personelID);
                    toplamSatislar.Add(toplamSatis);
                }

                // SqlDataReader nesnesini kapat
                reader.Close();

                // Her personel adı için bir seriyi chart'a ekle
                chart1.Series.Clear();
                string query2 = "SELECT PersonelAdi FROM Table_Personeller WHERE PersonelId IN (" +
                   string.Join(",", personelIdleri.Select(id => id.ToString())) + " )";

                SqlCommand cmdd = new SqlCommand(query2, baglanti);

                // Sorguyu çalıştır ve sonuçları al
                SqlDataReader readerr = cmdd.ExecuteReader();

         
                while (readerr.Read())
                {
                    string personelAdi = readerr.GetString(0);
                    personelAdlari.Add(personelAdi);
                }

                chart1.Series.Add("Satıslar");

                for (int i = 0; i < personelAdlari.Count; i++)
                {
                    string personelAdi = personelAdlari[i];
                    int toplamSatis = toplamSatislar[i];

                    
                    chart1.Series["Satıslar"].Points.AddY(toplamSatis);
                    chart1.Series["Satıslar"].IsValueShownAsLabel = true;
                    chart1.Series["Satıslar"].LabelFormat = "{#}"; // Sayısal değerleri tam olarak göstermek için

                }
                string[] personelAdlarDizi = personelAdlari.ToArray();

                // Y ekseni için etiketleri ayarla
                for (int i = 0; i < personelAdlarDizi.Length; i++)
                {
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, personelAdlarDizi[i]);
                }
            }

            baglanti.Close();

        }
        
        void miktaryaz()
        {
          

           
            baglanti.Open();
            string query = "SELECT TOP 10 p.PersonelId, p.PersonelToplamSatis as ToplamSatis " +
                           "FROM Table_Personeller p " +
                           "WHERE p.PersonelToplamSatis IS NOT NULL " +
                           "ORDER BY p.PersonelToplamSatis DESC";

            SqlCommand cmd = new SqlCommand(query, baglanti);
            cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            // Sorguyu çalıştır ve sonuçları al
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Personel adlarını ve toplam satışları tutacak listeleri oluştur
                List<int> personelIdleri = new List<int>();
                List<int> toplamSatislar = new List<int>();
                List<string> personelAdlari = new List<string>();
                while (reader.Read())
                {

                    int personelID = reader.GetInt32(0);
                    int toplamSatis = reader.GetInt32(1);

                    personelIdleri.Add(personelID);
                    toplamSatislar.Add(toplamSatis);
                }

                // SqlDataReader nesnesini kapat
                reader.Close();

                // Her personel adı için bir seriyi chart'a ekle
                chart2.Series.Clear();
                string query2 = "SELECT PersonelAdi FROM Table_Personeller WHERE PersonelId IN (" +
                 string.Join(",", personelIdleri.Select(id => id.ToString())) + "  ) ";

                SqlCommand cmdd = new SqlCommand(query2, baglanti);

                // Sorguyu çalıştır ve sonuçları al
                SqlDataReader readerr = cmdd.ExecuteReader();


                while (readerr.Read())
                {
                    string personelAdi = readerr.GetString(0);
                    personelAdlari.Add(personelAdi);
                }

                chart2.Series.Add("Satıslar");

                for (int i = 0; i < personelAdlari.Count; i++)
                {
                    string personelAdi = personelAdlari[i];
                    int toplamSatis = toplamSatislar[i];


                    chart2.Series["Satıslar"].Points.AddY(toplamSatis);
                    chart2.Series["Satıslar"].IsValueShownAsLabel = true;
                    chart2.Series["Satıslar"].LabelFormat = "{#}"; // Sayısal değerleri tam olarak göstermek için

                }
                string[] personelAdlarDizi = personelAdlari.ToArray();

                // Y ekseni için etiketleri ayarla
                for (int i = 0; i < personelAdlarDizi.Length; i++)
                {
                    chart2.ChartAreas[0].AxisX.CustomLabels.Add(i + 0.5, i + 1.5, personelAdlarDizi[i]);
                }
            }


            baglanti.Close();







        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
            if (checkBox1.Checked)
            {
                dateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
                adetyaz();
            }
            else
            {
                miktaryaz();
            }
        
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = DateTime.Now.AddDays(0);
         
            if (checkBox1.Checked)
            {
                dateTimePicker1.MaxDate = DateTime.Now.AddDays(-1);
                adetyaz();
            }
            else
            {
                miktaryaz();
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                chart1.Visible = false;
                chart2.Visible = true;
                checkBox1.Checked = false; 
                miktaryaz();
              
            }
            
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                chart2.Visible = false;
                chart1.Visible = true;
                adetyaz();

            }

        }
    }
}
