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
    public partial class DinGrafik : Form
    {
        public DinGrafik()
        {
            InitializeComponent();
        }

        private void DinGrafik_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
            baglanti.Open();





            SqlCommand komut = new SqlCommand("Select  DinKültürü.Ogrenci_id,DinKültürü.Net , DinKültürü.SinavSayisi  from DinKültürü  where DinKültürü.SinavSayisi<= '" + Say.SinavSay + "' and DinKültürü.Ogrenci_id='" + Say.id + "' ", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            chart1.DataSource = dt;
        }
    }
}
