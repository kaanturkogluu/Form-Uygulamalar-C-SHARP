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
    public partial class İngGrafik : Form
    {
        public İngGrafik()
        {
            InitializeComponent();
        }

        private void İngGrafik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();





            SqlCommand komut4 = new SqlCommand("Select  İngilizce.Ogrenci_id,İngilizce.Net , İngilizce.SinavSayisi  from İngilizce  where İngilizce.SinavSayisi<= '" + Say.SinavSay + "' and İngilizce.Ogrenci_id='" + Say.id + "'  ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut4);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart1.DataSource = dt;
        }
    }
}
