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
    public partial class Sube_İslemleri : Form
    {
        public Sube_İslemleri()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Güncelle";
            temizle(txt_sube_adi);
            if(  radioButton1.Checked==true )
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }
      VeriTabaniSube vt_sube = new VeriTabaniSube(); 
        private void Sube_İslemleri_Load(object sender, EventArgs e)
        {



            comboBoxDoldur();

        }

        void temizle(TextBox text)
        {
            if (text.Text!="")
            {
                txt_personel_sayisi.Clear();
                txt_adres.Clear();
                txt_sube_adi.Clear();
            }
        }
        //güncelleme sonrası temizleme
        void temizle()
        {
            txt_personel_sayisi.Clear();
            txt_adres.Clear();
            txt_sube_adi.Clear();
        }

        // mevcut subeleri comboboxa aktrıyoruz
        public void comboBoxDoldur()
        {
            try
            {
                string query = "SELECT SubeAdi FROM Table_Subeler where SubeAktif=1";


                // Bağlantıyı açın ve sorguyu çalıştırın
                vt_sube.baglanti.Open();

                SqlCommand command = new SqlCommand(query, vt_sube.baglanti);


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
                if (vt_sube.baglanti.State ==ConnectionState.Open)
                {
                    vt_sube.baglanti.Close();
                }
            }
         

        }
     
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString()).Length; i++)
            {

                txt_adres.Text = vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString())[2];
                txt_personel_sayisi.Text = vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString())[1];
                txt_sube_adi.Text = vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString())[0];

                //3.indexten id dönüyor
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = "Ekle";
            comboBox1.Enabled = false; 
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            button1.Text = "Sil"; temizle(txt_sube_adi); temizle(txt_sube_adi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Güncelle")
            {
                if (true)
                {
                    vt_sube.subeGuncelle(vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString())[3], txt_adres.Text, txt_sube_adi.Text);
                    temizle();
                    //combobx ı temizliyoruz
                    comboBox1.Items.Clear();
                    comboBoxDoldur();
                }
             
              else
                {

                MessageBox.Show("İşlem İptal Edildi", "Silme İptal", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            if (button1.Text == "Sil")
            {

                if (DialogResult.Yes ==MessageBox.Show("Silme işlemi ile Şube İle İlgili Tüm Kayıtlar Etkilenecektir.\n İşlemini Onaylıyor musunuz? ","Silme Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Warning ))
                {
                    vt_sube.subeSil(vt_sube.subeBilgileri(comboBox1.SelectedItem.ToString())[3]);
                    comboBox1.Items.Clear();
                    temizle(); 
                    comboBoxDoldur();
                }
                else
                {
                    MessageBox.Show("İşlem İptal Edildi","Silme İptal",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
              
            }
            if (button1.Text == "Ekle")
            {
                if (DialogResult.OK == MessageBox.Show("Ekleme İşlemini Onaylıyor musunuz? ", "Ekleme Onay", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    vt_sube.subeEkle(txt_sube_adi.Text, txt_adres.Text);
                    temizle(); comboBox1.Items.Clear(); comboBoxDoldur();
                }
                else
                {
                    MessageBox.Show("Ekleme İptal Edildi", "Ekleme İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}
