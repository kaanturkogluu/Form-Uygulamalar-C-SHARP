using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Telefon
{
    class VeriTabaniPersonel
    {

        // tabloya personel ekleme işlemi yapılacak

        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;
        //personel listesi alma
        public DataTable personelListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT p.PersonelId ,p.PersonelAdi, s.SubeAdi,p.PersonelBaslamaTarihi,p.PersonelToplamSatis,p.PersonelToplamSatisAdeti  FROM Table_Personeller p  INNER JOIN Table_Subeler s ON p.PersonelCalistigiSubeId = s.SubeId";
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

        //silme
        public void personelSil(string id)
        {
            try
            {
                // SqlConnection ile veritabanına bağlanın
                baglanti.Open();
                // SqlCommand ile sorguyu belirleyin
                string query = "DELETE FROM Table_Personeller WHERE PersonelId ='" + id + "' ";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // Sorguyu veritabanına gönderin
                cmd.ExecuteNonQuery();
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

        // filtreleme 
        public DataTable personelFiltrele(string filtre)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = "SELECT p.PersonelId,p.PersonelAdi, s.SubeAdi,p.PersonelBaslamaTarihi,p.PersonelToplamSatis,p.PersonelToplamSatisAdeti  FROM Table_Personeller p  INNER JOIN Table_Subeler s ON p.PersonelCalistigiSubeId = s.SubeId where PersonelAdi LIKE @name";
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


        public int subeIdAl(string subeadi)
        {

            try
            {

                int subeId = 0;

              
                
                  

                    string query = "SELECT SubeId FROM Table_Subeler WHERE SubeAdi = @subeAdi";

                command = new SqlCommand(query, baglanti);
                    
                        command.Parameters.AddWithValue("@subeAdi", subeadi);

                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            subeId = Convert.ToInt32(result);
                        }
                    
                

                return subeId;








            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
           
        }

        public void personelEkle(string ad, string sube)
        {

            try
            {
                baglanti.Open();


                int subeid = subeIdAl(sube);
                string sorgu = "INSERT INTO Table_Personeller(PersonelAdi, PersonelCalistigiSubeId) VALUES(@personelAdi, @personelsubeid)";
                command = new SqlCommand(sorgu, baglanti);

                command.Parameters.AddWithValue("@personelAdi", ad);
                command.Parameters.AddWithValue("@personelsubeid",subeid);
              

                //sorgu calissin

                command.ExecuteNonQuery();
                baglanti.Close();
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
        
       
        public void personelGuncelle(string ad, string sube,string personelId)
        {

            try
            {
                string personelAdi = ad;
                string subeAdi = sube;

                // SubeAdi'na göre SubeId'yi almak için veritabanı sorgusu kullanılır
                string subeIdSorgusu = "SELECT SubeId FROM Table_Subeler WHERE SubeAdi = @subeAdi";
                int subeId;



                command = new SqlCommand(subeIdSorgusu, baglanti);
                    
                        command.Parameters.AddWithValue("@subeAdi", subeAdi);
                        baglanti.Open();
                        subeId = Convert.ToInt32(command.ExecuteScalar());
                    
                

                // PersonelTablosunda güncelleme işlemi gerçekleştirilir
                string personelGuncellemeSorgusu = "UPDATE Table_Personeller SET PersonelCalistigiSubeId = @subeId ,PersonelAdi=@personelAdi WHERE PersonelId = @personelId";



                     command = new SqlCommand(personelGuncellemeSorgusu, baglanti);
                    
                        command.Parameters.AddWithValue("@subeId", subeId);
                        command.Parameters.AddWithValue("@personelAdi", personelAdi);
                command.Parameters.AddWithValue("@personelId", personelId);
               
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            // Güncelleme işlemi başarılı
                        }
                        else
                        {
                            // Güncelleme işlemi başarısız
                        }
               
                    
                
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

        public bool personelGiris(string admin_kul_adi, string admin_sifre)
        {

            try
            {

                bool giris = false;

                baglanti.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi=@kullaniciAdi AND sifre=@sifre and  IsAdmin=0", baglanti);
                command.Parameters.AddWithValue("@kullaniciAdi", admin_kul_adi);
                command.Parameters.AddWithValue("@sifre", admin_sifre);
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    giris = true;
                }






                return giris;


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

        public DataTable personelPerformansFiltrele(string filtre)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = "SELECT p.PersonelAdi ,p.PersonelToplamSatis as 'Miktar' ,p.PersonelToplamSatisAdeti as 'Adet' ,s.SubeAdi ,p.PersonelId from Table_Personeller p inner join Table_Subeler s on p.PersonelCalistigiSubeId =s.SubeId  where PersonelAdi LIKE @name";
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
        public DataTable performansListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT p.PersonelAdi ,p.PersonelToplamSatis as 'Miktar' ,p.PersonelToplamSatisAdeti as 'Adet' ,s.SubeAdi ,p.PersonelId from Table_Personeller p inner join Table_Subeler s on p.PersonelCalistigiSubeId =s.SubeId ";
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

        public bool personelSifresiKontrol(string ad, string sifre)
        {
            try
            {



                baglanti.Open();
                string query = "SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi=@ad and sifre = @sifre";

                command = new SqlCommand(query, baglanti);
                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@sifre", sifre);
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
        public void personelSifreGuncelle(string ad, string yeni_sifre)
        {

            try
            {
                baglanti.Open();
                command = new SqlCommand($"UPDATE Table_Admin SET sifre = @sifre  WHERE kullanici_adi= @ad", baglanti);
                command.Parameters.AddWithValue("@ad", ad);

                command.Parameters.AddWithValue("@sifre", yeni_sifre);
                command.ExecuteNonQuery();
                // Veritabanı bağlantısını açma


                // Sorguyu çalıştırma ve etkilenen satır sayısını alınması


                // Veritabanı bağlantısını kapatma
                baglanti.Close();
                System.Windows.Forms.MessageBox.Show(" Güncelleme İşlemi Başarılı ", "Personel Update");
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
        public bool personelKullaniciAdiKontrol(string kul_adi)
        {
            try
            {



                baglanti.Open();
                string query = "SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi = @Username and Isadmin=0";

                command = new SqlCommand(query, baglanti);
                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@Username", kul_adi);
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
        public bool personelAdKontrol(string adi,string sube)
        {
            try
            {



                baglanti.Open();
                   

                    string query = "SELECT COUNT(*) FROM Table_Personeller p " +
                                   "INNER JOIN Table_Subeler s ON p.PersonelCalistigiSubeId = s.SubeId " +
                                   "WHERE p.PersonelAdi = @personelAdi AND s.SubeAdi = @subeAdi";

                    using (SqlCommand command = new SqlCommand(query, baglanti))
                    {
                        command.Parameters.AddWithValue("@personelAdi", adi);
                        command.Parameters.AddWithValue("@subeAdi", sube);

                        int count = (int)command.ExecuteScalar();
                        return count == 0;
                    }
                 

                
              

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

    }
}
