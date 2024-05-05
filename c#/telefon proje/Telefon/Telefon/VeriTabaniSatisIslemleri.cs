using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    class VeriTabaniSatisIslemleri
    {

        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=telefon;Integrated Security=True");
        private SqlCommand command;

        public  DataTable stokListele(int a)
        {
            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = " SELECT  t.TelefonAdi, m.Marka,t.StokAdeti, r.Renk ,t.Fiyat,t.TelefonId FROM Table_Telefonlar t JOIN Table_Marka m ON t.MarkaID = m.MarkaID JOIN Table_Renk r ON t.RenkId = r.RenkId ";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // SqlParameter ile kullanıcının girdiği isim verisini belirleyin




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

        public DataTable stokListele()
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = " SELECT  t.TelefonAdi, m.Marka,t.StokAdeti, r.Renk ,t.Fiyat,t.TelefonId FROM Table_Telefonlar t JOIN Table_Marka m ON t.MarkaID = m.MarkaID JOIN Table_Renk r ON t.RenkId = r.RenkId WHERE t.StokAdeti > 0";
                SqlCommand cmd = new SqlCommand(query, baglanti);

                // SqlParameter ile kullanıcının girdiği isim verisini belirleyin




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

        public List<string> bilgileriDoldur(int id)
        {
            try
            {
                baglanti.Open();
                List<string> gelenBilgiler = new List<string>();
                // SqlCommand kullanarak verileri seçin
                string query = "SELECT t.TelefonAdi, r.RamBellek, d.DahiliDepolama, ekran.EkranBoyutu, m.Marka, b.BataryaKapasitesi, hs.HizliSarjDestegi, ks.KablosuzSarjDestegi, k.KameraCozunurlugu, onk.OnKameraCozunurlugu, ey.EkranYenilemeHizi, fr.DesteklenenFrekans, p.ParmakIziOkuyucu, rk.Renk, hk.HafizaKartiDestegi, i.IsletimSistemi, c.CikisYili, GarantiSuresi, StokAdeti ,hat.HatSayisi ,t.Fiyat " +
                               "FROM Table_Telefonlar t " +
                               "INNER JOIN Table_Ram_Bellek r ON t.RamBellekID = r.RamBellekId " +
                               "INNER JOIN Table_Dahili_Depolama d ON t.DahiliDepolamaID = d.DahiliDepolamaId " +
                               "INNER JOIN Table_Ekran_Boyutu ekran ON t.EkranBoyutuID = ekran.EkranBoyutuId " +
                               "INNER JOIN Table_Marka m ON t.MarkaID = m.MarkaId " +
                               "INNER JOIN Table_Batarya_Kapasitesi b ON t.BataryaKapasitesiID = b.BataryaKapasitesiId " +
                               "INNER JOIN Table_Kamera_Cozunurlugu k ON t.KameraCozunurluguID = k.KameraCozunurluguId " +
                               "INNER JOIN Table_On_Kamera_Cozunurlugu onk ON t.OnKameraCozunurluguID = onk.OnKameraCozunurluguId " +
                               "INNER JOIN Table_Ekran_Yenileme_Hizi ey ON t.EkranYenilemeHiziID = ey.EkranYenilemeHiziId " +
                               "INNER JOIN Table_Desteklenen_Frekans fr ON t.DesteklenenFrekansID = fr.DesteklenenFrekansId " +
                               "INNER JOIN Table_Parmak_Izi_Okuyucu p ON t.ParmakIziOkuyucuID = p.ParmakIziOkuyucuId " +
                               "INNER JOIN Table_Renk rk ON t.RenkID = rk.RenkId " +
                               "INNER JOIN Table_Hafiza_Karti_Destegi hk ON t.HafizaKartiDestegiID = hk.HafizaKartiDestegiId " +
                               "INNER JOIN Table_Hizli_Sarj_Destegi hs ON t.HizliSarjDestegiID = hs.HizliSarjDestegiId " +
                               "INNER JOIN Table_Kablosuz_Sarj_Destegi ks ON t.KablosuzSarjDestegiID = ks.KablosuzSarjDestegiId " +
                               "INNER JOIN Table_Isletim_Sistemi i ON t.IsletimSistemiID = i.IsletimSistemiId " +
                               " INNER JOIN Table_Hat_Sayisi hat on t.HatSayisiID=hat.HatSayisiId " +
                               "INNER JOIN Table_Cikis_Yili c ON t.CikisYiliID = c.CikisYiliId " +
                               "WHERE t.TelefonID='" + id + "'";



                command = new SqlCommand(query, baglanti);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // gelen verilerin tamamı oknur
                    for (int i = 0; i < reader.FieldCount; i++)
                    {// gelen veri null mu kontrolu yapılır , değilse gelen veri object tipinde alınarak stringe dönüştürlür ve listeye eklenir

                        string veri = reader.IsDBNull(i) ? string.Empty : reader.GetValue(i).ToString();
                        gelenBilgiler.Add(veri);
                    };

                }

                return gelenBilgiler;


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

        public DataTable stokFiltrele(string filtre)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin

                string query = " SELECT  t.TelefonAdi, m.Marka,t.StokAdeti, r.Renk ,t.Fiyat,t.TelefonId FROM Table_Telefonlar t JOIN Table_Marka m ON t.MarkaID = m.MarkaID JOIN Table_Renk r ON t.RenkId = r.RenkId WHERE t.StokAdeti > 0 and TelefonAdi LIKE @name";
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

        public string[] musteriGetir(string tc)
        {
            try
            {

                baglanti.Open();
                command = new SqlCommand($"select MusteriAdi, MusteriAdres,MusteriBakiye,MusteriTelefonNo,MusteriId from Table_Musteriler where MusteriTc={tc}", baglanti);
                List<string> bilgiler = new List<string>();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string bilgi = reader[i].ToString();
                        bilgiler.Add(bilgi);
                    }
                }
                else
                {
                    bilgiler.Add("false");
                }
                return bilgiler.ToArray();
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

        // personel bilgilierni isme göre sorgulayıp dizi çiçnde bilgiler return atıyoruz
        public string[] personelBilgileriniGetir(string isim)
        {
            try
            {

                baglanti.Open();


                command = new SqlCommand($" select p.PersonelCalistigiSubeId ,s.SubeAdi, p.PersonelToplamSatis , p.PersonelToplamSatisAdeti,p.PersonelId from Table_Personeller p inner join Table_Subeler s on p.PersonelCalistigiSubeId=s.SubeId where p.PersonelAdi = @personelAdi", baglanti);
                command.Parameters.AddWithValue("@personelAdi", isim);
                List<string> bilgiler = new List<string>();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string bilgi = reader[i].ToString();
                        bilgiler.Add(bilgi);
                    }
                }
                else
                {
                    bilgiler.Add("false");
                }
                return bilgiler.ToArray();
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



        public void satisTablosubaEkle(int telefonid, int personelid, int musteriid, int subeid,int urunadet)
        {
            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin
               


                string query = "insert into Table_Satislar (TelefonId, PersonelId, MusteriId, SubeId, UrunAdeti) values (@telefonid, @personelid, @musteriid, @subid, @urunadeti)";
                command = new SqlCommand(query, baglanti); // SqlCommand nesnesini önce oluşturun

                command.Parameters.AddWithValue("@telefonid", telefonid);
                command.Parameters.AddWithValue("@personelid", personelid);
                command.Parameters.AddWithValue("@musteriid", musteriid);
                command.Parameters.AddWithValue("@subid", subeid);
                command.Parameters.AddWithValue("@urunadeti", urunadet);

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

     
        public DataTable tarihFiltre(DateTime baslangicTarihi, DateTime bitisTarihi)
        {

            try
            {
                baglanti.Open();

                // SqlCommand ile sorguyu belirleyin
                string formattedParam1 = baslangicTarihi.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string formattedParam2 = bitisTarihi.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string query = "SELECT TelefonAdi , tel.Fiyat,PersonelAdi , MusteriAdi,SubeAdi,UrunAdeti FROM Table_Satislar t " +
                    "inner join Table_Personeller p on p.PersonelId =t.PersonelId " +
                    "inner join  Table_Musteriler m on m.MusteriId = t.MusteriId" +
                    " inner join Table_Subeler s on s.SubeId = t.SubeId " +
                    "inner join Table_Telefonlar tel on tel.TelefonId = t.TelefonId "+
                    
                    "WHERE (SatisTarihi >= @param1 AND SatisTarihi <= @param2) OR (SatisTarihi = @param1 OR SatisTarihi = @param2)";
                SqlCommand cmd = new SqlCommand(query, baglanti);
                cmd.Parameters.AddWithValue("@param1", formattedParam1);
                cmd.Parameters.AddWithValue("@param2", formattedParam2);

                // SqlParameter ile kullanıcının girdiği isim verisini belirleyin
              
              

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


    }
  
}
