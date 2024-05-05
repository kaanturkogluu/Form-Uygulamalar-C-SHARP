using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    public partial class Musteri_Islemleri : Form
    {
        int admindeger;
        public Musteri_Islemleri(int admin)
        {
            admindeger = admin;
            InitializeComponent();
           
        }
        VeriTabaniMusteri vt_musteri = new VeriTabaniMusteri(); 
        private void Musteri_Islemleri_Load(object sender, EventArgs e)
        {
            if (admindeger==1)
            {
                txt_bakiye.Enabled = true;
            }
            else
            {
                txt_bakiye.Enabled = false; 
            }

            listele();
        }
        void listele()
        {
           dtgrid_musteri.DataSource = vt_musteri.musteriListeleTable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           dtgrid_musteri.DataSource= vt_musteri.müsteriFiltrele(textBox1.Text);
            temizle(txt_ad, txt_adres, txt_bakiye, txt_tc, txt_telefon);
        }
        int id;

        private void dtgrid_musteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           txt_ad.Text = dtgrid_musteri.CurrentRow.Cells["MusteriAdi"].Value.ToString();
          txt_bakiye.Text = dtgrid_musteri.CurrentRow.Cells["MusteriBakiye"].Value.ToString();
          txt_tc.Text = dtgrid_musteri.CurrentRow.Cells["MusteriTc"].Value.ToString();
          txt_telefon.Text = dtgrid_musteri.CurrentRow.Cells["MusteriTelefonNo"].Value.ToString();
          txt_adres.Text = dtgrid_musteri.CurrentRow.Cells["MusteriAdres"].Value.ToString();
            id = int.Parse(dtgrid_musteri.CurrentRow.Cells["MusteriId"].Value.ToString());
        }
        // textboxları temizlemek için fonsiyon
        public void temizle(params TextBox[] text)
        {
            foreach (TextBox item in text)
            {
                item.Clear();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //müşteri seçilmiş mi kontrolü 
              if (txt_ad.Text!="")
            {
                DialogResult result = MessageBox.Show("Silme İşlemini Onaylayın", "Silme Onay", MessageBoxButtons.OKCancel);
                //işlem onaylanınıca silme yapılaccak 
                if (result == DialogResult.OK)
                {
                    vt_musteri.musteriSil(id.ToString());
                    temizle(txt_ad, txt_adres, txt_bakiye, txt_tc, txt_telefon);
                    listele();
                

                }
                else
                {
                    MessageBox.Show("İptal Edildi ", "Sİlme İşlem İptal");
                }

            }
            else
            {
                MessageBox.Show("Bir Kayıt Seçiniz","Kayıt Silme Hatası");
            }
           
          

        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (txt_tc.TextLength < 11)
            {
                MessageBox.Show("Hatalı Tc girişi");
            }
            else
            {



                if (MessageBox.Show("Eklemeyi Onaylayın ", "Ekleme Onay", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {




                    string[] bilgiler = { txt_ad.Text, txt_telefon.Text, txt_tc.Text, txt_adres.Text, txt_bakiye.Text };
                    //tc üzerindne veri tabanında kayıt var mı kontrolü
                    if (!vt_musteri.musteriTcKotrol(txt_tc.Text))
                    {

                        // ekleme işlemi
                        vt_musteri.musteriEkle(bilgiler);
                        listele();
                        MessageBox.Show("Kayit Tamamlandı","Kayıt Onay",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Sistemde Zaten Kayıtlıdır", "Mükerrir Kayıt");
                    }


                }
                else
                {
                    MessageBox.Show("Kayit İptal Edildi", "Kayıt İptali", MessageBoxButtons.OK);
                }
            }
        }

        private void txt_tc_TextChanged(object sender, EventArgs e)
        {
            // girilcek max karakter
            txt_tc.MaxLength = 11; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // olan seçilmiş mi onayı 
            if (id!=null)
            { // onay 
                if (DialogResult.OK == MessageBox.Show("Güncelleme işlemini Onaylayın ", "Güncelleme Onay", MessageBoxButtons.OKCancel))
                {
                    vt_musteri.musteriGuncelle(txt_ad.Text, txt_tc.Text,txt_bakiye.Text, txt_telefon.Text, txt_adres.Text, id);
                    listele(); 
                }
                else
                {
                    MessageBox.Show("islem iptal edilmiştir", "Güncelleme İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Güncellemek için veri seçiniz","Yanlış Güncelleme");
            }
           
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle(txt_ad, txt_adres, txt_bakiye, txt_tc, txt_telefon);
        }

        private void txt_tc_KeyPress(object sender, KeyPressEventArgs e)
        {
            // tc için sadece sayı girişi
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_telefon_TextChanged(object sender, EventArgs e)
        {
            txt_telefon.MaxLength = 11; 
        }

        private void txt_bakiye_TextChanged(object sender, EventArgs e)
        {
            txt_bakiye.MaxLength = 10; 
        }

        private void txt_bakiye_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_bakiye_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
