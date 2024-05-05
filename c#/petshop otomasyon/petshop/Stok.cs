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

namespace AyseNurProje
{
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
        private void Stok_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Listele() //datagird e kayıt çekme
        {
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Adı,Adet,Fiyat from Stok", baglantı);
            DataTable table = new DataTable();

            da.Fill(table);
            dataGridView1.DataSource = table;
            baglantı.Close();

        }

        private void Stok_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
            
        }
    }
}
