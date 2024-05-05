using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    public partial class Personel_İslemleri : Form
    {
        public Personel_İslemleri()
        {
            InitializeComponent();

        }
        public void comboBoxDoldur()
        {
            try
            {
                string query = "SELECT SubeAdi FROM Table_Subeler where SubeAktif =1";

                // Bağlantıyı açın ve sorguyu çalıştırın
                vt_personel.baglanti.Open();

                SqlCommand command = new SqlCommand(query, vt_personel.baglanti);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Her satırdaki SubeAdi değerini ComboBox'a ekleyin
                    comboBox1.Items.Add(reader["SubeAdi"].ToString().Trim());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (vt_personel.baglanti.State == ConnectionState.Open)
                {
                    vt_personel.baglanti.Close();
                }
            }


        }

        VeriTabaniPersonel vt_personel = new VeriTabaniPersonel(); 
        private void Personel_İslemleri_Load(object sender, EventArgs e)
        {
           

            listele();
            comboBoxDoldur();


        }

        void listele()
        {
            dtgri_personel_liste.DataSource = vt_personel.personelListeleTable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgri_personel_liste.DataSource = vt_personel.personelFiltrele(textBox1.Text); 
        }

     
        int id; 
        private void dtgri_personel_liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dtgri_personel_liste.CurrentRow.Cells["PersonelId"].Value.ToString().Trim());
           
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (id==0)

            {
                MessageBox.Show("Silinecek Kişiyi Seçin");
            }
            else
            {


                if (DialogResult.OK == MessageBox.Show("Silme İşlemini Onaylayın", "Silme işlemi onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    vt_personel.personelSil(id.ToString());

                    listele();
                    MessageBox.Show("işlem işlemi başarı ile yapıldı", "Silme ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("işlem iptal edildi", "Silme iptal Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        string subeid; 
        private void button2_Click(object sender, EventArgs e)
        {
            // ad girilmiş mi kontrolü 
            if (textBox2.Text=="")
            {
                MessageBox.Show("Veri Girişini Sağlayın");
            }
            else
            {

                if (comboBox1.SelectedIndex != -1)
                {
                    if (vt_personel.personelAdKontrol(textBox2.Text,comboBox1.SelectedItem.ToString()))
                    {
                        if (DialogResult.Yes == MessageBox.Show("Ekleme İşlemini Onaylıyor Musunuz?", "Ekleme Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
                        {
                            vt_personel.personelEkle(textBox2.Text, comboBox1.SelectedItem.ToString());
                            listele();
                            MessageBox.Show("Ekleme Tamamlandı");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seçilen Şubede Aynı İsimde Bir Çalışan Bulunmaktadır","Farklı isim veya sube seçin");
                    }

                 
                   
                }
                else
                {
                    MessageBox.Show("Şube Seçimi Yapınız");
                }
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        //güncelleme islemleri
        private void button3_Click(object sender, EventArgs e) {

            // isim kontrolü
            if (textBox2.Text == "")
            {
                MessageBox.Show("Veri Girişini Sağlayın");



            }
          
            else
            {  // kişi seçilmiş mi kontrolü
                if (id == 0)

                {
                    MessageBox.Show("Güncellenecek Kişiyi Seçin");
                }
                else
                {
                    //şube seçimi kontrolü
                    if (comboBox1.SelectedIndex !=-1)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Güncellemeyi Onaylayın", "Güncelleme Onay", MessageBoxButtons.YesNo))
                        {

                            vt_personel.personelGuncelle(textBox2.Text, comboBox1.SelectedItem.ToString(), id.ToString());
                            listele();
                            MessageBox.Show("İşlem Başarı ile Gerçekleşti", "İşlem Tamamlandı");
                        }
                        else
                        {
                            MessageBox.Show("İşlem İptal Edildi", "İşlem İptali");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şube Seçimi Kontrol Ediniz","Şube Seçimi");
                    }
                 
                }

            }
{

}
            
        }
    }
}
