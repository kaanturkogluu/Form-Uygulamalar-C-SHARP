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
    public partial class ogrenciler : Form
    {
        public ogrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
        private void ogrenciler_Load(object sender, EventArgs e)
        {

           KayitGetir(); 

        }
        void KayitGetir()

        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Sube,Adi, Soyadi , Okul_Numarasi  from Ogrenci", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close(); 
        }
    }
}
