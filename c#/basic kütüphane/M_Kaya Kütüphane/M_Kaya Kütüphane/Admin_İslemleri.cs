using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace M_Kaya_Kütüphane
{
    internal class Admin_İslemleri
    {

        SqlCommand cmd; 


        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
      

        public static string Ad{ get; set; }
        public static int id { get; set; }

        public string Referans_Goster(string Admin)
        {      SqlConnection baglantim = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");

            baglanti.Close(); 

            baglanti.Open(); 
            cmd = new SqlCommand("select Referans from Admin where  Ad='"+Admin+"'",baglanti);
             string referans = (string)cmd.ExecuteScalar();
            baglanti.Close();

            return referans; 
           
        }
        public string Sfire_Kontrol(string statment, int id )
        {
            baglanti.Close(); 
            baglanti.Open();
            cmd = new SqlCommand($"select Sifre from {statment} where id='"+id+"'", baglanti);

            string sifre = (string) cmd.ExecuteScalar();
            return sifre; 
        }

    }
}
