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
    public partial class MatGrafik : Form
    {
        public MatGrafik()
        {
            InitializeComponent();
        }

        private void MatGrafik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();





            SqlCommand komut1 = new SqlCommand(" Select  Matematik.Ogrenci_id,   Matematik.Net  , Matematik.SinavSayisi  from Matematik  where Matematik.SinavSayisi<= '" + Say.SinavSay + "' and Matematik.Ogrenci_id='" + Say.id + "'  ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart1.DataSource = dt;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
