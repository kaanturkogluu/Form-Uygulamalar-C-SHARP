using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Telefon
{
    public partial class AnaSayfa : Form
    {
        int admin;
        public AnaSayfa(int admin)
        {
            InitializeComponent();
            this.admin = admin; 
        }

        private void telefonSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void personelEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel_İslemleri personel = new Personel_İslemleri();
            personel.Show(); 
        }

        private void adminEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // admin ekleme  sayfasını açan satır
            AdminEkleme admin = new AdminEkleme();
            admin.ShowDialog(); 
           
        }

        private void adminSilmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // admin silme sayfasını açan satır
            Admin_Silme admin_Silme = new Admin_Silme();
            admin_Silme.Show(); 
        }

        private void adminGüncellemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // güncelleme sayfasını açan satır
            AdminGüncelle admin = new AdminGüncelle();
            admin.Show();
        }

        private void adminListesiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // admin listesi sayfasını açan satır
            Admin_Liste admin = new Admin_Liste();
            admin.Show();

        }
        // admin sifre güncelleme sayfasını açan satır
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Sifre_Güncelleme admin = new Admin_Sifre_Güncelleme();
            admin.Show(); 
        }

        VeriTabaniSatisIslemleri vt_satis = new VeriTabaniSatisIslemleri();
        public void stokListele()
        {
            dtgrid_stok.DataSource = vt_satis.stokListele(); 
        }
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            stokListele();
            tablolarıListele();
        }



        private void tabloclick(object sender, EventArgs e )
        {
            string tabloadi = sender.ToString();
            TabloEkle tb = new TabloEkle(tabloadi,tabloadlari);
            tb.ShowDialog(); 



        }




        // veri tabanındaki tablo isimlerini alalım mennu ye aktaralım
        List<string> tabloadlari = new List<string>();
        public void tablolarıListele()
        {
           
            
                try
                {
                    vt_admin.baglantı.Open();

                    // Tablo adlarını almak için sorguyu oluştur
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

                    SqlCommand command = new SqlCommand(query, vt_admin.baglantı);

                    // Verileri oku
                    SqlDataReader reader = command.ExecuteReader();

                // Tablo adlarını ToolStripMenuItem'a ekle
                int say = 0;
                    while (reader.Read())
                    {
                    if(say !=0 & say < 18)
                    {
                       string tableName = reader.GetString(0);
                        tabloadlari.Add(tableName);
                        tableName = reader.GetString(0).Replace("Table_", "").Replace("_", "");
                        ToolStripMenuItem tableMenuItem = new ToolStripMenuItem(tableName);
                        tableMenuItem.Click += tabloclick;

                        verilerToolStripMenuItem.DropDownItems.Add(tableMenuItem);
                    }
                    say++;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    vt_admin.baglantı.Close();
                }
            
        

    }
        VeriTabaniAdmin vt_admin = new VeriTabaniAdmin();
        private void yedekAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vt_admin.VeritabaniYedekle();
          

        }

        private void veriTabanıTablolarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tablo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri_Islemleri musteri = new Musteri_Islemleri(admin);
            musteri.Show(); 
        }

        private void şubeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sube_İslemleri sube = new Sube_İslemleri();
            sube.Show();
        }

        private void şubeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sube_Liste sube_Liste = new Sube_Liste();
            sube_Liste.Show(); 
        }

        private void personelListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel_Liste personel_Liste = new Personel_Liste();
            personel_Liste.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dtgrid_stok_DoubleClick(object sender, EventArgs e)
        {
           

        }

        private void dtgrid_stok_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Sadece satırın üzerine tıklanmışsa devam et
            {
                DataGridViewRow selectedRow = dtgrid_stok.Rows[e.RowIndex];
                // id stununu diğer forma aktarmak için alioz
                int selectedId = Convert.ToInt32(selectedRow.Cells["TelefonId"].Value);

                // Yeni formu açmak ve Id değerini iletmek için kodu buraya ekleyin

                Telefon_Bilgileri yeniForm = new Telefon_Bilgileri(selectedId,lbl_isAdmin.Text);
                yeniForm.ShowDialog();
            }
        }

      
        private void stokİşlemiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            stokListele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgrid_stok.DataSource = vt_satis.stokFiltrele(textBox1.Text);
            
        }

        private void yeniTelefonKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok();
            stok.ShowDialog();
           
        }

        private void stokArttırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokArttır stokArttır = new StokArttır();
            stokArttır.ShowDialog(); 

        }

        private void geçmişSatışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GecmisSatıslar gecmisSatıslar = new GecmisSatıslar();
            gecmisSatıslar.ShowDialog(); 
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Uygualamayı kapatır
            Application.Exit();
        }

        private void girişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giris giris = new Giris();
            this.Hide(); 
            giris.ShowDialog();

        }

        private void performansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonelPerformans personel = new PersonelPerformans();
            personel.ShowDialog(); 
        }

        private void personelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PersonelSifreGuncelle psfre = new PersonelSifreGuncelle();
            psfre.ShowDialog();
        }

        private void verilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

        }
      

      
    }
}
