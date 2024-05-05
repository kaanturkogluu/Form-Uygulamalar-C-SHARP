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


namespace M_Kaya_Kütüphane
{
    public partial class Mevcut_Kitaplar : Form
    {
        public Mevcut_Kitaplar()
        {
            InitializeComponent();
        }
        Baglanti_Kitap baglanti_Kitap = new Baglanti_Kitap(); 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Mevcut_Kitaplar_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kütüphaneDataSet2.Kitap' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitapTableAdapter1.Fill(this.kütüphaneDataSet2.Kitap);
            // TODO: Bu kod satırı 'kütüphaneDataSet1.Kitap' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitapTableAdapter.Fill(this.kütüphaneDataSet1.Kitap);
            baglanti_Kitap.kitap_Liste(dataGridView1);
            

        }

     
    

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //cmb2 nin içerğini veri tbanına göre çek 
            comboBox2.Items.Clear(); 
            baglanti_Kitap.altFiltre(comboBox1.Text, comboBox2); 


        }
        SqlCommand cmd; 
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            baglanti.Open();
            cmd = new SqlCommand("select   Kitap_Ad , Yazar ,Tipi,Hasar_Durumu,Hasar_Tipi,Adet,Sayfa ,Konu from Kitap where  '" +  comboBox1.SelectedItem.ToString().Trim() + "'='" + comboBox2.SelectedItem.ToString().Trim() + "'", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            dataGridView1.DataSource = dt; 

        }
    }
}
