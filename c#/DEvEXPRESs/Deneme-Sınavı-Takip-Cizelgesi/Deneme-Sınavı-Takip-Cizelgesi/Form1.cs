using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme_Sınavı_Takip_Cizelgesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ogrenciler ogrenciler = new ogrenciler(); 
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ogrenciler ogrenciler = new ogrenciler();
            ogrenciler.MdiParent = this;
            ogrenciler.Show(); 
             
            
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Ekle ekle = new Ekle();
            ekle.MdiParent = this;
            ekle.Show(); 
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sil sil = new Sil();
            sil.MdiParent = this;
            sil.Show();


            
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Deneme deneme = new Deneme();
            deneme.MdiParent = this;
            deneme.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SınavSonucu sınavSonucu = new SınavSonucu();
            sınavSonucu.MdiParent = this;
            sınavSonucu.Show();
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string kayityolu = "";
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            
            save.InitialDirectory = @"D:\";
            save.Title = "DenemeTakipYedekDosyası";
         
            save.Filter = "Bak Dosyalari(.bak)|.bak|Tüm Dosyalar(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Kayit = new StreamWriter(save.FileName);
               
             
                Kayit.Close();
                try
                {
                    SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DenemeTakip;Integrated Security=True");
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("BACKUP DATABASE DenemeTakiP TO DISK ='" + save.FileName + DateTime.Now.ToString("yyyyMMdd") + ".bak'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Yedekleme Basarili");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }


          



        }
    }
}
