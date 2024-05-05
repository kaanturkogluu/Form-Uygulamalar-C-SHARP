using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Telefon
{
    class VeriTabaniAdmin
    {
        // Veritabanı bağlantı dizesi

        public SqlConnection baglantı = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;

        // veri tabanından admin girisi 

        public bool adminGiris(string admin_kul_adi, string admin_sifre)
        {

            try
            {

                bool giris = false;

                baglantı.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi=@kullaniciAdi AND sifre=@sifre and  IsAdmin=1", baglantı);
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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }

            }

        }
       



        public bool adminReferansKontrol(string referans)
        {
            try
            {


                bool onay = false;
                baglantı.Open();
                SqlCommand command = new SqlCommand("SELECT referans FROM Table_Admin", baglantı);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    if (reader["referans"].ToString() == referans)
                    {
                        onay = true;

                    }



                }

                return onay;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
                throw;
            }
            finally
            {
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }


        }
        public bool adminKullaniciAdiKontrol(string kul_adi)
        {
            try
            {



                baglantı.Open();
                string query = "SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi = @Username";

                command = new SqlCommand(query, baglantı);
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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }
        }

        public void adminEkle(string[] admin_bilgiler)
        {
            try
            {



                baglantı.Open();





                // INSERT sorgusu hazırlama
                string query = "INSERT INTO Table_Admin (kullanici_adi, sifre, referans,ekleyen_referans,Isadmin) VALUES (@Username, @Password, @Reference,@added_reference,@isadmin)";
                command = new SqlCommand(query, baglantı);

                // Parametreleri ayarlama
                command.Parameters.AddWithValue("@Username", admin_bilgiler[0]);
                command.Parameters.AddWithValue("@Password", admin_bilgiler[1]);


                command.Parameters.AddWithValue("@Reference", admin_bilgiler[2]);

                command.Parameters.AddWithValue("@added_reference", admin_bilgiler[3]);
                command.Parameters.AddWithValue("@isadmin",Convert.ToBoolean( admin_bilgiler[4]));
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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }
        }
        public DataTable adminListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT kullanici_adi as 'AD',referans as 'REFERANS', ekleyen_referans as 'Ekleyen Admin', AdminId as 'ID' FROM Table_Admin where Isadmin=1";
                command = new SqlCommand(query, baglantı);
              

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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }

            }




        }
        public DataTable personeladminListeleTable()
        {

            try
            {
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT kullanici_adi as 'AD',referans as 'REFERANS', ekleyen_referans as 'Ekleyen Admin', AdminId as 'ID' FROM Table_Admin where Isadmin=0";
                command = new SqlCommand(query, baglantı);


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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }

            }




        }

        public void adminSil(string ad)
        {
            try
            {
                // SqlConnection ile veritabanına bağlanın
                baglantı.Open();
                // SqlCommand ile sorguyu belirleyin
                string query = "DELETE FROM Table_Admin WHERE kullanici_adi ='" + ad + "' ";
                SqlCommand cmd = new SqlCommand(query, baglantı);

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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }
            }








        }
        public bool sifreKarsilastir(string sifre, string sifre_tekrar)
        {
            bool sonuc = false;

            if (sifre == sifre_tekrar)
            {
                sonuc = true;
            }
            return sonuc;
        }
        public DataTable adminFiltrele(string filtre)
        {

            try
            {
                baglantı.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = "SELECT AdminId as'ID',kullanici_adi as 'AD',ekleyen_referans as 'REFERANS' FROM Table_Admin WHERE kullanici_adi LIKE @name";
                SqlCommand cmd = new SqlCommand(query, baglantı);

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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }
            }



        }

        public bool adminSifresiKontrol(string ad, string sifre)
        {
            try
            {



                baglantı.Open();
                string query = "SELECT COUNT(*) FROM Table_Admin WHERE kullanici_adi=@ad and sifre = @sifre";

                command = new SqlCommand(query, baglantı);
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
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }






        }
        public void adminGuncelle(string ad, string referans, int id)
        {

            try
            {
                baglantı.Open();
                command = new SqlCommand($"UPDATE Table_Admin SET kullanici_adi = @Ad, referans = @Referans WHERE AdminId = @Id", baglantı);
                command.Parameters.AddWithValue("@Ad", ad);
                command.Parameters.AddWithValue("@Referans", referans);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
                // Veritabanı bağlantısını açma


                // Sorguyu çalıştırma ve etkilenen satır sayısını alınması


                // Veritabanı bağlantısını kapatma
                baglantı.Close();
                System.Windows.Forms.MessageBox.Show("Güncelleme İşlemi Başarılı ", "Admin Update");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
            finally
            {
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }
        }
        // metodu overload yapıyoruz ada göre update atıyoruz
        public void adminGuncelle(string ad, string yeni_sifre)
        {

            try
            {
                baglantı.Open();
                command = new SqlCommand($"UPDATE Table_Admin SET sifre = @sifre  WHERE kullanici_adi= @ad", baglantı);
                command.Parameters.AddWithValue("@ad", ad);

                command.Parameters.AddWithValue("@sifre", yeni_sifre);
                command.ExecuteNonQuery();
                // Veritabanı bağlantısını açma


                // Sorguyu çalıştırma ve etkilenen satır sayısını alınması


                // Veritabanı bağlantısını kapatma
                baglantı.Close();
                System.Windows.Forms.MessageBox.Show(" Güncelleme İşlemi Başarılı ", "Admin Update");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

                throw;
            }
            finally
            {
                if (baglantı.State == System.Data.ConnectionState.Open)
                {
                    baglantı.Close();
                }


            }
        }


        // veri tabanı yedeklemek için metot 
        public void VeritabaniYedekle()
        { // klasör yolu oluşturuluyor 
            string klasor = "C://" + DateTime.Now.ToShortDateString();
            Directory.CreateDirectory(klasor);


            try
            {
                // Veritabanı bağlantısını açın
                baglantı.Open();
                command = new SqlCommand();
                // sorgu parametreler ile backup işlemi yapıypr 
                command = new SqlCommand(@"backup database telefon to disk = @directory with init,stats=10", baglantı);
                command.Parameters.AddWithValue("@directory", string.Concat("C://", DateTime.Now.ToShortDateString(), "/telefon.bak"));
                command.ExecuteNonQuery();


                MessageBox.Show($"Veritabanı yedeği \n C: Dizinine -- {DateTime.Now.ToShortDateString()}-- adı ile \nKlasörüne  başarıyla oluşturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Veritabanı bağlantısını kapatın
                baglantı.Close();
            }


        }




    }
}
