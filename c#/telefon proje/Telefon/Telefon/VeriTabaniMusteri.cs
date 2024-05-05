using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefon
{
    class VeriTabaniMusteri
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;


        //musteri eklemek için paramtre olrak dizi alan metot
        public void musteriEkle(string[] musteri_bilgiler)
        {
            try
            {



                baglanti.Open();





                // INSERT sorgusu hazırlama
                string query = "INSERT INTO Table_Musteriler (MusteriAdi, MusteriTelefonNo,MusteriTc,MusteriAdres,MusteriBakiye) VALUES (@adi, @telefon, @tc,@Adres, @bakiye)";
                command = new SqlCommand(query, baglanti);

                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@adi", musteri_bilgiler[0]);
                command.Parameters.AddWithValue("@telefon", musteri_bilgiler[1]);


                command.Parameters.AddWithValue("@tc", musteri_bilgiler[2]);

                command.Parameters.AddWithValue("@Adres", musteri_bilgiler[3]);
                command.Parameters.AddWithValue("@bakiye", float.Parse( musteri_bilgiler[4]));
                // Sorguyu çalıştırma
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
        public DataTable musteriListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT * FROM Table_Musteriler";
                command = new SqlCommand(query, baglanti);

                // SqlDataAdapter ile verileri bir DataTable'e yükleyin
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                return dataTable;
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

        public bool musteritcKontrol(string tc)
        {
            bool exists = false;


            baglanti.Open();

            string query = "SELECT COUNT(*) FROM Table_Musteriler WHERE MusteriTc = @tc";
            SqlCommand command = new SqlCommand(query, baglanti);
            command.Parameters.AddWithValue("@tc", tc);

            int count = (int)command.ExecuteScalar();

            if (count > 0)
            {
                exists = true;
            }

            baglanti.Close();
            return exists;
        }
        public DataTable müsteriFiltrele(string filtre)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = "SELECT * FROM Table_Musteriler WHERE MusteriAdi LIKE @name";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // SqlParameter ile kullanıcının girdiği isim verisini belirleyin
                string inputName = filtre;
                SqlParameter param = new SqlParameter("@name", "%" + inputName + "%");
                cmd.Parameters.Add(param);

                // SqlDataReader ile sorgudan verileri okuyun
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
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
        public void musteriSil(string id)
        {
            try
            {
                // SqlConnection ile veritabanına bağlanın
                baglanti.Open();
                // SqlCommand ile sorguyu belirleyin
                string query = "DELETE FROM Table_Musteriler WHERE MusteriId ='" + id + "' ";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // Sorguyu veritabanına gönderin
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Silme İslemi Tamamlandı","Silme");
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

        public bool musteriTcKotrol(string tc)
        {
            try
            {



                baglanti.Open();
                string query = "SELECT COUNT(*) FROM Table_Musteriler WHERE MusteriTc= @tc";

                command = new SqlCommand(query, baglanti);
                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@tc", tc);
                // Sorguyu çalıştırma ve sonucu alıp döndürme
                int count = (int)command.ExecuteScalar();
                //eğer var ise true , yok ise false dönecek
                return (count > 0);

            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
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

        public void musteriGuncelle(string ad, string tc,string bakiye, string telefon ,string adres,int id)
        {

            try
            {
                baglanti.Open();
                command = new SqlCommand("UPDATE Table_Musteriler SET MusteriAdi = @Ad, MusteriTc = @tc ,MusteriAdres=@adres, MusteriBakiye= @bakiye, MusteriTelefonNo=@telefon WHERE MusteriId = @Id", baglanti);
                command.Parameters.AddWithValue("@Ad", ad);
                command.Parameters.AddWithValue("@bakiye", bakiye);
                command.Parameters.AddWithValue("@tc", tc); 
                command.Parameters.AddWithValue("@adres", adres);
                command.Parameters.AddWithValue("@telefon", telefon);


                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                // Veritabanı bağlantısını açma


                // Sorguyu çalıştırma ve etkilenen satır sayısını alınması


                // Veritabanı bağlantısını kapatma
                baglanti.Close();
                System.Windows.Forms.MessageBox.Show("Güncelleme İşlemi Başarılı ", "Müsteri Update");
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

        public void musteriHarcama(int musteriid, string harcama)
        {
            try
            {



                baglanti.Open();

                string query = "update Table_Musteriler set MusteriBakiye= MusteriBakiye - @harcama , MusteriToplamHarcama = @harcama where MusteriId=@id  ";

                command = new SqlCommand(query, baglanti);
                command.Parameters.AddWithValue("@harcama",decimal.Parse( harcama));
                command.Parameters.AddWithValue("@id",musteriid);
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
    }
}
