using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; 
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace M_Kaya_Kütüphane
{
    internal class Baglanti_İslemleri
    {
       public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");

     
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public static int id;
       
      

        public void AdminGirisi(string kuladi, string sifre)
        {

           
            try
            {


                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
  
               
                string sorgu = "SELECT * FROM Admin where Ad=@user AND Sifre=@pass";
              
                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@user", kuladi);
                cmd.Parameters.AddWithValue("@pass", sifre);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Kitap_Admin kitap_Admin = new Kitap_Admin();
                    kitap_Admin.Show(); 
                   
                }
                else
                {
                    MessageBox.Show( "Kullanici Adi veya Şifre Hatali","Giriş Hatasi");
                }

                con.Close();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                

            }
          
        



        }

        public void Temizle(TextBox txt)
        {
            txt.Clear();
        }
        public void Admin_Kayit(string ad , string sifre , string güvenlik_sorusu , string cevap , string referans , string kayit_referans )
        {
            try
            {



              
                  baglanti.Open();

               
             

                SqlCommand komut = new SqlCommand("Select Referans from Admin where  Referans='" + kayit_referans + "' ", baglanti);
                
                SqlDataReader dr = komut.ExecuteReader();

                dr.Read();
                //referans kontrolü 
                if (dr.HasRows == true | kayit_referans== "18744721")
                {
                    dr.Close();

                    // Kayit Kontrolü 

                    SqlCommand tekrar = new SqlCommand("select count(*) from Admin where Ad='" + ad + "'", baglanti);
                    int sonuc = (int)tekrar.ExecuteScalar();
                  
                    if (sonuc == 0)
                    {
                        string kayit = "insert into Admin(Ad,Sifre,Referans,Guvenlik_Sorusu,Cevap , Kaydeden_Referans) values (@ad,@Sifre,@Referans,@Güvenlik_Sorusu ,@Cevap ,@KaydedenReferans)";

                        SqlCommand komut2 = new SqlCommand(kayit, baglanti);

                        komut2.Parameters.AddWithValue("@ad", ad);
                        komut2.Parameters.AddWithValue("@Sifre", sifre);
                        komut2.Parameters.AddWithValue("@Güvenlik_Sorusu", güvenlik_sorusu);
                        komut2.Parameters.AddWithValue("@Cevap", cevap);
                        komut2.Parameters.AddWithValue("@Referans", referans);
                        komut2.Parameters.AddWithValue("@KaydedenReferans", kayit_referans);
                  

                        komut2.ExecuteNonQuery();

                        baglanti.Close();
                        MessageBox.Show("Admin Basariyla Eklendi ", "Admin Ekleme");


                    }
                    else
                    {


                        dr.Close();

                        baglanti.Close();

                        MessageBox.Show(ad + " İsminde Kayit Bulunmaktadir\nBaşka Bir İsim Veya İsim Basina Branş Ekleyin\n Örn :\nAli:\n Türkce Ali  ", "Ayni İsimde Birden Fazla Kayit Bulunamaz");

                    }










                    // Kontrol SOnu


                   
                }
                else
                {
                    baglanti.Close(); 
                    MessageBox.Show("Girilen Referans Numarasi Geçerli Değildir \nDoğru Bir Referans Numarasi Yada Varsayilan Anahtari Kullanarak Ekleme Yapin","Hatali Referans");
                }

              
            }
            catch (Exception hata)
            {
                baglanti.Close();
                MessageBox.Show("İşlem Sırasında Hata Oluştu.\n Eğer Bu hatayi aliyorsaniz hata mesahini Kaydedin" + hata.Message);
            }




        }

        public void Kutuphane_Sorumlusu_Ekle(string ad , string sifre , string kaydeden_ref)
        {

            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close(); 
            }
            baglanti.Open();
            SqlCommand tekrar = new SqlCommand("select count(*) from Kutuphane_Sorumlusu where Ad='" + ad + "'", baglanti);
            int sonuc = (int)tekrar.ExecuteScalar();

            if (sonuc == 0)
            {

               
                SqlCommand cmd = new SqlCommand("insert into Kutuphane_Sorumlusu (Ad,Sifre,Kaydeden_Referans) values ('" + ad + "','" + sifre + "','" + kaydeden_ref + "')", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayit Başarı İle Tamamlandı ", "Başarılı Kayıt");



            }
            else
            {




                baglanti.Close();

                MessageBox.Show(ad + " İsminde Kayit Bulunmaktadir\nFarkli Bir İsimde EKleme Yapiniz ", "Ayni İsimde Birden Fazla Kayit Bulunamaz");

            }
            baglanti.Close();

           
          





        }
        public void Refernas_Kontrol(string referans,string ad , string sifre,string kaydeden_ref)
        {
            if(baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close(); 
            }
                    

            baglanti.Open();




            SqlCommand komut = new SqlCommand("Select Referans from Admin where  Referans='" + referans + "' ", baglanti);

            SqlDataReader dr = komut.ExecuteReader();

            dr.Read();
           
            if (dr.HasRows == true | referans == "18744721")
            {
                Kutuphane_Sorumlusu_Ekle(ad,sifre,kaydeden_ref);
            }
            else
            {
                MessageBox.Show("Girilen Refernas Kodu Sistemde Bulunmamaktadir , Geçerli Bir Referans Kodu veya\n Def Key ile kayit Yapiniz","Referan Kodu Hatasi");
            }

        }

       public bool  Admin_Sifre_Yenile( string admin)
       {
            bool kontrol = false; 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select Referans from Admin where  Ad='" + admin + "' ", baglanti);

            SqlDataReader dr = komut.ExecuteReader();

            dr.Read();
            //referans kontrolü 
            if (dr.HasRows == true)
            {// admin var ise yapilcaklar

                Admin_Sifre_Yenile adminformu = new Admin_Sifre_Yenile();
                kontrol = true;
               


                baglanti.Close(); 
            }
            else
            {
                kontrol = false; 
                baglanti.Close();
                MessageBox.Show("Girilen "+ admin+" ismi ile eşleşen kayit bulunmamaktadir\nBüyük Küçük Harflere Dikkat Ederek Tekrar Deneyin");
            }

            return kontrol; 

        }

    


       public string SifreYenile(string ad )
        {
            string guvenlik_sorusu = "";
            baglanti.Open(); 

            SqlCommand cmd = new SqlCommand("select Guvenlik_Sorusu from Admin where Ad = '"+ad+"'",baglanti);
           
           

            SqlDataReader dr = cmd.ExecuteReader();
          
          
          
            while (dr.Read())
            {
              guvenlik_sorusu= dr["Guvenlik_Sorusu"].ToString();
            }



            baglanti.Close();

            return guvenlik_sorusu;

           

        }


        public void Sifre_Cevap(string ad,string cevap)
        {
           if( baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("select Cevap from Admin where Ad = '" +ad+ "'" , baglanti);


            string sonuc = (string)cmd.ExecuteScalar();
            if( cevap == sonuc)
            {
                Admin_Sifre_Sifirlama admin = new Admin_Sifre_Sifirlama();
                admin.ShowDialog();
              
            }
            else
            {
                MessageBox.Show("Hatali Giriş\nAnasayfaya Yönelendiriliyorsunuz","Hatali Cevap Girişi");
            }
           
            baglanti.Close();












        }

        public  int idAl(string adminad,string userstatment ) {

            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
                sql.Open();
              
                SqlCommand cmd = new SqlCommand($"select id from {userstatment} where Ad ='" + adminad + "'",sql);
               

                return (int)cmd.ExecuteScalar();
                sql.Close();
              
            }
            catch (Exception ex)
            {
                //if(baglanti.State == System.Data.ConnectionState.Open)
                //{
                //    baglanti.Close(); 
                //}
                //MessageBox.Show("Bu mesaji aliyorsniz , Hata Mesajini Not aliniz:\n'"+ex.ToString()+"'","Hata İletisi");
                throw;
            }
           



        }
        public int idAl_Sorumludan(string adminad)
        {

            try
            {
                SqlConnection sql = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
                sql.Open();

                SqlCommand cmd = new SqlCommand($"select id from Kutuphane_Sorumlusu where Ad ='" + adminad + "'", sql);


                return (int)cmd.ExecuteScalar();
                sql.Close();

            }
            catch (Exception ex)
            {
                //if(baglanti.State == System.Data.ConnectionState.Open)
                //{
                //    baglanti.Close(); 
                //}
                //MessageBox.Show("Bu mesaji aliyorsniz , Hata Mesajini Not aliniz:\n'"+ex.ToString()+"'","Hata İletisi");
                throw;
            }




        }

        public void yeniSifre(string yenisifre)
        {

            try
            {
                baglanti.Open();
                string kayit = "update Admin set Sifre=@sifre  where id='"+id+"'";
                SqlCommand komut = new SqlCommand(kayit, baglanti);
               
                komut.Parameters.AddWithValue("@sifre", yenisifre);
              
              
                komut.ExecuteNonQuery();
             
                baglanti.Close();
              
            }
            catch (Exception ex)
            {
                //if (baglanti.State == System.Data.ConnectionState.Open)
                //{
                //    baglanti.Close();
                //}
                //MessageBox.Show("Bu mesaji aliyorsniz , Hata Mesajini Not aliniz:\n'" + ex.ToString() + "'", "Hata İletisi");
                //throw;
            }

        }

       void grpbox_Enabled(GroupBox grp)
        {
            grp.Enabled = true; 
        }
        public void Giris_Kontrol_Admin(string ad, string sifre,GroupBox group)

        {
            Sifre_Degistir sifre_ = new Sifre_Degistir();


            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");


            string sorgu = "SELECT * FROM Admin where Ad=@user AND Sifre=@pass";

            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", ad);
            cmd.Parameters.AddWithValue("@pass", sifre);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                grpbox_Enabled(group);
                



            }
            else
            {
                MessageBox.Show("Kullanici Adi veya Şifre Hatali", "Giriş Hatasi");
            }

            con.Close();




        }
       
        public void Giris_Kontrol_Sorumlu(string ad , string sifre,GroupBox group)
        {
            Sifre_Degistir sifre_ = new Sifre_Degistir();


            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");


            string sorgu = "SELECT * FROM Kutuphane_Sorumlusu where Ad=@user AND Sifre=@pass";

            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", ad);
            cmd.Parameters.AddWithValue("@pass", sifre);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                grpbox_Enabled(group);

               

            }
            else
            {
                MessageBox.Show("Kullanici Adi veya Şifre Hatali", "Giriş Hatasi");
            }

            con.Close();


        }

        public void Sifreyi_Degistir(string sifre , int idd,string userstatment)
        {
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close(); 

            }
            try
            {
                baglanti.Open();
                string kayit = $"update {userstatment} set Sifre=@sifre  where id='" + idd + "'";
                SqlCommand komut = new SqlCommand(kayit, baglanti);

                komut.Parameters.AddWithValue("@sifre", sifre);


                komut.ExecuteNonQuery();

                baglanti.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Sifreyi_Kontrol_Et(string eskisifre,int idd,string yenisifre,string usert_statment)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");


            string sorgu = $"SELECT Sifre FROM {usert_statment} where id=@user AND Sifre=@pass";

            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", idd);
            cmd.Parameters.AddWithValue("@pass", eskisifre);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Sifreyi_Degistir(yenisifre,idd,usert_statment);
                MessageBox.Show("Sifre Basariyla Değiştirildi","Succes");
            }
            else
            {
                MessageBox.Show("Eski Şifreyi Hatali Girdiniz ", "Giriş Hatasi");
            }

            con.Close();
        }

        public void Sorumlu_Girisi(string kul_adi, string sifre)
        {

            try
            {


                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");


                string sorgu = "SELECT * FROM Kutuphane_Sorumlusu where Ad=@user AND Sifre=@pass";

                cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@user", kul_adi);
                cmd.Parameters.AddWithValue("@pass", sifre);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Kitap admin = new Kitap();
                    admin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kullanici Adi veya Şifre Hatali", "Giriş Hatasi");
                }

                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }


    }


}
