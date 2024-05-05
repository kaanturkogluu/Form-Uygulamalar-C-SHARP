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
    public partial class Satis_İslemlerş : Form
    {
        public Satis_İslemlerş()
        {
            InitializeComponent();
        }

        private void Satis_İslemlerş_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
           this.Size= new Size(806,552);
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
        void Listele() //datagird e kayıt çekme
        {
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Cinsi,Renk,Adet,Fiyat from Hayvanlar", baglantı);
            DataTable table = new DataTable();

            da.Fill(table);
            dataGridView1.DataSource = table;
            baglantı.Close();

        }

        int toplam;

        #region
        private void button1_Click(object sender, EventArgs e)
        {
            toplam += 50;
            textBox1.Text = toplam.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toplam += 40;
            textBox1.Text = toplam.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toplam += 230;
            textBox1.Text = toplam.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            toplam += 30;
            textBox1.Text = toplam.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            toplam += 35;
            textBox1.Text = toplam.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toplam += 15;
            textBox1.Text = toplam.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            toplam += 5;
            textBox1.Text = toplam.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            toplam += 120;
            textBox1.Text = toplam.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
          
            toplam += 25;
            textBox1.Text = toplam.ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            
            toplam += 15;
            textBox1.Text = toplam.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            toplam += 5;
            textBox1.Text = toplam.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            toplam += 55;
            textBox1.Text = toplam.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            toplam += 155;
            textBox1.Text = toplam.ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            toplam += 15;
            textBox1.Text = toplam.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            toplam += 135;
            textBox1.Text = toplam.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            toplam += 35;
            textBox1.Text = toplam.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            toplam += 65;
            textBox1.Text = toplam.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            toplam += 15;
            textBox1.Text = toplam.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            toplam += 25;
            textBox1.Text = toplam.ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            toplam += 30;
            textBox1.Text = toplam.ToString();
        }
        #endregion
        int sayac = 0; 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sayac++;
            if (sayac%2==1)
            {
                this.Size=new Size(1232, 520);

                Listele();

            }
            else
            {
                this.Size = new Size(806, 520);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fiyat=int.Parse(dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString());
          
            toplam += fiyat;
            textBox1.Text = toplam.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            toplam = 0;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
           
            form.Show();
            this.Hide();

        }
    }
}
