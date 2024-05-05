using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    class VeriTabaiStok
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;
        // resimin byte halini parametre alarak veritbanına kaydeden metot

        public void comboBoxDoldur(ComboBox combobox, string tablo, string kolon)
        {
            try
            {

                baglanti.Open();
                string query = $"SELECT  {kolon}  FROM  {tablo} ";


                // Bağlantıyı açın ve sorguyu çalıştırın


                SqlCommand command = new SqlCommand(query, baglanti);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Her satırdaki  değerini ComboBox'a ekleyin
                    combobox.Items.Add(reader[kolon].ToString().Trim());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }


        }

        public void telefonEkle(Dictionary<string, object> comboData)
        {

            try
            {

                string tableName = "Table_Telefonlar";
                string columnNames = string.Join(", ", comboData.Keys);
                string columnValues = string.Join(", ", comboData.Values);

                string query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({string.Join(", ", comboData.Keys.Select(k => "@" + k))})";

                command = new SqlCommand(query, baglanti);
                foreach (var kvp in comboData)
                {
                    command.Parameters.AddWithValue("@" + kvp.Key, kvp.Value);
                }

                baglanti.Open();
                command.ExecuteNonQuery();














            }





            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }


            }
        }


        // id almak için 
        public string idAl(string idStunu, string tablo, string stunadi, string stundegeri)
        {

            try
            {
                string iddegeri = "0";


                baglanti.Open();

                // Bataryalar tablosundan bataryaid'ye göre batarya değerini almak için sorgu
                string idQuery = $"SELECT {idStunu} FROM {tablo} WHERE {stunadi} = '{stundegeri}'";

                command = new SqlCommand(idQuery, baglanti);




                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    iddegeri = (reader[idStunu]).ToString();
                }
                reader.Close();



                return iddegeri;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {


                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }

            }


        }


        public void resimGoster(int id,PictureBox pictureBox)
        {

            try
            {



                string query = "SELECT OrnekResim FROM Table_Telefonlar WHERE TelefonID = @id";



                command = new SqlCommand(query, baglanti);

                command.Parameters.AddWithValue("@id", id);
                baglanti.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["OrnekResim"] != DBNull.Value)
                    {
                        byte[] resimBytes = (byte[])reader["OrnekResim"];
                        using (MemoryStream ms = new MemoryStream(resimBytes))
                        {
                            Image resim = Image.FromStream(ms);
                            pictureBox.Image = resim;
                        }
                    }
                    else
                    {
                        // Eğer resim null ise, PictureBox'i temizleyebilirsiniz.
                        pictureBox.Image = null;
                    }
                }









            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

        }
        public  void stokArttir(int id ,int adet)
        {
            try
            {

                baglanti.Open();
                string sql = $"update Table_Telefonlar set StokAdeti=StokAdeti+{adet} where TelefonId = {id} ";
                command = new SqlCommand(sql, baglanti);
                command.ExecuteNonQuery(); 



            }





            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
            finally
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }


            }

        }

        public void tabloyaEkle(string tabloadi , string deger)
        {

            try
            {

                baglanti.Open();

                string query ="INSERT INTO " + tabloadi + " VALUES (@deger)";

                command = new SqlCommand(query, baglanti);
       
                command.Parameters.AddWithValue("@deger", deger);

                command.ExecuteNonQuery();
                string mesaj = tabloadi + " tablosuna  veri Eklenmiştir";
                MessageBox.Show(mesaj, "Ekleme Başarılı");
                baglanti.Close();
               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
               
            }
            finally
            {
                if (baglanti.State ==System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }

        }
       

        
    }

}
