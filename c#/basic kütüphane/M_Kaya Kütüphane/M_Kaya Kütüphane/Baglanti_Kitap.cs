using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace M_Kaya_Kütüphane
{
    internal class Baglanti_Kitap
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public static int id;

        public void kitap_Liste(DataGridView dataGrid)
        {
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();


                }
                baglanti.Open();

                cmd = new SqlCommand("select Kitap_Ad , Yazar ,Tipi,Hasar_Durumu,Hasar_Tipi,Adet,Sayfa ,Konu from Kitap", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt  = new DataTable();
                da.Fill(dt);
                baglanti.Close(); 
              dataGrid.DataSource = dt;

                
            }
            catch (Exception ex)
            {
                baglanti.Close();
                throw;
                MessageBox.Show(ex.Message+"\nPrgorami Yeniden Baslatin");
                Application.Exit();
                
            }


        }
    
        public void altFiltre(string filtre, ComboBox comboBox1)
        {
            try
            {
                if (baglanti.State==ConnectionState.Open)
                {
                    baglanti.Close(); 

                }
                baglanti.Open();
               

                cmd = new SqlCommand( $"select distinct {filtre}  From Kitap", baglanti);
               
                SqlDataReader dr;
                comboBox1.DataSource = null; 
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
                baglanti.Close();

            }
            catch (Exception)
            {

                throw;
            }



        }
        public DataTable Filtre(string filt1, string filt2)
        {



            baglanti.Open();
            cmd = new SqlCommand("select   Kitap_Ad , Yazar ,Tipi,Hasar_Durumu,Hasar_Tipi,Adet,Sayfa ,Konu from Kitap where  '" + filt1+"'='"+filt2+"'", baglanti);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
           return dt;
        }

     




    }
}
