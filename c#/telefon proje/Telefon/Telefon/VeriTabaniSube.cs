using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefon
{
    class VeriTabaniSube
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;
      
        public DataTable aktifSubeListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT  SubeId , SubeAdi , SubeAdres,SubePersonelSayisi , SubeToplamSatis, SubeToplamSatisAdeti FROM Table_Subeler where SubeAktif=1";
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
        public DataTable tumSubeListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT  SubeId , SubeAdi ,SubeAktif as 'Acık/Kapalı', SubeAdres,SubePersonelSayisi , SubeToplamSatis, SubeToplamSatisAdeti FROM Table_Subeler";
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
        public string[] subeBilgileri(string subeadi)
        {

            try
            {
                string query = "SELECT * FROM Table_Subeler WHERE SubeAdi = @SubeAdi";

                // Verileri saklamak için bir string dizisi oluşturun
                string[] data = new string[4];

                // Bağlantıyı açın ve sorguyu çalıştırın
            
                
                     command = new SqlCommand(query, baglanti);
                    command.Parameters.AddWithValue("@SubeAdi", subeadi);
                    baglanti.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Verileri diziye aktarın
                        data[0] = reader["SubeAdi"].ToString();
                        data[1] = reader["SubePersonelSayisi"].ToString();
                        data[2] = reader["SubeAdres"].ToString();
                       data[3]= reader["SubeId"].ToString();

                }

                    reader.Close();
                

                return data;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (baglanti.State==System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
        public DataTable subeFiltrele(string filtre)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = "SELECT * FROM Table_Subeler  WHERE SubeAdi LIKE @name";
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
        public void subeGuncelle(string id,string SubeAdres, string subead )
        {

            try
            {
                baglanti.Open();
                command = new SqlCommand($"UPDATE Table_Subeler  SET SubeAdres = @adres , SubeAdi = @ad  WHERE SubeId= @id", baglanti);

                command.Parameters.AddWithValue("@adres", SubeAdres);
                command.Parameters.AddWithValue("@ad", subead);
                command.Parameters.AddWithValue("@id", id);

               
                command.ExecuteNonQuery();
                // Veritabanı bağlantısını açma


                // Sorguyu çalıştırma ve etkilenen satır sayısını alınması


                // Veritabanı bağlantısını kapatma
                baglanti.Close();
                System.Windows.Forms.MessageBox.Show(" Güncelleme İşlemi Başarılı ", "Sube Update");
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
        public void subeSil(string id )
        {
            try
            {
                
                // SqlConnection ile veritabanına bağlanın
                baglanti.Open();
                // SqlCommand ile sorguyu belirleyin
               
                string query = "Update  Table_Subeler Set SubeAktif=0 where SubeId ='" + id+"'";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // Sorguyu veritabanına gönderin
                cmd.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show(" Silme İşlemei Başarılı ", "Sube Silme");
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

        public void subeEkle(params string[] sube_bilgiler)
        {
            try
            {



                baglanti.Open();





                // INSERT sorgusu hazırlama
                string query = "INSERT INTO Table_Subeler  (SubeAdi, SubeAdres) VALUES (@subead, @subeadres)";
                command = new SqlCommand(query, baglanti);

                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@subead", sube_bilgiler[0]);
                command.Parameters.AddWithValue("@subeadres", sube_bilgiler[1]);


            

                // Sorguyu çalıştırma
                command.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Sube Ekleme Başarılı","Sube Ekleme ",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);







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
