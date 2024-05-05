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
    public partial class İnkGrafik : Form
    {
        public İnkGrafik()
        {
            InitializeComponent();
        }

        private void İnkGrafik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();





            SqlCommand komut3 = new SqlCommand("Select  İnklap.Ogrenci_id, İnklap.Net ,  İnklap.SinavSayisi  from  İnklap  where  İnklap.SinavSayisi<= '" + Say.SinavSay + "' and  İnklap.Ogrenci_id='" + Say.id + "'  ", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut3);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart1.DataSource = dt;
        }
    }
}
