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
    public partial class Genel_islemler : Form
    {
        public Genel_islemler()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True");
        private void Genel_islemler_Load(object sender, EventArgs e)
        {
            Listele();

        }
        void Listele() //datagird e kayıt çekme
        {
            baglantı.Open();
            SqlDataAdapter da= new SqlDataAdapter("select * from Hayvanlar",baglantı);
            DataTable table = new DataTable();

            da.Fill(table);
            dataGridView1.DataSource = table;
            baglantı.Close();
            
        }
        //arama filtreleme
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komut = new SqlCommand("select *from Hayvanlar where Renk like'"+textBox1.Text+"' or  Cinsi like '"+textBox1.Text+"' ", baglantı);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglantı.Close();

            if (textBox1.Text=="")
            {
                Listele();
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //Datagridview e tıklanınca olackalar
        {
            txt_cins.Text = dataGridView1.CurrentRow.Cells["Cinsi"].Value.ToString();
            txt_fiyat.Text = dataGridView1.CurrentRow.Cells["Fiyat"].Value.ToString();
            txt_renk.Text = dataGridView1.CurrentRow.Cells["Renk"].Value.ToString();
            txt_tür.Text = dataGridView1.CurrentRow.Cells["Tür"].Value.ToString();
            txt_yas.Text = dataGridView1.CurrentRow.Cells["Yas"].Value.ToString();

         


        }

        void Temizle()
        {
            txt_cins.Clear();
            txt_fiyat.Clear();
            txt_renk.Clear();
            txt_tür.Clear();
            txt_yas.Clear(); 
        }
        private void button2_Click(object sender, EventArgs e) //Kayıt Ekleme 
        {
            try
            {
                baglantı.Open();
                string kayıt = "insert into Hayvanlar(Cinsi,Yas,Fiyat,Renk,Kart,Tür) Values( @cinsi,@yas,@fiyat,@renk,@kart,@tür) ";

                SqlCommand komut = new SqlCommand(kayıt, baglantı);
                komut.Parameters.AddWithValue("@yas", txt_yas.Text);
                komut.Parameters.AddWithValue("@cinsi", txt_cins.Text);
                komut.Parameters.AddWithValue("@fiyat", txt_fiyat.Text);
                komut.Parameters.AddWithValue("@kart", comboBox1.Text);
                komut.Parameters.AddWithValue("tür", txt_tür.Text);
                komut.Parameters.AddWithValue("@renk", txt_renk.Text);
                komut.ExecuteNonQuery();
                baglantı.Close();
                Temizle();
                MessageBox.Show("Kayıt İşlemi Başarı İle Tamamlandı");
                Listele();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
          






        }

        private void txt_yas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        private void txt_fiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)//güncelleme
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            try
            {
               if( MessageBox.Show("Bigiler Güncellenecek , Yapılan Değişiklik Geri Alınmiyacaktır \nEmin Misiniz?", "Kayıt Değişikliği ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglantı.Open();
                    string sorgu = "update Hayvanlar set Cinsi ='"+txt_cins.Text+"' , Yas='"+txt_yas.Text+"',Renk='"+txt_renk.Text+"'  ,Fiyat='"+txt_fiyat.Text+"',Kart='"+comboBox1.Text+"', Tür ='"+txt_tür.Text+"'  where id ='"+id+"'    "; 
                    SqlCommand komut = new SqlCommand(sorgu,baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    Listele();
                    MessageBox.Show("Güncelleme İşlemi Başarıyla Tamamlandı","Güncelleme İŞlemi",MessageBoxButtons.OK,MessageBoxIcon.Information);





                }
                else
                {
                    MessageBox.Show("Güncelleme İşlemi İptal Edildi","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
               
            try
            {
             if   (MessageBox.Show("Silmek İstediğinize Emin Misiniz?","Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    baglantı.Open();
                    SqlCommand komut = new SqlCommand("Delete from Hayvanlar where id= '"+ id + "'", baglantı);
                    komut.ExecuteNonQuery();
                    baglantı.Close();
                    Listele();
                    MessageBox.Show("Silme İşlemi Tamamlandı, Yaptığını Beğendin mi Silindi işte ", "Silme İŞlemi", MessageBoxButtons.OK, MessageBoxIcon.Question);



                }
                else
                {
                    MessageBox.Show("İptal edildi");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide(); 
        }
    }
}
