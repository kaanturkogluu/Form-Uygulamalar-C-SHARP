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
    public partial class FenGrafik : Form
    {
        public FenGrafik()
        {
            InitializeComponent();
        }

        private void FenGrafik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();





            SqlCommand komut5 = new SqlCommand("Select  FenBilimleri.Ogrenci_id,FenBilimleri.Net , FenBilimleri.SinavSayisi  from FenBilimleri  where FenBilimleri.SinavSayisi<= '" + Say.SinavSay + "' and FenBilimleri.Ogrenci_id='" + Say.id + "'  ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart1.DataSource = dt;
        }
    }
}
